// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.BusinessTransactions;
using Bodoconsult.App.BusinessTransactions.RequestData;
using Bodoconsult.App.Delegates;
using Bodoconsult.App.Interfaces;
using GrpcServerApp.BusinessLogic.Interfaces;
using GrpcServerApp.Common.EnumsAndConstants;

namespace GrpcServerApp.BusinessLogic.BusinessTransactions;

public class GrpcServerAppBusinessTransactionProvider : IBusinessTransactionProvider
{

    private readonly IDemoBl _demoBl;

    public GrpcServerAppBusinessTransactionProvider(IDemoBl demoBl)
    {
        _demoBl = demoBl;

        CreateBusinessTransactionDelegates.Add(BusinessTransactionCodes.DoSomething, Transaction1_DoSomething);
        CreateBusinessTransactionDelegates.Add(BusinessTransactionCodes.DoSomethingElse, Transaction2_DoSomethingElse);
    }

    public Dictionary<int, CreateBusinessTransactionDelegate> CreateBusinessTransactionDelegates { get; } = new();

    /// <summary>
    /// Create transaction 1: do something
    /// </summary>
    /// <returns>Business transaction</returns>
    public BusinessTransaction Transaction1_DoSomething()
    {
        var transaction = new BusinessTransaction
        {
            Id = BusinessTransactionCodes.DoSomething,
            Name = "DoSomething",
            RunBusinessTransactionDelegate = _demoBl.DoSomething
        };

        transaction.AllowedRequestDataTypes.Add(nameof(EmptyBusinessTransactionRequestData));

        return transaction;
    }

    /// <summary>
    /// Create transaction 1: do something selse
    /// </summary>
    /// <returns>Business transaction</returns>
    public BusinessTransaction Transaction2_DoSomethingElse()
    {
        var transaction = new BusinessTransaction
        {
            Id = BusinessTransactionCodes.DoSomething,
            Name = "DoSomethingElse",
            RunBusinessTransactionDelegate = _demoBl.DoSomethingElse
        };

        transaction.AllowedRequestDataTypes.Add(nameof(EmptyBusinessTransactionRequestData));

        return transaction;
    }
}