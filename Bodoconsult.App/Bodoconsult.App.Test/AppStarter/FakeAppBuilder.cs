// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Test.AppStarter
{
    /// <summary>
    /// Fake implementation of <see cref="IAppBuilder"/> for unit testing
    /// </summary>
    internal class FakeAppBuilder : IAppBuilder
    {
        /// <summary>
        /// Global app settings
        /// </summary>
        public IAppGlobals AppGlobals { get; set; }

        /// <summary>
        /// Current app path
        /// </summary>
        public string AppPath { get; set; }

        /// <summary>
        /// Current config file
        /// </summary>
        public string ConfigFile { get; set; }

        /// <summary>
        /// Current <see cref="IAppStarterUi"/> instance
        /// </summary>
        public IAppStarter AppStarter { get; set; }

        /// <summary>
        /// Current app start provider
        /// </summary>
        public IAppStartProvider AppStartProvider { get; set; }

        /// <summary>
        /// Package with all DI container services to load for uasge in the app
        /// </summary>
        public IDiContainerServiceProviderPackage DiContainerServiceProviderPackage { get; set; }

        /// <summary>
        /// Current app server
        /// </summary>
        public IApplicationService ApplicationServer { get; set; }

        public bool WasStartApplication { get; set; }

        /// <summary>
        /// Load basic settings
        /// </summary>
        /// <param name="appStartType">Type of the app entry class (probably Program)</param>
        public void LoadBasicSettings(Type appStartType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Process the configuration from <see cref="IAppBuilder.ConfigFile"/>
        /// </summary>
        public void ProcessConfiguration()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load global settings like the default logger
        /// </summary>
        public void LoadGlobalSettings()
        {
            throw new NotImplementedException();
        }

        public void CheckStorageConnection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load the <see cref="IAppBuilder.DiContainerServiceProviderPackage"/>
        /// </summary>
        public void LoadDiContainerServiceProviderPackage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Regsiter DI container services
        /// </summary>
        public void RegisterDiServices()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finalize the DI container setup. Use this method to solve circular references via method injection
        /// </summary>
        public void FinalizeDiContainerSetup()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start the application. Default start mode is a console app.
        /// </summary>
        public void StartApplication()
        {
            WasStartApplication = true;
        }

        /// <summary>
        /// Start the application service
        /// </summary>
        public void StartApplicationService()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Suspend the app
        /// </summary>
        public void SuspendApplication()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Restart the app if it is in suspend state
        /// </summary>
        public void RestartApplication()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the application
        /// </summary>
        public void StopApplication()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load the app starter service from a background service
        /// </summary>
        /// <param name="appStarter">Current app starter instance</param>
        public void LoadAppStarterUi(IAppStarter appStarter)
        {
            AppStarter = appStarter;
        }
    }
}