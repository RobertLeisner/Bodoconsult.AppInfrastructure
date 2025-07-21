// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Interface for checking if a certain <see cref="IClient"/> implementation has permission to receive client notifications
/// </summary>
public interface IClientNotificationLicenseManager
{
    /// <summary>
    /// Check if a certain <see cref="IClient"/> implementation has permission to receive client notifications
    /// </summary>
    /// <param name="client">Current client</param>
    /// <returns>True if the client should receive client notifications</returns>
    bool CheckClientForReceivingNotifications(IClient client);

}