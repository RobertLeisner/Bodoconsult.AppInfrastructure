// Copyright (c) Royotech. All rights reserved.

using System.Collections.Concurrent;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.ClientNotifications;

/// <summary>
/// Current implementation of <see cref="IClientManager"/>
/// </summary>
public class ClientManager : IClientManager
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="licenseManager">Current license manager</param>
    /// <param name="appLogger">Current app logger</param>
    public ClientManager(IClientNotificationLicenseManager licenseManager, IAppLoggerProxy appLogger)
    {
        LicenseManager = licenseManager;
        AppLogger = appLogger;
    }

    /// <summary>
    /// Current license manager
    /// </summary>
    public IClientNotificationLicenseManager LicenseManager { get; }

    /// <summary>
    /// Current logger
    /// </summary>
    public IAppLoggerProxy AppLogger { get; }

    /// <summary>
    /// Currently connected clients
    /// </summary>
    public ConcurrentDictionary<Guid, IClient> AllConnectedClients { get; } = new();


    /// <summary>
    /// Add a connected client to the conencted clients
    /// </summary>
    /// <param name="client">Current client to add to the conencted clients</param>
    public void AddClient(IClient client)
    {

        if (!LicenseManager.CheckClientForReceivingNotifications(client))
        {
            return;
        }

        client.LoadClientManager(this);
        AllConnectedClients.GetOrAdd(client.ClientData.Id, client);
        AppLogger.LogInformation($"Client added {client.ClientData.Type} {client.ClientData.Id} Count: {AllConnectedClients.Count}");

    }

    /// <summary>
    /// Remove a client from the conencted clients list
    /// </summary>
    /// <param name="client">Current client to remove</param>
    public void RemoveClient(IClient client)
    {
        AllConnectedClients.TryRemove(client.ClientData.Id, out client);
        AppLogger.LogInformation($"Client removed {client?.ClientData.Type} {client?.ClientData.Id} Count: {AllConnectedClients.Count}");
    }

    /// <summary>
    /// Send a notification to all clients
    /// </summary>
    /// <param name="notification">Notification to send to the clients</param>
    public void DoNotifyAllClients(IClientNotification notification)
    {
        foreach (var connectedClient in AllConnectedClients.Values)
        {
            if (!connectedClient.CheckNotification(notification))
            {
                continue;
            }
            connectedClient.DoNotifyClient(notification);
        }
    }
}