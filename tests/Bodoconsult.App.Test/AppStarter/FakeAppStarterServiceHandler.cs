﻿//// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
//// Licence MIT

//using Bodoconsult.App.AppStarter;
//using Bodoconsult.App.Exceptions;
//using Bodoconsult.App.Interfaces;
//using Bodoconsult.App.Logging;

//namespace Bodoconsult.App.Test.AppStarter;

///// <summary>
///// Fake implementation of <see cref="IAppStarterProcessHandler"/> for unit testing
///// </summary>
//internal class FakeAppStarterServiceHandler : IApplicationServiceHandler
//{

//    /// <summary>
//    /// Default ctor
//    /// </summary>
//    public FakeAppStarterServiceHandler()
//    {
//        var assembly = typeof(BaseAppStarterUi).Assembly;
//        var assemName = assembly.GetName();
//        SoftwareRevision = assemName.Version;

//        AppVersion = $"{assemName.Name}, Version {SoftwareRevision}";

//        AppLogger = new AppLoggerProxy(new FakeLoggerFactory(), new LogDataFactory());

//        AppName = "FakeApp";
//    }


//    /// <summary>
//    /// Clear text name of the app to show in windows and message boxes
//    /// </summary>
//    public string AppName { get; }

//    /// <summary>
//    /// Current <see cref="IDiContainerServiceProviderPackageFactory"/> instance
//    /// </summary>
//    public IDiContainerServiceProviderPackageFactory DiContainerServiceProviderPackageFactory { get; set; }

//    /// <summary>
//    /// App globals
//    /// </summary>
//    public IAppGlobals AppGlobals { get; set; }

//    /// <summary>
//    /// Current <see cref="IAppStarterUi"/> instance
//    /// </summary>
//    public IAppStarter AppStarterUi { get; private set; }

//    /// <summary>
//    /// String with the current app version
//    /// </summary>
//    public string AppVersion { get; }

//    /// <summary>
//    /// Current software version
//    /// </summary>
//    public Version SoftwareRevision { get; }

//    /// <summary>
//    /// Current app logger
//    /// </summary>
//    public IAppLoggerProxy AppLogger { get; }

//    /// <summary>
//    /// Load the current app starter in the start process
//    /// </summary>
//    /// <param name="appStarterUi">Current <see cref="IAppStarterUi"/> instance</param>
//    public void SetAppStarterUi(IAppStarter appStarterUi)
//    {
//        AppStarterUi= appStarterUi;
//    }

//    /// <summary>
//    /// Activates an instance of <see cref="IAppLoggerProxy"/> for logging during app start process. <see cref="IAppStarterProcessHandler.AppLogger"/> may NOT be null after calling this method
//    /// </summary>
//    public void ActivateLogger()
//    {
//        // Do nothing
//        WasActivateLogger = true;
//    }

//    /// <summary>
//    /// Was <see cref="ActivateLogger"/> called
//    /// </summary>
//    public bool WasActivateLogger { get; set; }

//    /// <summary>
//    /// Starts the application
//    /// </summary>
//    public void StartApplication()
//    {
//        // Do nothing
//        WasStartApplication = true;
//    }

//    /// <summary>
//    /// Check if storage connection is available
//    /// </summary>
//    /// <exception cref="AppStorageConnectionCheckException">Storage connection is not avialbale exception</exception>
//    public void CheckStorageConnection()
//    {
//        // Do nothing
//    }

//    /// <summary>
//    /// Start the application service
//    /// </summary>
//    public void StartApplicationService()
//    {
//        throw new NotImplementedException();
//    }

//    public void RegisterGlobalAndDatabaseServices()
//    {
//        throw new NotImplementedException();
//    }

//    public void FinalizeSetupForGlobalAndDatabaseServices()
//    {
//        // Do nothing
//    }

//    /// <summary>
//    /// Suspend the app
//    /// </summary>
//    public void SuspendApplication()
//    {
//        throw new NotImplementedException();
//    }

//    /// <summary>
//    /// Restart the app if it is in suspend state
//    /// </summary>
//    public void RestartApplication()
//    {
//        throw new NotImplementedException();
//    }

//    /// <summary>
//    /// Was <see cref="StartApplication"/> called
//    /// </summary>
//    public bool WasStartApplication { get; set; }

//    /// <summary>
//    /// Stops the application
//    /// </summary>
//    public void StopApplication()
//    {
//        // Do nothing
//    }

//    /// <summary>
//    /// Checks if the database is available
//    /// </summary>
//    public void CheckDatabaseServerConnection()
//    {
//        // Do nothing
//    }

//    /// <summary>
//    /// Handles an exception an returns a string to use in UI
//    /// </summary>
//    /// <param name="e">Raised exception</param>
//    /// <returns>String with information for the raised exception</returns>
//    public string HandleException(Exception e)
//    {
//        // Do nothing
//        return "Teststring";
//    }
//}