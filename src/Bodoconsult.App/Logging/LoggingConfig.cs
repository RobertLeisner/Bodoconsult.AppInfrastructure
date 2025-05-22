﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Bodoconsult.App.Logging;

/// <summary>
/// Stores logging configuration
/// </summary>

public class LoggingConfig
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public LoggingConfig()
    {
        Filters = new Dictionary<string, LogLevel>();
        MinimumLogLevel = LogLevel.Information;
        ConsoleConfigurationSettings = new SimpleConsoleFormatterOptions();
    }

    /// <summary>
    /// Minimum log level to set
    /// </summary>
    public LogLevel MinimumLogLevel { get; set; }


    /// <summary>
    /// Output filters set for logging
    /// </summary>
    public Dictionary<string, LogLevel> Filters { get; }

    /// <summary>
    /// Logging configurators to use
    /// </summary>
    public List<ILoggerProviderConfigurator> LoggerProviderConfigurators { get; } = new();


    /// <summary>
    /// Console config configuration
    /// </summary>
    public SimpleConsoleFormatterOptions ConsoleConfigurationSettings { get; }

    /// <summary>
    /// Current log data entry factory
    /// </summary>
    public ILogDataFactory LogDataFactory { get; set; }
}