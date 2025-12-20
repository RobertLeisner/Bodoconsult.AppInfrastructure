// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

#region GRPC copyright notice and license

// Copyright 2019 The gRPC Authors
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

#endregion

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.BusinessTransactions.RequestData;
using Bodoconsult.App.GrpcBackgroundService.BusinessTransactions;
using Bodoconsult.App.GrpcBackgroundService.Test.Helpers;
using Bodoconsult.App.Test.Helpers;
using Grpc.Core;

namespace Bodoconsult.App.GrpcBackgroundService.Test;

[TestFixture]
internal class BaseGrpcBusinessTransactionRequestMappingServiceTests
{
    private readonly BaseGrpcBusinessTransactionRequestMappingService _service;
    private readonly IAppLoggerProxy _logger = TestHelper.GetFakeAppLoggerProxy();
    private readonly ServerCallContext _context;


    public BaseGrpcBusinessTransactionRequestMappingServiceTests()
    {
        const int userId = 1;

        _service = new BaseGrpcBusinessTransactionRequestMappingService(_logger);
        _context = GrpcTestHelper.CreateTestContext(userId);
    }

    [Test]
    public void MapGrpc_EmptyRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new EmptyRequest();

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(EmptyBusinessTransactionRequestData)));
    }

    [Test]
    public void MapGrpc_ObjectIdRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectIdRequest
        {
            ObjectId = 99
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectIdBusinessTransactionRequestData)));

    }

    [Test]
    public void MapGrpc_ObjectIdIntRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectIdIntRequest
        {
            ObjectId = 99,
            Value = 97
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectIdIntBusinessTransactionRequestData)));

        var o = (ObjectIdIntBusinessTransactionRequestData)result;
        Assert.That(o.ObjectId, Is.EqualTo(request.ObjectId));
        Assert.That(o.Value, Is.EqualTo(request.Value));
    }

    [Test]
    public void MapGrpc_ObjectIdStringRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectIdStringRequest
        {
            ObjectId = 99,
            Value = "blabb"
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectIdStringBusinessTransactionRequestData)));

        var o = (ObjectIdStringBusinessTransactionRequestData)result;
        Assert.That(o.ObjectId, Is.EqualTo(request.ObjectId));
        Assert.That(o.Value, Is.EqualTo(request.Value));
    }

    [Test]
    public void MapGrpc_ObjectIdListRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectIdListRequest
        {
            ObjectId = 99,
            Page = 97,
            PageSize = 96
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectIdListBusinessTransactionRequestData)));

        var o = (ObjectIdListBusinessTransactionRequestData)result;
        Assert.That(o.Page, Is.EqualTo(request.Page));
        Assert.That(o.PageSize, Is.EqualTo(request.PageSize));
    }

    [Test]
    public void MapGrpc_ObjectUidRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectUidRequest
        {
            ObjectUid = Guid.NewGuid().ToString()
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectGuidBusinessTransactionRequestData)));
    }

    [Test]
    public void MapGrpc_TwoObjectUidRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new TwoObjectUidRequest
        {
            ObjectUid1 = Guid.NewGuid().ToString(),
            ObjectUid2 = Guid.NewGuid().ToString()
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(TwoObjectGuidBusinessTransactionRequestData)));

        var internalRequest = (TwoObjectGuidBusinessTransactionRequestData)result;

        Assert.That(internalRequest.ObjectGuid1, Is.EqualTo(new Guid(request.ObjectUid1)));
        Assert.That(internalRequest.ObjectGuid2, Is.EqualTo(new Guid(request.ObjectUid2)));
    }

    [Test]
    public void MapGrpc_TwoObjectIdRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new TwoObjectIdRequest
        {
            ObjectId1 = 79,
            ObjectId2 = 98
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(TwoObjectIdBusinessTransactionRequestData)));

        var internalRequest = (TwoObjectIdBusinessTransactionRequestData)result;

        Assert.That(internalRequest.ObjectId1, Is.EqualTo(request.ObjectId1));
        Assert.That(internalRequest.ObjectId2, Is.EqualTo(request.ObjectId2));
    }

    [Test]
    public void MapGrpc_ObjectUidRequestGuidEmpty_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectUidRequest
        {
            ObjectUid = Guid.Empty.ToString()
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectGuidBusinessTransactionRequestData)));
    }

    [Test]
    public void MapGrpc_ObjectUidRequestInvalidGuid_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectUidRequest
        {
            ObjectUid = "blubb"
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectGuidBusinessTransactionRequestData)));
    }

    [Test]
    public void MapGrpc_ObjectUidRequestEmptyString_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectUidRequest
        {
            ObjectUid = string.Empty
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectGuidBusinessTransactionRequestData)));
    }

    [Test]
    public void MapGrpc_ObjectUidListRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectUidListRequest
        {
            ObjectUid = Guid.NewGuid().ToString(),
            Page = 2,
            PageSize = 99
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);


        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectGuidListBusinessTransactionRequestData)));

        var o = (ObjectGuidListBusinessTransactionRequestData)result;
        Assert.That(o.ObjectGuid.ToString(), Is.EqualTo(request.ObjectUid));
        Assert.That(o.Page, Is.EqualTo(request.Page));
        Assert.That(o.PageSize, Is.EqualTo(request.PageSize));
    }


    [Test]
    public void MapGrpc_ObjectNameRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectNameRequest
        {
            Name = "Test"
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);


        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectNameBusinessTransactionRequestData)));
    }

    //[Test]
    //public void MapGrpc_StringNameRequest()
    //{
    //    // Arrange 
    //    var request = new ObjectNameRequest
    //    {
    //        Name = "Test"
    //    };

    //    // Act  
    //    var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);


    //    // Assert
    //    Assert.That(result, Is.Not.Null);
    //    Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectNameBusinessTransactionRequestData)));
    //}

    [Test]
    public void MapGrpc_ObjectNameStringRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new ObjectNameStringRequest
        {
            Name = "Blabb",
            Value = "Hallo"
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);


        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(ObjectNameStringBusinessTransactionRequestData)));

        var o = (ObjectNameStringBusinessTransactionRequestData)result;

        Assert.That(o.ObjectName, Is.EqualTo(request.Name));
        Assert.That(o.Value, Is.EqualTo(request.Value));
    }

       
    [Test]
    public void MapGrpc_StringRequest_ReturnsTransactionRequest()
    {
        // Arrange 
        var request = new StringRequest
        {
            Message = "blubb"
        };

        // Act  
        var result = _service.MapGrpcRequestToBusinessTransactionRequestData(request, _context);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetType(), Is.EqualTo(typeof(StringBusinessTransactionRequestData)));

        var o = (StringBusinessTransactionRequestData)result;

        Assert.That(o.Content, Is.EqualTo(request.Message));

    }
}