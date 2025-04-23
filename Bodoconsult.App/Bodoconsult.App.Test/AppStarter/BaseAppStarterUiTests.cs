// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.AppStarter;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Test.AppStarter;

[TestFixture]
internal class BaseAppStarterUiTests
{

    [Test]
    public void TestCtor()
    {
        // Arrange 
        IApplicationServiceHandler h = new FakeAppStarterServiceHandler();

        // Act  

        var b = new BaseAppStarterUi(h);

        // Assert
        Assert.That(b.AppStarterProcessHandler, Is.Not.Null);
        Assert.That(b.AppStarterProcessHandler, Is.EqualTo(h));
    }


    [Test]
    public void TestIsAnotherInstance()
    {
        // Arrange 
        var h = new FakeAppStarterServiceHandler();

        var b = new BaseAppStarterUi(h);

        // Act  
        var result = b.IsAnotherInstance;

        // Assert
        Assert.That(!result);

    }


    [Test]
    public void TestStart()
    {
        // Arrange 
        var h  = new FakeAppStarterServiceHandler();

        var b = new BaseAppStarterUi(h);

        Assert.That(!h.WasStartApplication);

        // Act  
        b.Start();

        // Assert
        Wait.Until(() => h.WasStartApplication);
        Assert.That(h.WasStartApplication);

    }
        

}