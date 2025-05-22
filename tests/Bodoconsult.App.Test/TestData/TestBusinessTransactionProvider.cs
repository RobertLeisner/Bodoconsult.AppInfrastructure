// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.BusinessTransactions;
using Bodoconsult.App.BusinessTransactions.RequestData;
using Bodoconsult.App.Delegates;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Test.SampleBusinessLogic;

namespace Bodoconsult.App.Test.TestData;

internal class TestBusinessTransactionProvider: IBusinessTransactionProvider
{

    /// <summary>
    /// Default ctor
    /// </summary>
    public TestBusinessTransactionProvider(SampleBusinessLogicLayer sampleBusinessLogicLayer)
    {
        SampleBusinessLogic = sampleBusinessLogicLayer;

        CreateBusinessTransactionDelegates.Add(1000, CreateTnr1000);

    }

    /// <summary>
    /// A dictionary containing delegates for creating business transactions.
    /// The key of the dictionary is the int tarnsaction ID
    /// </summary>
    public Dictionary<int, CreateBusinessTransactionDelegate> CreateBusinessTransactionDelegates { get; } = new();

    /// <summary>
    /// Business logic dependency
    /// </summary>
    public SampleBusinessLogicLayer SampleBusinessLogic { get; }

    /// <summary>
    /// Create business transcation 1000. Public for unit testing. Do not use directly in production
    /// </summary>
    /// <returns>Business transaction</returns>
    public BusinessTransaction CreateTnr1000()
    {
        var bt =  new BusinessTransaction
        {
            Id = 1000,
            Name = "Testtransaction",
            RunBusinessTransactionDelegate = SampleBusinessLogic.EmptyRequest
        };

        bt.AllowedRequestDataTypes.Add(nameof(EmptyBusinessTransactionRequestData));

        return bt;
    }
}