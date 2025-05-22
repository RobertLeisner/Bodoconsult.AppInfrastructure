// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Grpc.Net.Client;
using Microsoft.Extensions.Logging;

namespace GrpcServerApps.Tests.Helpers;

public class IntegrationTestBase : IDisposable
{
    private GrpcChannel _channel;
    private IDisposable _testContext;

    protected GrpcTestFixture<Startup> Fixture { get; set; }

    protected ILoggerFactory LoggerFactory => Fixture.LoggerFactory;

    protected GrpcChannel Channel => _channel ??= CreateChannel();

    protected GrpcChannel CreateChannel()
    {
        return GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
        {
            LoggerFactory = LoggerFactory,
            HttpHandler = Fixture.Handler
        });
    }

    public IntegrationTestBase(GrpcTestFixture<Startup> fixture)
    {
        Fixture = fixture;
        _testContext = Fixture.GetTestContext();
    }

    public void Dispose()
    {
        _testContext?.Dispose();
        _channel = null;
    }
}