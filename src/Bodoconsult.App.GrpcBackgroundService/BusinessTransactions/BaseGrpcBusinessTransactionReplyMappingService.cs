// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.BusinessTransactions.Replies;
using Bodoconsult.App.GrpcBackgroundService.Interfaces;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.GrpcBackgroundService.BusinessTransactions;

/// <summary>
/// Base class for <see cref="IGrpcBusinessTransactionReplyMappingService"/> implementations
/// </summary>
public class BaseGrpcBusinessTransactionReplyMappingService : IGrpcBusinessTransactionReplyMappingService
{

    // ToDo: JW add unit tests for methods

    protected delegate void AddContainerContentDelegate(BusinessTransactionReply reply, IBusinessTransactionReply internalReply);

    protected readonly Dictionary<string, AddContainerContentDelegate> Containers = new();

    protected readonly IAppLoggerProxy AppLogger;

    public BaseGrpcBusinessTransactionReplyMappingService(IAppLoggerProxy appLogger)
    {
        AppLogger = appLogger;

        Containers.Add(nameof(ObjectIdBusinessTransactionReply), CreateObjectIdReply);
        Containers.Add(nameof(ObjectUidBusinessTransactionReply), CreateObjectUidReply);
        Containers.Add(nameof(StringBusinessTransactionReply), CreateStringBusinessTransactionReply);
        Containers.Add(nameof(StringListBusinessTransactionReply), CreateStringListBusinessTransactionReply);
        Containers.Add(nameof(UidListBusinessTransactionReply), CreateUidListBusinessTransactionReply);
        Containers.Add(nameof(BoolBusinessTransactionReply), CreateBoolBusinessTransactionReply);
        Containers.Add(nameof(DateBusinessTransactionReply), CreateDateBusinessTransactionReply);
        Containers.Add(nameof(IntegerBusinessTransactionReply), CreateIntegerBusinessTransactionReply);
    }



    /// <summary>
    /// Map an internal reply instance <see cref="IBusinessTransactionReply"/> to a <see cref="BusinessTransactionReply"/> message
    /// </summary>
    /// <param name="internalReply">Internal business transaction reply</param>
    /// <returns>Protobuf business transaction reply</returns>
    public BusinessTransactionReply MapInternalReplyToGrpc(IBusinessTransactionReply internalReply)
    {
        if (internalReply.RequestData != null)
        {
            try
            {
                AppLogger.LogInformation(
                    $"BT {internalReply.RequestData.TransactionId} ({internalReply.RequestData.TransactionGuid}) reply: {ObjectHelper.GetObjectPropertiesAsString(internalReply)}");
            }
            catch //(Exception e)
            {
                AppLogger.LogDebug($"Object serialization for logging failed {internalReply.GetType().Name}");
            }
        }

        var result = new BusinessTransactionReply
        {
            TransactionId = internalReply.RequestData?.TransactionId ?? 0,
            TransactionUid = internalReply.RequestData?.TransactionGuid.ToString() ?? "",
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

        var success = Containers.TryGetValue(typeName, out var containerDelegate);

        if (!success || containerDelegate==null)
        {
            return result;
        }

        containerDelegate.Invoke(result, internalReply);
        return result;
    }


    public void CreateUidListBusinessTransactionReply(BusinessTransactionReply reply, IBusinessTransactionReply internalReply)
    {
        if (internalReply is not UidListBusinessTransactionReply sr)
        {
            return;
        }

        var ir = new ObjectNamesReply();

        foreach (var uid in sr.Uids)
        {
            ir.ObjectNames.Add(uid.ToString());
        }

        reply.ReplyData = Google.Protobuf.WellKnownTypes.Any.Pack(ir);

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
    /// Map a ObjectIdBusinessTransactionReply to a ObjectIdReply message. Public for unit tests
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

}