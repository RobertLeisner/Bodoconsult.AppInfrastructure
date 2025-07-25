// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.GrpcBackgroundService.Interfaces;
using Bodoconsult.App.Interfaces;
using Grpc.Core;

namespace Bodoconsult.App.GrpcBackgroundService;

public class BusinessTransactionServiceImpl : BusinessTransactionService.BusinessTransactionServiceBase
{
    private readonly IGrpcBusinessTransactionRequestMappingService _requestMappingService;
    private readonly IAppLoggerProxy _logger;
    private readonly IBusinessTransactionManager _businessTransactionManager;
    private readonly IGrpcBusinessTransactionReplyMappingService _replyMappingService;

    public BusinessTransactionServiceImpl(IGrpcBusinessTransactionRequestMappingService requestMappingService, IGrpcBusinessTransactionReplyMappingService replyMappingService, IBusinessTransactionManager businessTransactionManager, IAppLoggerProxy logger)
    {
        _requestMappingService = requestMappingService;
        _logger = logger;
        _businessTransactionManager = businessTransactionManager;
        _replyMappingService = replyMappingService;
    }

    public override Task<BusinessTransactionReply> StartTransaction(BusinessTransactionRequest request, ServerCallContext context)
    { 
        try
        {
            var internalRequest = _requestMappingService.MapToBusinessTransactionRequestData(request, context);

            //_logger.LogInformation($"BT {request.TransactionId} requested by {internalRequest.MetaDataClientName} (IP {internalRequest.MetaDataIpAddress}): {JsonHelper.JsonSerialize(request)}");
            _logger.LogInformation($"BT {request.TransactionId} requested by {internalRequest.MetaDataClientName}");
                
            var internalReply = _businessTransactionManager.RunBusinessTransaction(request.TransactionId, internalRequest);

            var reply = _replyMappingService.MapInternalReplyToGrpc(internalReply);

            _logger.LogInformation($"BT {request.TransactionId} reply will be sent to {internalRequest.MetaDataClientName} now");
            return Task.FromResult(reply);
        }
        catch (Exception e)
        {
            var reply = new BusinessTransactionReply
            {
                TransactionId = request.TransactionId,
                ExceptionMessage = e.ToString(),
                LogMessage = $"Business transaction {request.TransactionId} failed",
                ErrorCode = -1
            };

            return Task.FromResult(reply);
        }

    }

}