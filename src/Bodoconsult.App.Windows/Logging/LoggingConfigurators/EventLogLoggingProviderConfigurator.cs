// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Linq;
using System.Runtime.Versioning;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace Bodoconsult.App.Windows.Logging.LoggingConfigurators;

/// <summary>
/// Configures an EventLog logger for logging to Windows EventLog
/// </summary>
[SupportedOSPlatform("windows")]
public class EventLogLoggingProviderConfigurator : ILoggerProviderConfigurator
{
    public string SectionNameAppSettingsJson => "EventSource";

    /// <summary>
    /// The configuration section from appsettings.json or null if not existing
    /// </summary>
    public IConfigurationSection Section { get; set; }

    /// <summary>
    /// Settings for EventLog logging
    /// </summary>
    public EventLogSettings EventLogSettings { get; } = new();


    /// <summary>
    /// Add the DI container service used for the current logger provider
    /// </summary>
    /// <param name="builder">Current logging builder</param>
    /// <param name="loggingConfig">Current logging config</param>
    public void AddServices(ILoggingBuilder builder, LoggingConfig loggingConfig)
    {
        var oValue = Section.GetChildren().FirstOrDefault(x => x.Key == "SourceName");
        EventLogSettings.SourceName = oValue?.Value;

        oValue = Section.GetChildren().FirstOrDefault(x => x.Key == "LogName");
        EventLogSettings.LogName = oValue?.Value;

        oValue = Section.GetChildren().FirstOrDefault(x => x.Key == "MachineName");
        EventLogSettings.MachineName = oValue?.Value;

        EventLogSettings.Filter ??= (s, level) => level <= LogLevel.Error;

        builder.AddEventLog(EventLogSettings);
    }
}