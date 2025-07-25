// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.GrpcBackgroundService.BusinessTransactions;
using Bodoconsult.App.GrpcBackgroundService.Interfaces;

namespace GrpcServerApp.Grpc.MappingServices;

/// <summary>
/// Current impl for <see cref="IGrpcBusinessTransactionRequestMappingService"/> for mapping GRPC requests to internal business transaction requests
/// </summary>
public class GrpcBusinessTransactionReplyMappingService : BaseGrpcBusinessTransactionReplyMappingService
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public GrpcBusinessTransactionReplyMappingService(IAppLoggerProxy appLogger): base(appLogger)
    {

        // Register all reply delegates with the exception of the default reply delegates

        // Containers.Add(nameof(ObjectIdBusinessTransactionReply), CreateObjectIdReply);

    }


    ///// <summary>
    ///// Map a ObjectIdBusinessTransactionReply to a ObjectIdReply message. Public for unit tests
    ///// </summary>
    ///// <param name="reply">Internal business transaction reply</param>
    ///// <param name="internalReply">GRPC reply</param>
    //public void CreateObjectIdReply(BusinessTransactionReply reply, IBusinessTransactionReply internalReply)
    //{
    //    // Object UID provided
    //    if (internalReply is not ObjectIdBusinessTransactionReply s)
    //    {
    //        return;
    //    }

    //    var ir = new ObjectIdReply
    //    {
    //        ObjectId = s.ObjectId
    //    };

    //    reply.ReplyData = Google.Protobuf.WellKnownTypes.Any.Pack(ir);
    //}

}