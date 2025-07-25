﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.DependencyInjection;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.DependencyInjection;
using Bodoconsult.App.Logging;
using Bodoconsult.App.Test.App;
using Microsoft.Extensions.Logging;

namespace Bodoconsult.App.Test.DependencyInjection;

[TestFixture]
internal class DefaultAppLoggerDiContainerProviderTests
{

    private static DefaultAppLoggerProvider CreateLoggerProvider()
    {
        var config = new LoggingConfig();
        var configPath = Globals.Instance.AppStartParameter.ConfigFile;

        var configProvider = new AppConfigurationProvider(configPath);
        configProvider.LoadConfigurationFromConfigFile();

        var loggerProvider = new DefaultAppLoggerProvider(configProvider, config);
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
        var provider = new DefaultAppLoggerDiContainerServiceProvider(loggerProvider.LoggingConfig, loggerProvider.DefaultLogger);

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
        var loggerProvider = new DebugAppLoggerProvider();
        loggerProvider.LoadDefaultLogger();

        // Act  
        var provider = new DefaultAppLoggerDiContainerServiceProvider(loggerProvider.LoggingConfig, loggerProvider.DefaultLogger);

        // Assert
        Assert.That(provider.Logger, Is.Not.Null);
        Assert.That(provider.LoggingConfig, Is.Not.Null);
    }

    [Test]
    public void AddServices_DebugSetup_ServicesAdded()
    {
        // Arrange
        var loggerProvider = new DebugAppLoggerProvider();
        loggerProvider.LoadDefaultLogger();

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

}