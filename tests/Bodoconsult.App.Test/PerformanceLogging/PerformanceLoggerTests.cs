// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.PerformanceLogging;

namespace Bodoconsult.App.Test.PerformanceLogging;

[TestFixture]
public class PerformanceLoggerTests
{

    [Test]
    public void TestGetCountersAsString()
    {

        // Arrange 
        var logger = new PerformanceLogger();

        logger.StartLogger();

        for (var i = 0; i < 100; i++)
        {
            Thread.Sleep(50);
        }

        logger.StopLogger();

        // Act  
        var s = logger.GetCountersAsString();

        // Assert
        Assert.That(!string.IsNullOrEmpty(s));
        Debug.Print(s);

    }
}