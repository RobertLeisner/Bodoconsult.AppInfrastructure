// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Interfaces;

namespace GrpcServerApp.Grpc.Interfaces
{
    /// <summary>
    /// Interface for mapping internal business transaction replies to GRPC replies
    /// </summary>
    public interface IGrpcBusinessTransactionReplyMappingService
    {

        /// <summary>
        /// Map a internal reply instance <see cref="IBusinessTransactionReply"/> to a <see cref="BusinessTransactionReply"/> message
        /// </summary>
        /// <param name="internalReply">Internal business transaction reply</param>
        /// <returns>Protobuf business transaction reply</returns>
        BusinessTransactionReply MapInternalReplyToGrpc(IBusinessTransactionReply internalReply);

    }
}