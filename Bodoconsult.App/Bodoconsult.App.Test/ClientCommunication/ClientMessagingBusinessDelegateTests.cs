// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.ClientNotifications;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Test.ClientCommunication.FakeImpls;
using Bodoconsult.App.Test.Helpers;

namespace Bodoconsult.App.Test.ClientCommunication;

[TestFixture]
public class ClientMessagingBusinessDelegateTests
{

    private readonly IAppLoggerProxy _logger = TestHelper.GetFakeAppLoggerProxy();

    [Test]
    public void TestCtor()
    {
        // Arrange 
        IClientMessagingService cms = new FakeClientMessagingService();

        var client = new FakeClient
        {
            ClientData = new FakeLoginData()
        };

        var licManager = TestHelper.GetFakeLicenceManager();
        var clientManager = new ClientManager(licManager, _logger);
        clientManager.AddClient(client);

        // Act  
        var cmdb = new ClientMessagingBusinessDelegate(cms, clientManager);

        // Assert
        Assert.That(cmdb.ClientMessagingService, Is.Not.Null);
        Assert.That(clientManager, Is.Not.Null);
    }
        


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
        var clientManager = new ClientManager(licManager, _logger);
        clientManager.AddClient(client);

        var cmdb = new ClientMessagingBusinessDelegate(cms, clientManager);

        var notification = new TestNotification();


        // Act  
        cmdb.DoNotifyClient(notification);

        // Assert
        Assert.That(cmdb.HasNotifications, Is.True);

    }

    [Test]
    public void TestRunnerDoNotifyClient()
    {
        // Arrange 
        IClientMessagingService cms = new FakeClientMessagingService();

        var client = new FakeClient
        {
            ClientData = new FakeLoginData()
        };

        var licManager = TestHelper.GetFakeLicenceManager();
        var clientManager = new ClientManager(licManager, _logger);
        clientManager.AddClient(client);

        var cmdb = new ClientMessagingBusinessDelegate(cms, clientManager);

        var notfication = new TestNotification();

        cmdb.DoNotifyClient(notfication);
        Assert.That(cmdb.HasNotifications, Is.True);

        // Act  
        cmdb.Runner();

        // Assert
        Assert.That(client.WasFired, Is.True);

    }

    [Test]
    public void TestRunnerMessagingBusinessManagerOnNotifyClient()
    {
        // Arrange 
        IClientMessagingService cms = new FakeClientMessagingService();

        var client = new FakeClient
        {
            ClientData = new FakeLoginData()
        };

        var licManager = TestHelper.GetFakeLicenceManager();
        var clientManager = new ClientManager(licManager, _logger);
        clientManager.AddClient(client);

        var cmdb = new ClientMessagingBusinessDelegate(cms, clientManager);

        var notfication = new TestNotification();

        cmdb.MessagingBusinessManagerOnNotifyClient(this, notfication);
        Assert.That(cmdb.HasNotifications, Is.True);

        // Act  
        cmdb.Runner();

        // Assert
        Assert.That( client.WasFired, Is.True);

    }


}