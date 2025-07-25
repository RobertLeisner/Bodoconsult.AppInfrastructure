﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Delegates;
using Bodoconsult.App.Abstractions.Interfaces;

namespace ConsoleWpfApp1.DiContainerProvider;

/// <summary>
/// The current DI container used for production 
/// </summary>
public class ConsoleWpfApp1ProductionDiContainerServiceProviderPackageFactory : IDiContainerServiceProviderPackageFactory
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ConsoleWpfApp1ProductionDiContainerServiceProviderPackageFactory(IAppGlobals appGlobals)
    {
        AppGlobals = appGlobals;
    }

    /// <summary>
    /// App globals
    /// </summary>
    public IAppGlobals AppGlobals { get; }

    /// <summary>
    /// Current status message delegate
    /// </summary>
    public StatusMessageDelegate StatusMessageDelegate { get; set; }

    /// <summary>
    /// Current license management delegate
    /// </summary>
    public LicenseMissingDelegate LicenseMissingDelegate { get; set; }

    /// <summary>
    /// Create an instance of <see cref="IDiContainerServiceProviderPackage"/>. Should be a singleton instance
    /// </summary>
    /// <returns>Singleton instance of <see cref="IDiContainerServiceProviderPackage"/></returns>
    public IDiContainerServiceProviderPackage CreateInstance()
    {
            
        return new ConsoleWpfApp1AllServicesDiContainerServiceProviderPackage(AppGlobals, StatusMessageDelegate, LicenseMissingDelegate);
    }
}