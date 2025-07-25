// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Test.App;

namespace Bodoconsult.App.Test.AppTests;

[TestFixture]
internal class DefaultAppStartProviderTests
{

    [Test]

    public void Ctor_DefaultSetup_AllPropsAreNull()
    {

        // Arrange
        var globals = Globals.Instance;

        // Act 
        var provider = new DefaultAppStartProvider(globals);

        // Assert
        Assert.That(provider.AppConfigurationProvider, Is.Null);
        Assert.That(provider.AppGlobals.AppStartParameter, Is.Not.Null);
        Assert.That(provider.DefaultAppLoggerProvider, Is.Null);

    }

    [Test]
    public void LoadConfigurationProvider_DefaultSetup_AppConfigIsLoaded()
    {

        // Arrange
        var globals = Globals.Instance;
        var provider = new DefaultAppStartProvider(globals);

        // Act 
        provider.LoadConfigurationProvider();

        // Assert
        Assert.That(provider.AppConfigurationProvider, Is.Not.Null);
    }



    [Test]
    public void LoadAppStartParameter_DefaultSetup_AppStartParameterIsLoaded()
    {

        // Arrange
        var globals = Globals.Instance;
        var provider = new DefaultAppStartProvider(globals);
        provider.LoadConfigurationProvider();

        // Act 
        provider.LoadAppStartParameter();

        // Assert
        Assert.That(provider.AppGlobals.AppStartParameter, Is.Not.Null);
    }

    [Test]
    public void LoadDefaultAppLoggerProvider_DefaultSetup_DefaultAppLoggerProviderIsLoaded()
    {

        // Arrange
        var globals = Globals.Instance;
        var provider = new DefaultAppStartProvider(globals);
        provider.LoadConfigurationProvider();
        provider.LoadAppStartParameter();

        // Act 
        provider.LoadDefaultAppLoggerProvider();

        // Assert
        Assert.That(provider.DefaultAppLoggerProvider, Is.Not.Null);
    }

}