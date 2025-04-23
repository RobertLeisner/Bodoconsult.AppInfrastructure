// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.PerformanceLogging;

namespace Bodoconsult.App.Test.PerformanceLogging;

[TestFixture]
public class UnitTestPerformanceLoggerManager
{

    private bool _delegateWasFired;

    [Test]
    public void TestCtor()
    {
        // Arrange 
        var logger = new PerformanceLogger();

        // Act  
        var manager = new PerformanceLoggerManager(logger);

        // Assert
        Assert.That(manager, Is.Not.Null);
        Assert.That(manager.PerformanceLogger, Is.Not.Null);
    }


    [Test]
    public void TestNoLogging()
    {
        // Arrange 
        _delegateWasFired = false;

        var logger = new PerformanceLogger();

        var manager = new PerformanceLoggerManager(logger)
        {
            StatusMessageDelegate = StatusMessageDelegate
        };

        Assert.That(manager, Is.Not.Null);
        Assert.That(manager.PerformanceLogger, Is.Not.Null);

        // Act  
        Thread.Sleep(2000);

        // Assert
        Assert.That(!_delegateWasFired);

    }

    [Test]
    public void TestStartLogging()
    {
        // Arrange 
        _delegateWasFired = false;

        var logger = new PerformanceLogger();

        var manager = new PerformanceLoggerManager(logger)
        {
            StatusMessageDelegate = StatusMessageDelegate,
            DelayUntilNextRunnerFired = 100
        };

        Assert.That(manager, Is.Not.Null);
        Assert.That(manager.PerformanceLogger, Is.Not.Null);

        // Act  
        manager.StartLogging();
        Thread.Sleep(2000);

        // Assert
        Assert.That(_delegateWasFired);

    }


    private void StatusMessageDelegate(string message)
    {
        _delegateWasFired = true;
    }
}