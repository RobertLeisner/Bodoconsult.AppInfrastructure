// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Interfaces;

/// <summary>
/// Interface for concrete implementations of the app start process required for a certain app
/// </summary>
public interface IApplicationServiceHandler
{
    /// <summary>
    /// Current <see cref="IDiContainerServiceProviderPackageFactory"/> instance
    /// </summary>
    IDiContainerServiceProviderPackageFactory DiContainerServiceProviderPackageFactory { get; }

    /// <summary>
    /// App globals
    /// </summary>
    IAppGlobals AppGlobals { get; }

    /// <summary>
    /// Current <see cref="IAppStarterUi"/> instance
    /// </summary>
    IAppStarterUi AppStarterUi { get; }

    /// <summary>
    /// Load the current app starter in the start process
    /// </summary>
    /// <param name="appStarterUi">Current <see cref="IAppStarterUi"/> instance</param>
    void SetAppStarterUi(IAppStarterUi appStarterUi);

    /// <summary>
    /// Starts the application
    /// </summary>
    void StartApplication();

    /// <summary>
    /// Suspend the app
    /// </summary>
    void SuspendApplication();

    /// <summary>
    /// Restart the app if it is in suspend state
    /// </summary>
    void RestartApplication();


    /// <summary>
    /// Stops the application
    /// </summary>
    void StopApplication();

}