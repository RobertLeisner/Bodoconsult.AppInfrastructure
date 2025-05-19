// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Grpc.Core;
using Grpc.Core.Testing;
using Grpc.Core.Utils;

namespace Bodoconsult.App.GrpcBackgroundService.Tests.Helpers
{
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
                (metadata) => TaskUtils.CompletedTask,
                () => new WriteOptions(),
                (writeOptions) => { });
        }

    }
}
