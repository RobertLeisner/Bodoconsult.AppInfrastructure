// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.BusinessTransactions.Replies;
using Bodoconsult.App.GrpcBackgroundService.Interfaces;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;

namespace GrpcServerApp.Grpc.MappingServices
{
    /// <summary>
    /// Current impl for <see cref="IGrpcBusinessTransactionRequestMappingService"/> for mapping GRPC requests to internal business transaction requests
    /// </summary>
    public class GrpcBusinessTransactionReplyMappingService : IGrpcBusinessTransactionReplyMappingService
    {

        private delegate void AddContainerContentDelegate(BusinessTransactionReply reply, IBusinessTransactionReply internalReply);

        private readonly Dictionary<string, AddContainerContentDelegate> _containers = new();

        private readonly IAppLoggerProxy _appLogger;

        /// <summary>
        /// Default ctor
        /// </summary>
        public GrpcBusinessTransactionReplyMappingService(IAppLoggerProxy appLogger)
        {
            _appLogger = appLogger;

            _containers.Add(nameof(ObjectIdBusinessTransactionReply), CreateObjectIdReply);
            _containers.Add(nameof(ObjectUidBusinessTransactionReply), CreateObjectUidReply);
            _containers.Add(nameof(StringBusinessTransactionReply), CreateStringBusinessTransactionReply);
            _containers.Add(nameof(StringListBusinessTransactionReply), CreateStringListBusinessTransactionReply);
            //_containers.Add(nameof(UidListBusinessTransactionReply), CreateUidListBusinessTransactionReply);
            _containers.Add(nameof(BoolBusinessTransactionReply), CreateBoolBusinessTransactionReply);
            _containers.Add(nameof(DateBusinessTransactionReply), CreateDateBusinessTransactionReply);
        }



        public void CreateDateBusinessTransactionReply(BusinessTransactionReply reply, IBusinessTransactionReply internalReply)
        {
            if (internalReply is not DateBusinessTransactionReply sr)
            {
                return;
            }

            var ir = new LongReply
            {
                Value = sr.Date?.ToFileTimeUtc() ?? 0
            };

            reply.ReplyData = Google.Protobuf.WellKnownTypes.Any.Pack(ir);
        }

        public void CreateIntegerBusinessTransactionReply(BusinessTransactionReply reply, IBusinessTransactionReply internalReply)
        {
            if (internalReply is not IntegerBusinessTransactionReply sr)
            {
                return;
            }

            var ir = new IntegerReply
            {
                Value = sr.Value
            };

            reply.ReplyData = Google.Protobuf.WellKnownTypes.Any.Pack(ir);
        }

        

        

        public void CreateBoolBusinessTransactionReply(BusinessTransactionReply reply, IBusinessTransactionReply internalReply)
        {
            if (internalReply is not BoolBusinessTransactionReply sr)
            {
                return;
            }

            var ir = new BoolReply
            {
                Value = sr.Value
            };

            reply.ReplyData = Google.Protobuf.WellKnownTypes.Any.Pack(ir);
        }

        
        public void CreateStringBusinessTransactionReply(BusinessTransactionReply reply, IBusinessTransactionReply internalReply)
        {
            if (internalReply is not StringBusinessTransactionReply lr)
            {
                return;
            }

            var ir = new StringReply
            {
                Message = lr.Content ?? string.Empty
            };

            reply.ReplyData = Google.Protobuf.WellKnownTypes.Any.Pack(ir);
        }

       

        

        public void CreateStringListBusinessTransactionReply(BusinessTransactionReply reply, IBusinessTransactionReply internalReply)
        {

            // String list provided
            if (internalReply is not StringListBusinessTransactionReply sl)
            {
                return;
            }

            var ir = new ObjectNamesReply();

            foreach (var s in sl.Content)
            {
                ir.ObjectNames.Add(s ?? string.Empty);
            }

            reply.ReplyData = Google.Protobuf.WellKnownTypes.Any.Pack(ir);
        }

        public void CreateObjectUidReply(BusinessTransactionReply reply, IBusinessTransactionReply internalReply)
        {
            // Object UID provided
            if (internalReply is not ObjectUidBusinessTransactionReply s)
            {
                return;
            }
            var ir = new ObjectUidReply
            {
                ObjectUid = s.ObjectUid.ToString()
            };

            reply.ReplyData = Google.Protobuf.WellKnownTypes.Any.Pack(ir);
        }

        /// <summary>
        /// Map a ObjectIdBusinessTransactionReply to a ObjectIdReply message
        /// </summary>
        /// <param name="reply">Internal business transaction reply</param>
        /// <param name="internalReply">GRPC reply</param>
        public void CreateObjectIdReply(BusinessTransactionReply reply, IBusinessTransactionReply internalReply)
        {
            // Object UID provided
            if (internalReply is not ObjectIdBusinessTransactionReply s)
            {
                return;
            }

            var ir = new ObjectIdReply
            {
                ObjectId = s.ObjectId
            };

            reply.ReplyData = Google.Protobuf.WellKnownTypes.Any.Pack(ir);
        }


        /// <summary>
        /// Map a internal reply instance <see cref="IBusinessTransactionReply"/> to a <see cref="BusinessTransactionReply"/> message
        /// </summary>
        /// <param name="internalReply">Internal business transaction reply</param>
        /// <returns>Protobuf business transaction reply</returns>
        public BusinessTransactionReply MapInternalReplyToGrpc(IBusinessTransactionReply internalReply)
        {
            if (internalReply.RequestData != null)
            {
                try
                {
                    _appLogger.LogInformation(
                        $"BT {internalReply.RequestData.TransactionId} ({internalReply.RequestData.TransactionGuid}) reply: {ObjectHelper.GetObjectPropertiesAsString(internalReply)}");
                }
                catch //(Exception e)
                {
                    _appLogger.LogDebug($"Object serialization for logging failed {internalReply.GetType().Name}");
                }
            }

            var result = new BusinessTransactionReply
            {
                TransactionId = internalReply.RequestData?.TransactionId ?? 0,
                ErrorCode = internalReply.ErrorCode,
                ExceptionMessage = internalReply.ExceptionMessage ?? string.Empty,
                LogMessage = internalReply.Message ?? string.Empty,
            };

            //// Default reply: leave here
            //if (!internalReply.GetType().IsSubclassOf(typeof(DefaultBusinessTransactionReply)))
            //{
            //    return result;
            //}

            var typeName = internalReply.GetType().Name;

            var success = _containers.TryGetValue(typeName, out var containerDelegate);

            if (!success)
            {
                return result;
            }

            containerDelegate.Invoke(result, internalReply);
            return result;
        }

    }
}