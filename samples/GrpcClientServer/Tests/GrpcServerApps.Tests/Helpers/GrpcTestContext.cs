// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace GrpcServerApps.Tests.Helpers;

internal class GrpcTestContext<TStartup> : IDisposable where TStartup : class
{
    private readonly Stopwatch _stopwatch;
    private readonly GrpcTestFixture<TStartup> _fixture;

    public GrpcTestContext(GrpcTestFixture<TStartup> fixture)
    {
        _stopwatch = Stopwatch.StartNew();
        _fixture = fixture;
        _fixture.LoggedMessage += WriteMessage;
    }

    private void WriteMessage(LogLevel logLevel, string category, EventId eventId, string message, Exception exception)
    {
        var log = $"{_stopwatch.Elapsed.TotalSeconds:N3}s {category} - {logLevel}: {message}";
        if (exception != null)
        {
            log += Environment.NewLine + exception;
        }
        //_outputHelper.WriteLine(log);
    }

    public void Dispose()
    {
        _fixture.LoggedMessage -= WriteMessage;
    }
}