// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Interfaces;

/// <summary>
/// Interface for loading <see cref="IBusinessTransactionProvider"/> instances providing business transactions in the current instance of a transaction manager <see cref="BusinessTransactionManager"/>
/// </summary>
public interface IBusinessTransactionLoader
{
    /// <summary>
    /// Current <see cref="IBusinessTransactionManager"/> impl to load the providers in
    /// </summary>
    IBusinessTransactionManager BusinessTransactionManager { get; }

    /// <summary>
    /// Load the providers
    /// </summary>
    void LoadProviders();
}