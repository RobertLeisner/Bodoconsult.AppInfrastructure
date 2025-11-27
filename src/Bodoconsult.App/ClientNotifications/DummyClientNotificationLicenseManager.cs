// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.ClientNotifications;

/// <summary>
/// Dummy implementation of <see cref="IClientNotificationLicenseManager"/> for production allowing all client calls 
/// </summary>
public class DummyClientNotificationLicenseManager : IClientNotificationLicenseManager
{
    /// <summary>
    /// Check if a certain <see cref="IClient"/> implementation has permission to receive client notifications: Uses the value of <see cref="ClientShouldReceiveNotifications"/>
    /// </summary>
    /// <param name="client">Current client</param>
    /// <returns>True if the client should receive client notifications</returns>
    public bool CheckClientForReceivingNotifications(IClient client)
    {
        return true;
    }
}