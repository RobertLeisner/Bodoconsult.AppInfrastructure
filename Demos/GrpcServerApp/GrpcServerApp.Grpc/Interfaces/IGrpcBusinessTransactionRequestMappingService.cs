// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Interfaces;
using Google.Protobuf;
using Grpc.Core;

namespace GrpcServerApp.Grpc.Interfaces
{
    /// <summary>
    /// Interface for mapping GRPC requests to internal business transaction requests
    /// </summary>
    public interface IGrpcBusinessTransactionRequestMappingService
    {
        /// <summary>
        /// Map a GRPC request to an internal business transaction request
        /// </summary>
        /// <param name="request">Current GRPC request</param>
        /// <param name="context">Request context with metadata</param>
        /// <returns>Internal business transaction request</returns>
        IBusinessTransactionRequestData MapToBusinessTransactionRequestData(BusinessTransactionRequest request,
            ServerCallContext context);


        /// <summary>
        /// Helper method to provoke moving to transactions. Should be replaced with 
        /// </summary>
        /// <param name="grpcRequest">Current not business transaction based GRPC request</param>
        /// <param name="context">Request context with meta data</param>
        /// <returns>Internal business transaction request</returns>
        IBusinessTransactionRequestData MapGrpcRequestToBusinessTransactionRequestData<T>(IMessage<T> grpcRequest,
            ServerCallContext context) where T : IMessage<T>;

    }
}