// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.Abstractions.DependencyInjection;

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Interface for a pckaing loading classes adding DI container services to a DI container in the order required for the current app
/// </summary>
public interface IDiContainerServiceProviderPackage
{
    /// <summary>
    /// Current app globals
    /// </summary>
    IAppGlobals AppGlobals { get; }

    /// <summary>
    /// Do not build the DI container
    /// </summary>
    bool DoNotBuildDiContainer { get; }

    /// <summary>
    /// Current list of services providers
    /// </summary>
    IList<IDiContainerServiceProvider> ServiceProviders { get; } 

    /// <summary>
    /// Add DI container services to a DI container
    /// </summary>
    /// <param name="diContainer">Current DI container</param>
    void AddServices(DiContainer diContainer);

    /// <summary>
    /// Late bind DI container references to avoid circular DI references
    /// </summary>
    /// <param name="diContainer"></param>
    void LateBindObjects(DiContainer diContainer);

}