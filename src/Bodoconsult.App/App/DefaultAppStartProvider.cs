// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Logging;

namespace Bodoconsult.App
{
    /// <summary>
    /// Default app start provider reading configuration, creating app start parameter and creating logger as defined in configuration
    /// </summary>
    public class DefaultAppStartProvider : IAppStartProvider
    {
        public DefaultAppStartProvider(IAppGlobals appGlobals)
        {
            AppGlobals=appGlobals;
        }

        /// <summary>
        /// The default app configuration file
        /// </summary>
        public string ConfigFile { get; set; } = "appsettings.json";

        /// <summary>
        /// Global app settings
        /// </summary>
        public IAppGlobals AppGlobals { get; }

        /// <summary>
        /// Current <see cref="IAppConfigurationProvider"/> instance to use
        /// </summary>
        public IAppConfigurationProvider AppConfigurationProvider { get; private set; }

        /// <summary>
        /// Current instance of <see cref="IDefaultAppLoggerProvider"/> to use
        /// </summary>
        public IDefaultAppLoggerProvider DefaultAppLoggerProvider { get; set; }

        /// <summary>
        /// Current logger provider instances to use for logger creation
        /// </summary>
        public IList<ILoggerProviderConfigurator> LoggerProviderConfigurators { get; set; }

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

            AppGlobals.AppStartParameter ??= new AppStartParameter();
            
            if (string.IsNullOrEmpty(AppGlobals.AppStartParameter.DefaultConnectionString))
            {
                AppGlobals.AppStartParameter.DefaultConnectionString = AppConfigurationProvider.ReadDefaultConnection();
            }

            var section = AppConfigurationProvider.ReadAppStartParameterSection();
            if (section == null)
            {
                return;
            }

            // Read AppName
            var calue = section["AppName"];
            if (!string.IsNullOrEmpty(calue))
            {
                AppGlobals.AppStartParameter.AppName = calue;
            }

            // Read AppFolderName
            calue = section["AppFolderName"];
            if (!string.IsNullOrEmpty(calue))
            {
                AppGlobals.AppStartParameter.AppFolderName = calue;
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

                AppGlobals.AppStartParameter.Port = iResult;
            }

            // Read backup path
            calue = section["BackupPath"];
            if (!string.IsNullOrEmpty(calue))
            {
                AppGlobals.AppStartParameter.BackupPath = calue;
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

                AppGlobals.AppStartParameter.NumberOfBackupsToKeep = iResult;
            }
        }


        /// <summary>
        /// Load the current <see cref="IDefaultAppLoggerProvider"/> implementation
        /// </summary>
        public void LoadDefaultAppLoggerProvider()
        {
            DefaultAppLoggerProvider = new DefaultAppLoggerProvider(AppConfigurationProvider, AppGlobals.LoggingConfig);
            DefaultAppLoggerProvider.LoadLoggingConfigFromConfiguration();
            DefaultAppLoggerProvider.LoadDefaultLogger();
        }

        /// <summary>
        /// Set central values in <see cref="IAppGlobals"/> instance
        /// </summary>
        public void SetValuesInAppGlobal()
        {
            AppGlobals.Logger = DefaultAppLoggerProvider.DefaultLogger;
            AppGlobals.LoggingConfig = DefaultAppLoggerProvider.LoggingConfig;
            AppGlobals.LogDataFactory = AppGlobals.LoggingConfig.LogDataFactory;
            AppGlobals.AppStartParameter.DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), AppGlobals.AppStartParameter.AppFolderName);
            AppGlobals.AppStartParameter.LogfilePath = AppGlobals.AppStartParameter.DataPath;
        }
    }
}