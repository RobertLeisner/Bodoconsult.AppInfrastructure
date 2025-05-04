// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.AppStarter;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Test.App;

namespace Bodoconsult.App.Test.AppStarter;

[TestFixture]
internal class BaseAppStarterUiTests
{

    [Test]
    public void TestCtor()
    {
        // Arrange 
        var h = new FakeAppBuilder(Globals.Instance);

        // Act  
        var b = new BaseAppStarterUi(h);

        // Assert
        Assert.That(b.AppBuilder, Is.Not.Null);
        Assert.That(b.AppBuilder, Is.EqualTo(h));
    }


    [Test]
    public void TestIsAnotherInstance()
    {
        // Arrange 
        var h = new FakeAppBuilder(Globals.Instance);

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
        var h = new FakeAppBuilder(Globals.Instance);

        Assert.That(!h.WasStartApplication);
        var b = new BaseAppStarterUi(h);

        // Act  
        b.Start();

        // Assert
        Wait.Until(() => h.WasStartApplication);
        Assert.That(h.WasStartApplication);

    }
        

}