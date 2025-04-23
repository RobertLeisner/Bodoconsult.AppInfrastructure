// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.BusinessTransactions;
using Bodoconsult.App.Delegates;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Test.SampleBusinessLogic;

namespace Bodoconsult.App.Test.TestData;

internal class TestTransactionProvider: IBusinessTransactionProvider
{
    /// <summary>
    /// A dictionary containing delegates for creating business transactions.
    /// The key of the dictionary is the int tarnsaction ID
    /// </summary>
    public Dictionary<int, CreateBusinessTransactionDelegate> CreateBusinessTransactionDelegates { get; } = new();

    public SampleBusinessLogicLayer SampleBusinessLogic { get; } 


    public TestTransactionProvider()
    {
        SampleBusinessLogic = new SampleBusinessLogicLayer();

        CreateBusinessTransactionDelegates.Add(1000, CreateTnr1000);


    }

    private BusinessTransaction CreateTnr1000()
    {
        return new BusinessTransaction
        {
            Id = 1000,
            Name = "Testtransaction",
            RunBusinessTransactionDelegate = SampleBusinessLogic.EmptyRequest
        };
    }
}