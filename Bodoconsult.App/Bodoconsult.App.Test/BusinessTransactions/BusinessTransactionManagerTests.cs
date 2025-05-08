﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.BusinessTransactions;
using Bodoconsult.App.BusinessTransactions.RequestData;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Test.Helpers;
using Bodoconsult.App.Test.SampleBusinessLogic;
using Bodoconsult.App.Test.TestData;

namespace Bodoconsult.App.Test.BusinessTransactions;

[TestFixture]
internal class BusinessTransactionManagerTests
{

    private readonly IAppLoggerProxy _logger = TestHelper.GetFakeAppLoggerProxy();

    [Test]
    public void TestCtor()
    {
        // Arrange 
        var aes = TestHelper.CreateAppEventSource();

        // Act  
        var m = new BusinessTransactionManager(_logger, aes);

        // Assert
        Assert.That(m.CreateBusinessTransactionDelegates, Is.Not.Null);
        Assert.That(m.CreateBusinessTransactionDelegates.Count, Is.EqualTo(0));

    }


    [Test]
    public void TestAddProvider()
    {
        // Arrange 
        var aes = TestHelper.CreateAppEventSource();

        var m = new BusinessTransactionManager(_logger, aes);

        var dependency = new SampleBusinessLogicLayer();
        var p = new TestBusinessTransactionProvider(dependency);

        // Act  
        m.AddProvider(p);

        // Assert
        Assert.That(m.CreateBusinessTransactionDelegates.Count, Is.EqualTo(p.CreateBusinessTransactionDelegates.Count));

    }

    [Test]
    public void TestCheckForBusinessTransactionSuccess()
    {
        // Arrange 
        var aes = TestHelper.CreateAppEventSource();

        const int transactionId = 1000;
        var m = new BusinessTransactionManager(_logger, aes);
        var dependency = new SampleBusinessLogicLayer();
        var p = new TestBusinessTransactionProvider(dependency);

        m.AddProvider(p);

        // Act  
        var t = m.CheckForBusinessTransaction(transactionId);

        // Assert
        Assert.That(t, Is.Not.Null);
        Assert.That(m.TransactionCache.Count, Is.EqualTo(1));

    }

    [Test]
    public void TestCheckForBusinessTransactionRepeatedSuccess()
    {
        // Arrange 
        var aes = TestHelper.CreateAppEventSource();

        const int transactionId = 1000;
        var m = new BusinessTransactionManager(_logger, aes);
        var dependency = new SampleBusinessLogicLayer();
        var p = new TestBusinessTransactionProvider(dependency);

        m.AddProvider(p);

        // Act  
        var t = m.CheckForBusinessTransaction(transactionId);
        var t2 = m.CheckForBusinessTransaction(transactionId);

        // Assert
        Assert.That(t, Is.Not.Null);
        Assert.That(m.TransactionCache.Count, Is.EqualTo(1));
        Assert.That(t2, Is.EqualTo(t));
    }

    [Test]
    public void TestCheckForBusinessTransactionNoSuccess()
    {
        // Arrange 
        var aes = TestHelper.CreateAppEventSource();

        const int transactionId = 1000;
        var m = new BusinessTransactionManager(_logger, aes);
        var p = new TestBusinessTransactionProviderNoDelegate();

        m.AddProvider(p);

        // Act and assert
        Assert.Throws<ArgumentException>(() =>
        {
            var t = m.CheckForBusinessTransaction(transactionId);
        });

    }

    [Test]
    public void TestRunBusinessTransactionSuccess()
    {
        // Arrange 
        var aes = TestHelper.CreateAppEventSource();

        const int transactionId = 1000;
        var m = new BusinessTransactionManager(_logger, aes);
        var dependency = new SampleBusinessLogicLayer();
        var p = new TestBusinessTransactionProvider(dependency);

        m.AddProvider(p);

        IBusinessTransactionRequestData requestData = new EmptyBusinessTransactionRequestData();

        // Act  
        var t = m.RunBusinessTransaction(transactionId, requestData);

        // Assert
        Assert.That(t, Is.Not.Null);
        Assert.That(m.TransactionCache, Has.Count.EqualTo(1));
        Assert.That(t.RequestData, Is.EqualTo(requestData));
    }

}