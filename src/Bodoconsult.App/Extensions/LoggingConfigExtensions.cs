// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Logging;
using Bodoconsult.App.Logging.LoggingConfigurators;

namespace Bodoconsult.App.Extensions;


/// <summary>
/// Extension methods for <see cref="IAppBuilder"/> instances
/// </summary>
public static class LoggingConfigExtensions
{

    /// <summary>
    /// Load the default <see cref="ILoggerProviderConfigurator"/> instances used for console apps including ConsoleLoggingProviderConfigurator, DebugLoggingProviderConfigurator and Log4NetLoggingProviderConfigurator
    /// </summary>
    /// <param name="loggingConfig">Current <see cref="IAppBuilder"/> instance</param>
    public static void AddDefaultLoggerProviderConfiguratorsForConsoleApp(this LoggingConfig loggingConfig)
    {
        loggingConfig.LoggerProviderConfigurators.Add(new ConsoleLoggingProviderConfigurator());
        if (Debugger.IsAttached)
        {
            loggingConfig.LoggerProviderConfigurators.Add(new DebugLoggingProviderConfigurator());
        }
        loggingConfig.LoggerProviderConfigurators.Add(new Log4NetLoggingProviderConfigurator());
    }

    /// <summary>
    /// Load the default <see cref="ILoggerProviderConfigurator"/> instances used for UI based apps including EventSourceLoggingProviderConfigurator, DebugLoggingProviderConfigurator and Log4NetLoggingProviderConfigurator
    /// </summary>
    /// <param name="loggingConfig">Current <see cref="IAppBuilder"/> instance</param>

    public static void AddDefaultLoggerProviderConfiguratorsForUiApp(this LoggingConfig loggingConfig)
    {
        if (Debugger.IsAttached)
        {
            loggingConfig.LoggerProviderConfigurators.Add(new DebugLoggingProviderConfigurator());
        }
        loggingConfig.LoggerProviderConfigurators.Add(new Log4NetLoggingProviderConfigurator());
        loggingConfig.LoggerProviderConfigurators.Add(new EventSourceLoggingProviderConfigurator());
    }

    /// <summary>
    /// Load the default <see cref="ILoggerProviderConfigurator"/> instances used for background service apps including DebugLoggingProviderConfigurator and Log4NetLoggingProviderConfigurator
    /// </summary>
    /// <param name="loggingConfig">Current <see cref="IAppBuilder"/> instance</param>

    public static void AddDefaultLoggerProviderConfiguratorsForBackgroundServiceApp(this LoggingConfig loggingConfig)
    {
        if (Debugger.IsAttached)
        {
            loggingConfig.LoggerProviderConfigurators.Add(new DebugLoggingProviderConfigurator());
        }
        loggingConfig.LoggerProviderConfigurators.Add(new Log4NetLoggingProviderConfigurator());
    }

    /// <summary>
    /// Load the default <see cref="ILoggerProviderConfigurator"/> instances used for debugging in test projects including DebugLoggingProviderConfigurator and Log4NetLoggingProviderConfigurator
    /// </summary>
    /// <param name="loggingConfig">Current <see cref="IAppBuilder"/> instance</param>
    public static void AddDefaultLoggerProviderConfiguratorsForDebugging(this LoggingConfig loggingConfig)
    {
        if (Debugger.IsAttached)
        {
            loggingConfig.LoggerProviderConfigurators.Add(new DebugLoggingProviderConfigurator());
        }
        loggingConfig.LoggerProviderConfigurators.Add(new Log4NetLoggingProviderConfigurator());
    }

}