// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.DependencyInjection;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Logging;
using Microsoft.Extensions.Logging;

namespace Bodoconsult.App.Test.AppTests;

[TestFixture]
internal class DefaultAppLoggerDiContainerProviderTests
{

    static readonly LoggingConfig Config = new();

    private static DefaultAppLoggerProvider CreateLoggerProvider()
    {

        var configProvider = new AppConfigurationProvider();

        configProvider.LoadConfigurationFromConfigFile();



        var loggerProvider = new DefaultAppLoggerProvider(configProvider, Config);

        loggerProvider.LoadLoggingConfigFromConfiguration();

        loggerProvider.LoadDefaultLogger();

        return loggerProvider;

    }

    [Test]
    public void Ctor_DefaultSetup_PropsSetCorrectly()
    {

        // Arrange
        var loggerProvider = CreateLoggerProvider();

        // Act 
        var provider =
            new DefaultAppLoggerDiContainerServiceProvider(loggerProvider.LoggingConfig,
                loggerProvider.DefaultLogger);

        // Assert
        Assert.That(provider.Logger, Is.Not.Null);
        Assert.That(provider.LoggingConfig, Is.Not.Null);

    }



    [Test]

    public void AddServices_DefaultSetup_ServicesAdded()

    {

        // Arrange
        var loggerProvider = CreateLoggerProvider();
        var provider = new DefaultAppLoggerDiContainerServiceProvider(loggerProvider.LoggingConfig, loggerProvider.DefaultLogger);
        var container = new DiContainer();
        Assert.That(container.ServiceCollection.Count, Is.EqualTo(0));

        // Act 
        provider.AddServices(container);
        container.BuildServiceProvider();

        // Assert
        Assert.That(container.ServiceCollection.Count, Is.Not.EqualTo(0));

        var loggerFactory = container.Get<ILoggerFactory>();
        Assert.That(loggerFactory, Is.Not.Null);

        var logger = container.Get<IAppLoggerProxy>();
        Assert.That(logger, Is.Not.Null);

        // Changed the logger factory
        logger.UpdateILoggerFactory(loggerFactory);

        Assert.That(logger.LoggerFactory, Is.EqualTo(loggerFactory));
    }

    [Test]
    public void Ctor_DebugSetup_PropsSetCorrectly()
    {

        // Arrange
        IAppConfigurationProvider appConfigurationProvider = new AppConfigurationProvider();
        var loggerProvider = new DefaultAppLoggerProvider(appConfigurationProvider, Config);
        loggerProvider.LoadDefaultLogger();

        // Act 
        var provider = new DefaultAppLoggerDiContainerServiceProvider(loggerProvider.LoggingConfig, loggerProvider.DefaultLogger);

        // Assert
        Assert.That(provider.Logger, Is.Not.Null);
        Assert.That(provider.LoggingConfig, Is.Not.Null);

    }

}