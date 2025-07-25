// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.DependencyInjection;

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Interface for classes adding DI container services to a DI container
/// </summary>
public interface IDiContainerServiceProvider
{
    /// <summary>
    /// Add DI container services to a DI container
    /// </summary>
    /// <param name="diContainer">Current DI container</param>
    void AddServices(DiContainer diContainer);

    /// <summary>
    /// Late bind DI container references to avoid circular DI references
    /// </summary>
    /// <param name="diContainer">Current DI container</param>
    void LateBindObjects(DiContainer diContainer);

}