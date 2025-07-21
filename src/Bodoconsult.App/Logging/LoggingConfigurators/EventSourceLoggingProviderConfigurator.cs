// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bodoconsult.App.Logging.LoggingConfigurators;

/// <summary>
/// Configures an EventSource logger
/// </summary>
public class EventSourceLoggingProviderConfigurator : ILoggerProviderConfigurator
{
    public string SectionNameAppSettingsJson => "EventSource";

    /// <summary>
    /// The configuration section from appsettings.json or null if not existing
    /// </summary>
    public IConfigurationSection Section { get; set; }

    public void AddServices(ILoggingBuilder builder, LoggingConfig loggingConfig)
    {
        builder.AddEventSourceLogger();
    }


}