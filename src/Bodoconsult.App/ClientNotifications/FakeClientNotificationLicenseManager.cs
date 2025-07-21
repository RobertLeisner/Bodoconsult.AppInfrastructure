// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.ClientNotifications;

/// <summary>
/// Fake implementation of <see cref="IClientNotificationLicenseManager"/> for production to replace a real implementation or unit testing for 
/// </summary>
public class FakeClientNotificationLicenseManager: IClientNotificationLicenseManager
{
    /// <summary>
    /// Sets the return value for <see cref="CheckClientForReceivingNotifications"/>. Default: true (client should recei´ve notifications)
    /// </summary>
    public bool ClientShouldReceiveNotifications { get; set; } = true;

    /// <summary>
    /// Check if a certain <see cref="IClient"/> implementation has permission to receive client notifications: Uses the value of <see cref="ClientShouldReceiveNotifications"/>
    /// </summary>
    /// <param name="client">Current client</param>
    /// <returns>True if the client should receive client notifications</returns>
    public bool CheckClientForReceivingNotifications(IClient client)
    {
        return ClientShouldReceiveNotifications;
    }
}