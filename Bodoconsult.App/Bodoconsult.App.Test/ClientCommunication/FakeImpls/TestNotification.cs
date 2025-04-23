// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Test.ClientCommunication.FakeImpls;

/// <summary>
/// Test notification
/// </summary>
public class TestNotification : IClientNotification
{
    /// <summary>
    /// Any message to transfer to the client
    /// </summary>
    public string Message { get; set; }

    public object NotificationObjectToSend { get; set; }
}