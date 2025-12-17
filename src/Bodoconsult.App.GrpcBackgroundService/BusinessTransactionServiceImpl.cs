// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

// GRPC Copyright 2019 The gRPC Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.GrpcBackgroundService.Interfaces;
using Bodoconsult.App.Interfaces;
using Grpc.Core;

namespace Bodoconsult.App.GrpcBackgroundService;

/// <summary>
/// Business transction GRPC service implementation
/// </summary>
public class BusinessTransactionServiceImpl : BusinessTransactionService.BusinessTransactionServiceBase
{
    private readonly IGrpcBusinessTransactionRequestMappingService _requestMappingService;
    private readonly IAppLoggerProxy _logger;
    private readonly IBusinessTransactionManager _businessTransactionManager;
    private readonly IGrpcBusinessTransactionReplyMappingService _replyMappingService;


    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="requestMappingService">Current request mapping service</param>
    /// <param name="replyMappingService">Current reply mapping service</param>
    /// <param name="businessTransactionManager">Current business transaction managr instance</param>
    /// <param name="logger">Current app logger</param>
    public BusinessTransactionServiceImpl(IGrpcBusinessTransactionRequestMappingService requestMappingService, IGrpcBusinessTransactionReplyMappingService replyMappingService, IBusinessTransactionManager businessTransactionManager, IAppLoggerProxy logger)
    {
        _requestMappingService = requestMappingService;
        _logger = logger;
        _businessTransactionManager = businessTransactionManager;
        _replyMappingService = replyMappingService;
    }

    /// <summary>
    /// Start a business transaction
    /// </summary>
    /// <param name="request">Current business transaction request</param>
    /// <param name="context">Current GRPC context</param>
    /// <returns>Task wit a business transaction reply</returns>
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