// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.Toast;

/// <summary>
/// Dummy implementation for <see cref="IToastMessagingService"/> doing nothing
/// </summary>
public class DummyToastMessagingService : IToastMessagingService
{
    /// <summary>
    /// Send a simple toast notification to the operating system
    /// </summary>
    /// <param name="notificationRequest">Notification request</param>
    public void SendSimpleToastMessage(NotifyRequestRecord notificationRequest)
    {
        // Do nothing
    }
}