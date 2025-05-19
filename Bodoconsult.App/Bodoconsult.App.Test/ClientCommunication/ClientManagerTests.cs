// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.ClientNotifications;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Test.ClientCommunication.FakeImpls;
using Bodoconsult.App.Test.Helpers;

namespace Bodoconsult.App.Test.ClientCommunication;

[TestFixture]
internal class ClientManagerTests
{

    private readonly IAppLoggerProxy _logger = TestHelper.GetFakeAppLoggerProxy();

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

    [Test]
    public void TestAddClientWebserviceWithLicense()
    {
        // Arrange 
        var licManager = TestHelper.GetFakeLicenceManager();
        var clientMessagingService = new FakeClientMessagingService();
        var cm = new ClientManager(licManager, _logger, clientMessagingService);

        Assert.That(cm.AllConnectedClients, Is.Not.Null);
        Assert.That(cm.AllConnectedClients.Count, Is.EqualTo(0));

        var client = new FakeClient
        {
            ClientData = new FakeLoginData{Type = (int)MyClientTypeEnum.Webservice}
        };

        // Act  
        cm.AddClient(client);

        // Assert
        Assert.That(cm.AllConnectedClients.Count, Is.EqualTo(1));

    }

    [Test]
    public void TestAddClientDisplay()
    {
        // Arrange 
        var licManager = TestHelper.GetFakeLicenceManager();
        var clientMessagingService = new FakeClientMessagingService();
        var cm = new ClientManager(licManager, _logger, clientMessagingService);

        Assert.That(cm.AllConnectedClients, Is.Not.Null);
        Assert.That(cm.AllConnectedClients.Count, Is.EqualTo(0));

        var client = new FakeClient
        {
            ClientData = new FakeLoginData { Type = (int)MyClientTypeEnum.Display }
        };

        // Act  
        cm.AddClient(client);

        // Assert
        Assert.That(cm.AllConnectedClients.Count, Is.EqualTo(1));

    }


    [Test]
    public void TestRemoveClient()
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

        cm.AddClient(client);
        Assert.That(cm.AllConnectedClients.Count, Is.EqualTo(1));

        // Act  
        cm.RemoveClient(client);

        // Assert
        Assert.That(cm.AllConnectedClients.Count, Is.EqualTo(0));

    }


    [Test]
    public void TestDoNotifyAllClients()
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

        cm.AddClient(client);
        Assert.That(cm.AllConnectedClients.Count, Is.EqualTo(1));

        var notification = new TestNotification();

        // Act  
            
        cm.DoNotifyAllClients(notification);

        // Assert
        Assert.That(client.WasFired);

    }
        
}