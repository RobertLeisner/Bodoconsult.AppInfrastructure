//// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

//using Bodoconsult.App.Exceptions;

//namespace Bodoconsult.App.Interfaces;

///// <summary>
///// Interface for concrete implementations of the app start process required for a certain app
///// </summary>
//public interface IApplicationServiceHandler
//{
//    /// <summary>
//    /// App globals
//    /// </summary>
//    IAppGlobals AppGlobals { get; }

//    /// <summary>
//    /// Current <see cref="IAppStarterUi"/> instance
//    /// </summary>
//    IAppStarter AppStarterUi { get; }

//    /// <summary>
//    /// Load the current app starter in the start process
//    /// </summary>
//    /// <param name="appStarterUi">Current <see cref="IAppStarterUi"/> instance</param>
//    void SetAppStarterUi(IAppStarter appStarterUi);

//    /// <summary>
//    /// Starts the application in one step. Calls CheckStorageConnection() => RegisterGlobalAndDatabaseServices() => FinalizeSetupForGlobalAndDatabaseServices() => StartApplicationService()
//    /// </summary>
//    void StartApplication();



//    /// <summary>
//    /// Start the application service
//    /// </summary>
//    public void StartApplicationService();

//    /// <summary>
//    /// Suspend the app
//    /// </summary>
//    void SuspendApplication();

//    /// <summary>
//    /// Restart the app if it is in suspend state
//    /// </summary>
//    void RestartApplication();


//    /// <summary>
//    /// Stops the application
//    /// </summary>
//    void StopApplication();

//}