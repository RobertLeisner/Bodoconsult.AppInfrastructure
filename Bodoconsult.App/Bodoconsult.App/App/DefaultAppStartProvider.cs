// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Globalization;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Logging;
using Microsoft.Diagnostics.Tracing.Parsers.FrameworkEventSource;

namespace Bodoconsult.App
{
    /// <summary>
    /// Default app start provider reading configuration, creating app start parameter and creating logger as defined in configuration
    /// </summary>
    public class DefaultAppStartProvider : IAppStartProvider
    {
        /// <summary>
        /// The default app configuration file
        /// </summary>
        public string ConfigFile { get; set; } = "appsettings.json";

        /// <summary>
        /// Current <see cref="IAppConfigurationProvider"/> instance to use
        /// </summary>
        public IAppConfigurationProvider AppConfigurationProvider { get; private set; }

        /// <summary>
        /// Current <see cref="IAppStartParameter"/> to use
        /// </summary>
        public IAppStartParameter AppStartParameter { get; private set; }

        /// <summary>
        /// Current instance of <see cref="IDefaultAppLoggerProvider"/> to use
        /// </summary>
        public IDefaultAppLoggerProvider DefaultAppLoggerProvider { get; set; }

        /// <summary>
        /// Load the default app configuration provider reading from appsettings.json
        /// </summary>
        public void LoadConfigurationProvider()
        {
            AppConfigurationProvider = new AppConfigurationProvider
            {
                ConfigFile = ConfigFile
            };
            AppConfigurationProvider.LoadConfigurationFromConfigFile();
        }

        /// <summary>
        /// Load the default app start
        /// </summary>
        public void LoadAppStartParameter()
        {
            if (AppConfigurationProvider == null)
            {
                throw new ArgumentNullException(nameof(AppConfigurationProvider));
            }

            AppStartParameter = new AppStartParameter
            {
                DefaultConnectionString = AppConfigurationProvider.ReadDefaultConnection()
            };

            var section = AppConfigurationProvider.ReadAppStartParameterSection();
            if (section == null)
            {
                return;
            }

            // Read AppName
            var calue = section["AppName"];
            if (!string.IsNullOrEmpty(calue))
            {
                AppStartParameter.AppName = calue;
            }

            // Read AppFolderName
            calue = section["AppFolderName"];
            if (!string.IsNullOrEmpty(calue))
            {
                AppStartParameter.AppFolderName = calue;
            }

            // Read port
            calue = section["Port"];
            if (!string.IsNullOrEmpty(calue))
            {
                var iResult = 0;
                try
                {
                    iResult = Convert.ToInt32(calue);
                }
                catch //(Exception e)
                {
                    // Do nothing
                }

                AppStartParameter.Port = iResult;
            }

            // Read backup path
            calue = section["BackupPath"];
            if (!string.IsNullOrEmpty(calue))
            {
                AppStartParameter.BackupPath = calue;
            }

            // Read NumberOfBackupsToKeep
            calue = section["NumberOfBackupsToKeep"];
            if (!string.IsNullOrEmpty(calue))
            {
                var iResult = 0;
                try
                {
                    iResult = Convert.ToInt32(calue);
                }
                catch //(Exception e)
                {
                    // Do nothing
                }

                AppStartParameter.NumberOfBackupsToKeep = iResult;
            }
        }

        /// <summary>
        /// Load customized app start parameter
        /// </summary>
        public void LoadAppStartParameter(IAppStartParameter appStartParameter)
        {
            if (AppConfigurationProvider == null)
            {
                throw new ArgumentNullException(nameof(AppConfigurationProvider));
            }

            AppStartParameter = appStartParameter ?? throw new ArgumentNullException(nameof(appStartParameter));
            AppStartParameter.DefaultConnectionString = AppConfigurationProvider.ReadDefaultConnection();
        }

        /// <summary>
        /// Load the current <see cref="IDefaultAppLoggerProvider"/> implementation
        /// </summary>
        public void LoadDefaultAppLoggerProvider()
        {
            DefaultAppLoggerProvider = new DefaultAppLoggerProvider(AppConfigurationProvider);
            DefaultAppLoggerProvider.LoadLoggingConfigFromConfiguration();
            DefaultAppLoggerProvider.LoadDefaultLogger();
        }

        /// <summary>
        /// Set central values in <see cref="IAppGlobals"/> instance
        /// </summary>
        /// <param name="appInstance">Current app globals instance</param>
        public void SetValuesInAppGlobal(IAppGlobals appInstance)
        {
            appInstance.AppStartParameter = AppStartParameter;
            appInstance.Logger = DefaultAppLoggerProvider.DefaultLogger;
            appInstance.LoggingConfig = DefaultAppLoggerProvider.LoggingConfig;
            appInstance.LogDataFactory = appInstance.LoggingConfig.LogDataFactory;

            appInstance.AppStartParameter.DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), AppStartParameter.AppFolderName);
            appInstance.AppStartParameter.LogfilePath = appInstance.AppStartParameter.DataPath;

        }
    }
}