# Client notifications

In a client server environment the server (or the client) may send notifications to the client (or server). The notifications are transported via GRPC, REST or any other transport layer technology. 

The client notifications system implemented in Bodoconsult.App is working one way. A client intended to receive notifications from the server has to login at the server. The login is handled by the IClientManager instance (normally a ClientManager instance). The IClientManager instance handles all clients and is responsible to forward the notifications created by the server to the clients logged in and intended to receive the notification.

If you need bidirectional notifications you can implement the client notifications system on both sides the server and the client.

## Implement your notifcations based on IClientNotification as required

Here a simple sample notification:

``` csharp
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
```

## Implement an IClientNotificationLicenseManager instance

Purpose of the IClientNotificationLicenseManager instance is to check if a certain type of client has permission to access client notifications.

Implement your own IClientNotificationLicenseManager implementation or use DummyClientNotificationLicenseManager if no license check is required.

## Implement an IClientMessagingService instance

The ClientMessagingService instance is intended to convert the internal notification object to the data transfer object used to sent the notification content via the transportation layer to the client.

``` csharp
/// <summary>
/// Sample implementation of <see cref="IClientMessagingService"/>
/// </summary>
public class FakeClientMessagingService : IClientMessagingService
{

    /// <summary>
    /// Default ctor: should load all required conversion rules
    /// </summary>
    public FakeClientMessagingService()
    {
        ConversionRules.Add(nameof(TestNotification), ConvertToTestTransportLayerObject);
    }

    /// <summary>
    /// Converts a <see cref="TestNotification"/> to a <see cref="TestTransportLayerObject"/>
    /// </summary>
    /// <param name="notification">Notifications</param>
    /// <returns>A <see cref="TestTransportLayerObject"/> instance</returns>
    /// <remarks>Method should be public for unit testing</remarks>
    /// <exception cref="ArgumentException">Throws if the type of notification is not <see cref="TestNotification"/></exception>
    public object ConvertToTestTransportLayerObject(IClientNotification notification)
    {
        if (notification is not TestNotification testNotification)
        {
            throw new ArgumentException("Wrong type of exeception. TestNotification is expected.");
        }

        return new TestTransportLayerObject
        {
            Message = testNotification.Message
        };
    }

    /// <summary>
    /// All conversion rules for notifications event args to client transport level target object
    /// </summary>
    public Dictionary<string, NotificationToTargetTransferObjectDelegate> ConversionRules { get; } = new();


    /// <summary>
    /// Convert a notification into a client transport level target object
    /// </summary>
    /// <param name="notification">Current notification to send</param>
    /// <returns>Object to transfer to the client on transport level</returns>
    public object Convert(IClientNotification notification)
    {
        var typeName = notification.GetType().Name;

        var success = ConversionRules.TryGetValue(typeName, out var result);

        if (!success)
        {
            throw new ArgumentException($"Type not found: {typeName}");
        }

        return result(notification);
    }
}
```

## Setup an ClientManager instance

You can use ClientManager as default implementation of IClientManager or implement your own IClientManager implementation.

``` csharp
[Test]
public void TestCtor()
{
    // Arrange 
    var licManager = TestHelper.GetFakeLicenceManager();
    var clientMessagingService = new FakeClientMessagingService();

    // Act  
    var cm = new ClientManager(licManager, _logger, clientMessagingService);

    // Assert
    Assert.That(cm.AllConnectedClients, Is.Not.Null);
    Assert.That(cm.AllConnectedClients.Count, Is.EqualTo(0));

}
```

## Login as client

Now a client has to login to the IClientManager instance. Your client implementation must contain a transport layer connection to the client for sending the notification via this connection.

Client implementations can allow no, all or only certain notfications to be sent to the client represented by this implementations. Add all (or none) names of the internal notification implementations to the IClient.AllowedNotifications property.

``` csharp
[Test]
public void TestAddClientFull()
{
    // Arrange 
    var licManager = TestHelper.GetFakeLicenceManager();
    var clientMessagingService = new FakeClientMessagingService();
    var cm = new ClientManager(licManager, _logger, clientMessagingService);

    Assert.That(cm.AllConnectedClients, Is.Not.Null);
    Assert.That(cm.AllConnectedClients.Count, Is.EqualTo(0));

    var client = new FakeClient
    {
        ClientData = new FakeLoginData { Type = (int)MyClientTypeEnum.Full }
    };

    // Act  
    cm.AddClient(client);

    // Assert
    Assert.That(cm.AllConnectedClients.Count, Is.EqualTo(1));
}
```

Remark: IClientManager.AddClient does not check if the client is allowed to login. You have to implement your own authentification if needed before calling IClientManager.AddClient.

## Send a notification to the connected client(s)

Setup your ClientMessagingBusinessDelegate instance and use its DoNotifyClient() method to send a notification to the client.

``` csharp
[Test]
public void TestDoNotifyClient()
{
    // Arrange 
    IClientMessagingService cms = new FakeClientMessagingService();

    var client = new FakeClient
    {
        ClientData = new FakeLoginData()
    };

    var licManager = TestHelper.GetFakeLicenceManager();
    var clientMessagingService = new FakeClientMessagingService();
    var clientManager = new ClientManager(licManager, _logger, clientMessagingService);
    clientManager.AddClient(client);

    var cmdb = new ClientMessagingBusinessDelegate(cms, clientManager);

    var notification = new TestNotification();

    // Act  
    cmdb.DoNotifyClient(notification);

    // Assert
    Assert.That(cmdb.HasNotifications, Is.True);
}
```

``` csharp

```