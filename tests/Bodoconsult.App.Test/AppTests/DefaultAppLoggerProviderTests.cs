// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Logging;
using Bodoconsult.App.Test.App;

namespace Bodoconsult.App.Test.AppTests;

[TestFixture]
internal class DefaultAppLoggerProviderTests
{
    static readonly LoggingConfig Config = new();
    private readonly string _configPath = Globals.Instance.AppStartParameter.ConfigFile;

    [Test]
    public void Ctor_DefaultSetup_PropsSetCorrectly()
    {
        // Arrange 
        var configProvider = new AppConfigurationProvider(_configPath);
        configProvider.LoadConfigurationFromConfigFile();

        // Act  
        var provider = new DefaultAppLoggerProvider(configProvider, Config);

        // Assert
        Assert.That(provider.AppConfigurationProvider, Is.Not.Null);
        Assert.That(provider.AppConfigurationProvider, Is.EqualTo(configProvider));
        Assert.That(provider.DefaultLogger, Is.Null);

    }

    [Test]
    public void LoadLoggingConfigFromConfiguration_DefaultSetup_LoggingConfigNotNull()
    {
        // Arrange 
        var configProvider = new AppConfigurationProvider(_configPath);
        configProvider.LoadConfigurationFromConfigFile();

        var provider = new DefaultAppLoggerProvider(configProvider, Config);

        // Act  
        provider.LoadLoggingConfigFromConfiguration();

        // Assert
        Assert.That(provider.LoggingConfig, Is.Not.Null);
        Assert.That(provider.DefaultLogger, Is.Null);

    }

    [Test]
    public void LoadDefaultLogger_DefaultSetup_LoggingConfigNotNull()
    {
        // Arrange 
        var configProvider = new AppConfigurationProvider(_configPath);
        configProvider.LoadConfigurationFromConfigFile();

        var provider = new DefaultAppLoggerProvider(configProvider, Config);

        provider.LoadLoggingConfigFromConfiguration();

        // Act  
        provider.LoadDefaultLogger();

        // Assert
        Assert.That(provider.LoggingConfig, Is.Not.Null);
        Assert.That(provider.DefaultLogger, Is.Not.Null);

    }

}