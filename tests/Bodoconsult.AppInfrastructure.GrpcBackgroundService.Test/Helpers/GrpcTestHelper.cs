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

using Grpc.Core;
using Grpc.Core.Testing;
using Grpc.Core.Utils;

namespace Bodoconsult.App.GrpcBackgroundService.Test.Helpers;

/// <summary>
/// GRPC helper class for unit testing
/// </summary>
public static class GrpcTestHelper
{

    /// <summary>
    /// Create a test context
    /// </summary>
    /// <returns></returns>
    public static ServerCallContext CreateTestContext(int userId = 0)
    {

        var metaData = new Metadata
        {
            {"userid", userId.ToString()},
        };

        return TestServerCallContext.Create("fooMethod", "192.168.10.125",
            DateTime.UtcNow.AddHours(1),
            metaData,
            CancellationToken.None,
            "127.0.0.1",
            null,
            null,
            metadata => TaskUtils.CompletedTask,
            () => new WriteOptions(),
            writeOptions => { });
    }

}