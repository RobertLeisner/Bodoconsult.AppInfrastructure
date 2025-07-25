// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Interface for a service classes which are dependent on app settings
/// and must be updated when app settings are changed
/// </summary>
public interface IServiceRequiresAppSettingsUpdate
{
    /// <summary>
    /// Update the service with changed app settings
    /// </summary>
    void UpdateService();

}