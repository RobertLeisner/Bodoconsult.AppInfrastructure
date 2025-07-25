// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.GrpcBackgroundService.BusinessTransactions;
using Bodoconsult.App.GrpcBackgroundService.Interfaces;

namespace GrpcServerApp.Grpc.MappingServices;

/// <summary>
/// Current impl for <see cref="IGrpcBusinessTransactionRequestMappingService"/> for mapping GRPC requests to internal business transaction requests
/// </summary>
public class GrpcBusinessTransactionRequestMappingService : BaseGrpcBusinessTransactionRequestMappingService
{

    public GrpcBusinessTransactionRequestMappingService(IAppLoggerProxy appLogger) : base(appLogger)
    {
        // Register all request delegates width exception of the default request delegates

        //_allBusinessTransactionRequestDataDelegates.Add(ObjectIdRequest.Descriptor, CreateObjectIdRequest);

    }

    ///// <summary>
    ///// Create an object name and string request. Public for unit testing. Do not use directly
    ///// </summary>
    ///// <param name="request">Current GRPC request</param>
    ///// <returns>Internal business transaction request</returns>
    //public IBusinessTransactionRequestData CreateObjectIdIntRequest(BusinessTransactionRequest request)
    //{
    //    var o = request.RequestData.Unpack<ObjectIdIntRequest>();

    //    var ir = new ObjectIdIntBusinessTransactionRequestData
    //    {
    //        ObjectId = o.ObjectId,
    //        Value = o.Value
    //    };
    //    return ir;
    //}
}