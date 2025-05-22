// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.BusinessTransactions;
using Bodoconsult.App.EventCounters;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Test.Helpers;

namespace Bodoconsult.App.Test.EventSources;

[TestFixture]
internal class AppApmEventSourceTests
{
    private readonly IAppLoggerProxy _logger = TestHelper.GetFakeAppLoggerProxy();


    [Test]
    public void TestCtor()
    {
        // Arrange 

        // Act  
        var aes = new AppApmEventSource(_logger);

        // Assert
        Assert.That(aes.EventCounters, Is.Not.Null);
        Assert.That(aes.IncrementingEventCounters, Is.Not.Null);
        Assert.That(aes.PollingCounters, Is.Not.Null);
        Assert.That(aes.IncrementingPollingCounters, Is.Not.Null);

        Assert.That(aes.EventCounters, Has.Count.EqualTo(0));
        Assert.That(aes.IncrementingEventCounters, Has.Count.EqualTo(0));
        Assert.That(aes.PollingCounters, Has.Count.EqualTo(0));
        Assert.That(aes.IncrementingPollingCounters, Has.Count.EqualTo(0));
    }



    [Test]
    public void TestAddProvider()
    {
        // Arrange 
        var aes = new AppApmEventSource(_logger);

        // Act  
        aes.AddProvider(new BusinessTransactionEventSourceProvider());

        // Assert
        Assert.That(aes.EventCounters, Has.Count.EqualTo(1));
        Assert.That(aes.IncrementingEventCounters, Has.Count.EqualTo(1));
        Assert.That(aes.PollingCounters, Has.Count.EqualTo(0));
        Assert.That(aes.IncrementingPollingCounters, Has.Count.EqualTo(0));

    }

    [Test]
    public void TestGetMetricEventCounter()
    {
        // Arrange 
        const string ecName = BusinessTransactionEventSourceProvider.BtmRunBusinessTransactionDuration;

        var aes = new AppApmEventSource(_logger);
        aes.AddProvider(new BusinessTransactionEventSourceProvider());


        // Act  
        var ec = aes.GetMetricEventCounter(ecName);

        // Assert
        Assert.That(ec, Is.Not.Null);
        Assert.That(ec.Name, Is.EqualTo(ecName));

    }

    [Test]
    public void TestGetIncrementEventCounter()
    {
        // Arrange 
        const string ecName = BusinessTransactionEventSourceProvider.BtmRunBusinessTransactionSuccess;

        var aes = new AppApmEventSource(_logger);
        aes.AddProvider(new BusinessTransactionEventSourceProvider());

        // Act  
        var ec = aes.GetIncrementEventCounter(ecName);

        // Assert
        Assert.That(ec, Is.Not.Null);
        Assert.That(ec.Name, Is.EqualTo(ecName));

    }


}