// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.GrpcBackgroundService;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;
using Grpc.Core;
using GrpcServerApp.BusinessLogic.Notifications;

namespace GrpcServerApp.Grpc.ProtobufServices;

public class GrpcClient : IClient, IDisposable
{
    private IServerStreamWriter<ClientNotificationMessage> _responseStream;
    private readonly ProducerConsumerQueue<IClientNotification> _consumerQueue = new();

    public GrpcClient(IClientLoginData loginData, CancellationToken contextCancellationToken)
    {
        ClientData = loginData;
        ContextCancellationToken = contextCancellationToken;

        _consumerQueue.ConsumerTaskDelegate = ConsumerTaskDelegate;
        _consumerQueue.StartConsumer();

        AllowedNotifications.Add(nameof(SimpleClientNotification));

    }

    private void ConsumerTaskDelegate(IClientNotification notification)
    {
        if (ContextCancellationToken.IsCancellationRequested)
        {
            return;
        }

        var dto = notification.NotificationObjectToSend;

        if (dto is ClientNotificationMessage message)
        {
            Debug.Print($"Server: send {notification.GetType().Name} to client");
            _responseStream.WriteAsync(message).GetAwaiter().GetResult();
        }
        else
        {
            Debug.Print($"Server: wrong message type");
        }
    }

    /// <summary>
    /// Current context cancellation token
    /// </summary>
    public CancellationToken ContextCancellationToken { get; }

    public void LoadStream(IServerStreamWriter<ClientNotificationMessage> responseStream)
    {
        _responseStream = responseStream;
    }

    /// <summary>
    /// Current client manager instance
    /// </summary>
    public IClientManager ClientManager { get; private set; }


    /// <summary>
    /// information about connected client
    /// </summary>
    public IClientLoginData ClientData { get; }


    /// <summary>
    /// Connection state
    /// </summary>
    public bool IsConnected { get; set; }

    /// <summary>
    /// All allowed notifications
    /// </summary>
    public IList<string> AllowedNotifications { get; } = new List<string>();


    /// <summary>
    /// Wait until connection result is set
    /// </summary>
    /// <returns>true if connected</returns>
    public Task<bool> WaitForConnectionResult()
    {
        return Task.FromResult(true);
    }

    public void StartConnection()
    {
        // Do nothing
        IsConnected = true;
    }

    /// <summary>
    /// Check if the notification is allowed to be sent to the client
    /// </summary>
    /// <param name="notification">Notification to check</param>
    /// <returns>True if the notification should be sent to the client else false</returns>
    public bool CheckNotification(IClientNotification notification)
    {
        // Do nothing
        return true;
    }

    /// <summary>
    /// Do notify the client
    /// </summary>
    /// <param name="notification">Current notification to send to the client instance</param>
    public void DoNotifyClient(IClientNotification notification)
    {
        Debug.Print($"Server: enqueue {notification.GetType().Name} to client");
        _consumerQueue.Enqueue(notification);
    }

    /// <summary>
    /// Load the current client manager instance
    /// </summary>
    /// <param name="clientManager">Current client manager instance</param>
    public void LoadClientManager(IClientManager clientManager)
    {
        ClientManager = clientManager;
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        _consumerQueue.StopConsumer();
        _consumerQueue?.Dispose();
    }
}