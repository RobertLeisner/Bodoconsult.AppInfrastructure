// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.Interfaces
{
    /// <summary>
    /// Interface for app start provider implementations generating the most basic app features like AppStartParameter, app configuration handling from appsettings.json and app default logging
    /// </summary>
    public interface IDefaultAppStartProvider
    {
        /// <summary>
        /// The default app configuration file
        /// </summary>
        string ConfigFile { get; set; }

        /// <summary>
        /// Current <see cref="IAppConfigurationProvider"/> instance to use
        /// </summary>
        IAppConfigurationProvider AppConfigurationProvider { get; }

        /// <summary>
        /// Current <see cref="IAppStartParameter"/> to use
        /// </summary>
        IAppStartParameter AppStartParameter { get; }

        /// <summary>
        /// Current instance of <see cref="IDefaultAppLoggerProvider"/> to use
        /// </summary>
        IDefaultAppLoggerProvider DefaultAppLoggerProvider { get; set; }

        /// <summary>
        /// Load the default app configuration provider reading from appsettings.json
        /// </summary>
        void LoadConfigurationProvider();

        /// <summary>
        /// Load the default app start
        /// </summary>
        void LoadAppStartParameter();

        /// <summary>
        /// Load customized app start parameter
        /// </summary>
        void LoadAppStartParameter(IAppStartParameter appStartParameter);

        /// <summary>
        /// Load the current <see cref="IDefaultAppLoggerProvider"/> implementation
        /// </summary>
        void LoadDefaultAppLoggerProvider();

        /// <summary>
        /// Set central values in <see cref="IAppGlobals"/> instance
        /// </summary>
        /// <param name="appInstance">Current app globals instance</param>
        void SetValuesInAppGlobal(IAppGlobals appInstance);
    }
}