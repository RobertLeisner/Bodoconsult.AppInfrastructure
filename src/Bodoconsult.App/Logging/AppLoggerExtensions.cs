// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bodoconsult.App.Logging;

/// <summary>
/// Helper functionality for easy usage of logging
/// </summary>
public static class AppLoggerExtensions
{

    /// <summary>
    /// Add a default logger
    /// </summary>
    /// <param name="serviceCollection">Current service collection</param>
    /// <param name="loggingConfig">Current logger configuration</param>

    public static void AddDefaultLogger(this IServiceCollection serviceCollection, LoggingConfig loggingConfig)
    {
        serviceCollection.AddLogging(builder =>
            {

                // Clear all default providers
                builder.ClearProviders();


                // Add minimum log level from config
                builder.SetMinimumLevel(loggingConfig.MinimumLogLevel);


                // Add filters from config
                foreach (var filter in loggingConfig.Filters)
                {
                    var key = filter.Key.ToUpperInvariant() == "DEFAULT" ? null : filter.Key;
                    builder.AddFilter(key, filter.Value);
                }

                // Add the providers found activated in appsettings.json
                foreach (var c in loggingConfig.LoggerProviderConfigurators.Where(x => x.Section != null))
                {
                    c.AddServices(builder, loggingConfig);
                }
            }
        );
    }

    /// <summary>
    /// Create the configured default logger factory
    /// </summary>
    /// <param name="loggingConfig">Current logging configuration</param>
    /// <returns>Configured default logger</returns>
    public static ILoggerFactory GetDefaultLogger(LoggingConfig loggingConfig)
    {

        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddDefaultLogger(loggingConfig);

        var logFactory = serviceCollection.BuildServiceProvider()
            .GetService<ILoggerFactory>();

        return logFactory;
    }

    /// <summary>
    /// Get a fake app logger proxy
    /// </summary>
    /// <returns></returns>
    public static IAppLoggerProxy GetFakeAppLoggerProxy()
    {
        return new AppLoggerProxy(new FakeLoggerFactory(), new LogDataFactory());
    }


    /// <summary>
    /// Get a default app logger proxy
    /// </summary>
    /// <returns></returns>
    public static IAppLoggerProxy GetDefaultAppLoggerProxy(LoggingConfig loggingConfig)
    {
        return new AppLoggerProxy(GetDefaultLogger(loggingConfig), new LogDataFactory());
    }
}