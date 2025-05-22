// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Interfaces;
using GrpcServerApp.BusinessLogic.Interfaces;

namespace GrpcServerApp.BusinessLogic.BusinessTransactions;

/// <summary>
/// Current implementation of <see cref="IBusinessTransactionLoader"/> for business transaction support
/// </summary>
public class GrpcServerAppBusinessTransactionLoader : IBusinessTransactionLoader
{
    /// <summary>
    /// Current <see cref="IBusinessTransactionManager"/> impl to load the providers in
    /// </summary>
    public IBusinessTransactionManager BusinessTransactionManager { get; }

    private readonly IDemoBl _demoBl;

    public GrpcServerAppBusinessTransactionLoader(IBusinessTransactionManager businessTransactionManager, IDemoBl demoBl)
    {
        BusinessTransactionManager = businessTransactionManager;
        _demoBl = demoBl;
    }

    /// <summary>
    /// Load the providers
    /// </summary>
    public void LoadProviders()
    {
        var provider = new GrpcServerAppBusinessTransactionProvider(_demoBl);
        BusinessTransactionManager.AddProvider(provider);
    }
}