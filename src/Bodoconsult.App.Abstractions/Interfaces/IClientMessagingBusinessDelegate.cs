// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Interface for client messaging business delegates
/// </summary>
public interface IClientMessagingBusinessDelegate
{

    /// <summary>
    /// Current client messaging service
    /// </summary>
    IClientMessagingService ClientMessagingService { get; }

    /// <summary>
    /// Current client manager to use
    /// </summary>
    IClientManager ClientManager { get; }

    /// <summary>
    /// Event method to bind to current buisness logic class instance for messaging. Calls <see cref="DoNotifyClient"/>. Use this method to decouple messaging business logic from <see cref="IClientMessagingBusinessDelegate"/> impls.
    /// </summary>
    /// <param name="sender">Source (not used)</param>
    /// <param name="notification">Current notification to send to the clients</param>
    void MessagingBusinessManagerOnNotifyClient(object sender, IClientNotification notification);

    /// <summary>
    /// Notify  a client
    /// </summary>
    /// <param name="notification">Notification to send to the client</param>
    void DoNotifyClient(IClientNotification notification);

    /// <summary>
    /// Any notifications in the queue?
    /// </summary>
    bool HasNotifications { get; }

    /// <summary>
    /// Send the queued messages to the client. To be called internally by <see cref="IWatchDog"/> implementation. Public only for testing purposes
    /// </summary>
    void Runner();

    /// <summary>
    /// Start messaging to the client
    /// </summary>
    void StartClientMessaging();

    /// <summary>
    /// Stop messaging to the client
    /// </summary>
    void StopClientMessaging();

}