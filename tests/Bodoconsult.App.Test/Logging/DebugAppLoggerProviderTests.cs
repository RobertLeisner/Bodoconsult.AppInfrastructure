// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Logging;

namespace Bodoconsult.App.Test.Logging;

[TestFixture]
internal class DebugAppLoggerProviderTests
{

    [Test]
    public void Ctor_DefaultSetup_PropsSetCorrectly()
    {
        // Arrange 
            
        // Act  
        var provider = new DebugAppLoggerProvider();
            
        // Assert
        Assert.That(provider.AppConfigurationProvider, Is.Null);
        Assert.That(provider.DefaultLogger, Is.Null);

    }

    [Test]
    public void LoadLoggingConfigFromConfiguration_DefaultSetup_LoggingConfigNotNull()
    {
        // Arrange 
        var provider = new DebugAppLoggerProvider();
            
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
        var provider = new DebugAppLoggerProvider();

        provider.LoadLoggingConfigFromConfiguration();
            
        // Act  
        provider.LoadDefaultLogger();
            
        // Assert
        Assert.That(provider.LoggingConfig, Is.Not.Null);
        Assert.That(provider.DefaultLogger, Is.Not.Null);
    }

}