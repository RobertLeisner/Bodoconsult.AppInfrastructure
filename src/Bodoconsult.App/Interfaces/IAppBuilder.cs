﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Exceptions;

namespace Bodoconsult.App.Interfaces;

public interface IAppBuilder
{
    /// <summary>
    /// Global app settings
    /// </summary>
    IAppGlobals AppGlobals { get;  }

    /// <summary>
    /// Current app path
    /// </summary>
    string AppPath { get; }

    /// <summary>
    /// Current config file
    /// </summary>
    string ConfigFile { get; }

    /// <summary>
    /// Current <see cref="IAppStarterUi"/> instance
    /// </summary>
    public IAppStarter AppStarter { get; }

    /// <summary>
    /// Current app start provider
    /// </summary>
    IAppStartProvider AppStartProvider { get; }

    /// <summary>
    /// Package with all DI container services to load for uasge in the app
    /// </summary>
    IDiContainerServiceProviderPackage DiContainerServiceProviderPackage { get;  }

    /// <summary>
    /// Current app server
    /// </summary>
    public IApplicationService ApplicationServer { get; }


    /// <summary>
    /// Load basic settings
    /// </summary>
    /// <param name="appStartType">Type of the app entry class (probably Program)</param>
    void LoadBasicSettings(Type appStartType);

    /// <summary>
    /// Process the configuration from <see cref="ConfigFile"/>
    /// </summary>
    void ProcessConfiguration();

    /// <summary>
    /// Load global settings like the default logger
    /// </summary>
    void LoadGlobalSettings();

    /// <summary>
    /// Check if storage connection is available
    /// </summary>
    /// <exception cref="AppStorageConnectionCheckException">Storage connection is not avialbale exception</exception>
    void CheckStorageConnection();

    /// <summary>
    /// Load the <see cref="IAppBuilder.DiContainerServiceProviderPackage"/>
    /// </summary>
    void LoadDiContainerServiceProviderPackage();

    /// <summary>
    /// Regsiter DI container services
    /// </summary>
    void RegisterDiServices();

    /// <summary>
    /// Finalize the DI container setup. Use this method to solve circular references via method injection
    /// </summary>
    void FinalizeDiContainerSetup();




    /// <summary>
    /// Start the application. Default start mode is a console app.
    /// </summary>
    void StartApplication();

    /// <summary>
    /// Start the application service
    /// </summary>
    void StartApplicationService();

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

    /// <summary>
    /// Load the app starter service from a background service
    /// </summary>
    /// <param name="appStarter">Current app starter instance</param>
    void LoadAppStarterUi(IAppStarter appStarter);

    /// <summary>
    /// Handle an unhandled exception
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Arguments</param>
    void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e);
}