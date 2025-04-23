// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Bodoconsult.App.Logging
{
    /// <summary>
    /// Default implementation creating default logger from appsettings.json file
    /// </summary>
    public class DefaultAppLoggerProvider : IDefaultAppLoggerProvider
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public DefaultAppLoggerProvider(IAppConfigurationProvider appConfigurationProvider)
        {
            AppConfigurationProvider = appConfigurationProvider;
        }

        /// <summary>
        /// Current app configuration provider
        /// </summary>
        public IAppConfigurationProvider AppConfigurationProvider { get; }

        /// <summary>
        /// Current logging config
        /// </summary>
        public LoggingConfig LoggingConfig { get; private set; }

        /// <summary>
        /// The app default logger instance create by the provider
        /// </summary>
        public IAppLoggerProxy DefaultLogger { get; private set; }


        /// <summary>
        /// Load the logging settings from <see cref="IAppConfigurationProvider.Configuration"/>
        /// </summary>
        public void LoadLoggingConfigFromConfiguration()
        {
            LoggingConfig = new LoggingConfig
            {
                LogDataFactory = new LogDataFactory()
            };

            var config = AppConfigurationProvider.ReadLoggingSection();

            var kids = config.GetChildren().ToList();

            // Add minimum log level from config
            var minLevel = kids.FirstOrDefault(x => x.Key == "MinimumLogLevel");

            if (minLevel != null)
            {
                Enum.TryParse(minLevel.Value, ignoreCase: true, result: out LogLevel logLevelValue);
                LoggingConfig.MinimumLogLevel = logLevelValue;
            }

            // Add filters from config
            var logLevels = config.GetSection("LogLevel").GetChildren();
            foreach (var logLevel in logLevels)
            {
                Enum.TryParse(logLevel.Value, ignoreCase: true, result: out LogLevel logLevelValue);
                LoggingConfig.Filters.Add(logLevel.Key, logLevelValue);
            }

            // EventSource provider
            var section = config.GetChildren().FirstOrDefault(item => item.Key == "EventSource");
            if (section != null)
            {
                LoggingConfig.UseEventSourceProvider = true;

                // Privide only errors to UI
                LoggingConfig.EventLogSettings.Filter = (s, level) => level <= LogLevel.Error;
            }


            // Debug provider
            section = kids.FirstOrDefault(item => item.Key == "Debug");
            if (section != null)
            {
                LoggingConfig.UseDebugProvider = true;
            }

            // Log4Net provider
            section = kids.FirstOrDefault(item => item.Key == "Log4Net");
            if (section != null)
            {
                LoggingConfig.UseLog4NetProvider = true;
            }

            IConfigurationSection oValue;

            // Console provider settings
            section = kids.FirstOrDefault(item => item.Key == "Console");
            if (section != null)
            {
                LoggingConfig.UseConsoleProvider = true;

                oValue = section.GetChildren().FirstOrDefault(x => x.Key == "DisableColors");
                LoggingConfig.ConsoleConfigurationSettings.ColorBehavior = 
                    oValue != null && oValue.Value.ToUpperInvariant() != "FALSE" ? LoggerColorBehavior.Enabled: LoggerColorBehavior.Disabled;

                oValue = section.GetChildren().FirstOrDefault(x => x.Key == "IncludeScopes");
                LoggingConfig.ConsoleConfigurationSettings.IncludeScopes =
                    oValue != null && oValue.Value.ToUpperInvariant() != "FALSE";
            }

            // EventLog provider
            section = kids.FirstOrDefault(item => item.Key == "EventLog");
            if (section == null)
            {
                return;
            }

            LoggingConfig.UseEventLogProvider = true;

            oValue = section.GetChildren().FirstOrDefault(x => x.Key == "SourceName");
            LoggingConfig.EventLogSettings.SourceName = oValue?.Value;

            oValue = section.GetChildren().FirstOrDefault(x => x.Key == "LogName");
            LoggingConfig.EventLogSettings.LogName = oValue?.Value;

            oValue = section.GetChildren().FirstOrDefault(x => x.Key == "MachineName");
            LoggingConfig.EventLogSettings.MachineName = oValue?.Value;
        }

        /// <summary>
        /// Load <see cref="IDefaultAppLoggerProvider.DefaultLogger"/> from <see cref="IDefaultAppLoggerProvider.LoggingConfig"/>
        /// </summary>
        public void LoadDefaultLogger()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddDefaultLogger(LoggingConfig);

            var logFactory = serviceCollection.BuildServiceProvider()
                .GetService<ILoggerFactory>();

            DefaultLogger = new AppLoggerProxy(logFactory, LoggingConfig.LogDataFactory);
        }

    }
}
