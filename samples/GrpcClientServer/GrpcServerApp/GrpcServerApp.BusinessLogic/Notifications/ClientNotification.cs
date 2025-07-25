// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace GrpcServerApp.BusinessLogic.Notifications;

/// <summary>
/// Simple client notification
/// </summary>
public class SimpleClientNotification: IClientNotification
{
    /// <summary>
    /// Simple client notification
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// A data object to send via GRPC etc to the client
    /// </summary>
    public object NotificationObjectToSend { get; set; }
}