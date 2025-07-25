// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.Abstractions.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bodoconsult.App.Logging.LoggingConfigurators;

/// <summary>
/// Configures a DEBUG window logger
/// </summary>
public class DebugLoggingProviderConfigurator: ILoggerProviderConfigurator
{
    public string SectionNameAppSettingsJson => "Debug";

    /// <summary>
    /// The configuration section from appsettings.json or null if not existing
    /// </summary>
    public IConfigurationSection Section { get; set; }

    public void AddServices(ILoggingBuilder builder, LoggingConfig loggingConfig)
    {
#if DEBUG
            // Debug
            if (Debugger.IsAttached)
            {
                builder.AddDebug();
            }
#endif
    }
}