// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.AppStarter;
using Bodoconsult.App.BusinessTransactions.RequestData;
using Bodoconsult.App.Exceptions;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App;

/// <summary>
    /// Base class for <see cref="IAppBuilder"/> implementations
    /// </summary>
    public class BaseAppBuilder : IAppBuilder
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="appGlobals">Global app settings</param>
    public BaseAppBuilder(IAppGlobals appGlobals)
    {
        AppGlobals = appGlobals;
        AppGlobals.StatusMessageDelegate = StatusMessageDelegate;
    }

    /// <summary>
    /// Global app settings
    /// </summary>
    public IAppGlobals AppGlobals { get; }

    /// <summary>
    /// Current app path
    /// </summary>
    public string AppPath { get; private set; }

    /// <summary>
    /// Current config file
    /// </summary>
    public string ConfigFile { get; private set; }

    /// <summary>
    /// Current <see cref="IAppStarterUi"/> instance
    /// </summary>
    public IAppStarter AppStarter { get; protected set; }

    /// <summary>
    /// Current app start provider
    /// </summary>
    public IAppStartProvider AppStartProvider { get; protected set; }

    /// <summary>
    /// Package with all DI container services to load for uasge in the app
    /// </summary>
    public IDiContainerServiceProviderPackage DiContainerServiceProviderPackage { get; protected set; }

    /// <summary>
    /// Current app server
    /// </summary>
    public IApplicationService ApplicationServer { get; private set; }

    /// <summary>
    /// Load basic settings
    /// </summary>
    /// <param name="appStartType">Type of the app entry class (probably Program)</param>
    public void LoadBasicSettings(Type appStartType)
    {
        var s = appStartType.Assembly.Location;
        AppPath = new FileInfo(s).DirectoryName;
        ConfigFile = Path.Combine(AppPath, "appsettings.json");

#if DEBUG
        // Load app settings from dev app settings file in DEBUG mode
        if (File.Exists(Path.Combine(AppPath, "appsettings.Development.json")))
        {
            ConfigFile = Path.Combine(AppPath, "appsettings.Development.json");
        }
#endif
    }

    /// <summary>
    /// Process the configuration from <see cref="IAppBuilder.ConfigFile"/>. Uses the <see cref="DefaultAppStartProvider"/>.
    /// </summary>
    public virtual void ProcessConfiguration()
    {
        // Now prepare the app start
        AppStartProvider = new DefaultAppStartProvider
        {
            ConfigFile = ConfigFile
        };

        AppStartProvider.LoadConfigurationProvider();
        AppStartProvider.LoadAppStartParameter();

    }

    /// <summary>
    /// Load global settings like the default logger
    /// </summary>
    public void LoadGlobalSettings()
    {
        AppStartProvider.LoadDefaultAppLoggerProvider();
        AppStartProvider.SetValuesInAppGlobal(AppGlobals);
    }

    /// <summary>
    /// Check if storage connection is available
    /// </summary>
    /// <exception cref="AppStorageConnectionCheckException">Storage connection is not avialbale exception</exception>
    public void CheckStorageConnection()
    {
        AppGlobals.Logger.LogWarning($"{AppGlobals.AppStartParameter.AppName} app {AppGlobals.AppStartParameter.AppVersion} starts...");

        var check = AppGlobals.AppStorageConnectionCheck;

        if (check == null)
        {
            return;
        }

        if (check.IsConnected)
        {
            return;
        }

        AppGlobals.Logger.LogError($"{AppGlobals.AppStartParameter.AppName} app {AppGlobals.AppStartParameter.AppVersion} start failed. Data storage not available: {check.HelpfulInformation}");
        throw new AppStorageConnectionCheckException(check.HelpfulInformation);
    }

    /// <summary>
    /// Load the <see cref="IAppBuilder.DiContainerServiceProviderPackage"/>
    /// </summary>
    public virtual void LoadDiContainerServiceProviderPackage()
    {
        throw new NotSupportedException("Please override the method LoadDiContainerServiceProviderPackage to load your requested provider");
    }

    /// <summary>
    /// Register DI container services
    /// </summary>
    public virtual void RegisterDiServices()
    {
        DiContainerServiceProviderPackage.AddServices(AppGlobals.DiContainer);
    }

    /// <summary>
    /// Finalize the DI container setup. Use this method to solve circular references via method injection
    /// </summary>
    public void FinalizeDiContainerSetup()
    {
        DiContainerServiceProviderPackage.LateBindObjects(AppGlobals.DiContainer);
    }

    /// <summary>
    /// Start the application. Default start mode is a console app.
    /// </summary>
    public virtual void StartApplication()
    {
        var appStarter = new ConsoleAppStarterUi(this)
        {
            MsgHowToShutdownServer = UiMessages.MsgHowToShutdownServer,
            MsgConsoleWait = UiMessages.MsgAppIsReady,
        };
        AppStarter = appStarter;

        // Run as singleton app
        if (AppGlobals.AppStartParameter.IsSingletonApp && appStarter.IsAnotherInstance)
        {
            Console.WriteLine($"Another instance of {AppGlobals.AppStartParameter.AppName} is already running! Press any key to proceed!");
            Console.ReadLine();
            Environment.Exit(0);
            return;
        }

        appStarter.Start();

        appStarter.Wait();
    }

    /// <summary>
    /// Start the application service
    /// </summary>
    public void StartApplicationService()
    {
        ApplicationServer = AppGlobals.DiContainer.Get<IApplicationService>();
        ApplicationServer.RequestApplicationStopDelegate = RequestApplicationStop;
        ApplicationServer.RegisterServices();
        ApplicationServer.LicenseMissingDelegate = TerminateIfLicenseMissing;
        ApplicationServer.StartApplication();

        AppGlobals.Logger.LogWarning($"{AppGlobals.AppStartParameter.AppName} app is started!");
    }

    /// <summary>
    /// Suspend the app
    /// </summary>
    public void SuspendApplication()
    {
        AppGlobals.Logger.LogWarning($"{AppGlobals.AppStartParameter.AppName} app is going to suspend mode...");
        ApplicationServer.SuspendApplication();
    }

    /// <summary>
    /// Restart the app if it is in suspend state
    /// </summary>
    public void RestartApplication()
    {
        if (AppGlobals.Logger == null)
        {
            throw new ArgumentException("Logger is null");
        }

        AppGlobals.Logger.LogWarning($"{AppGlobals.AppStartParameter.AppName} app is recovering from suspend mode...");

        // Restart DI container
        AppGlobals.DiContainer.ClearAll();
        DiContainerServiceProviderPackage.AddServices(AppGlobals.DiContainer);
        DiContainerServiceProviderPackage.LateBindObjects(AppGlobals.DiContainer);

        AppGlobals.Logger = AppGlobals.DiContainer.Get<IAppLoggerProxy>();
        AppGlobals.Logger.LogInformation("Global and database services successfully registered!");

        AppGlobals.Logger.LogInformation($"{AppGlobals.AppStartParameter.AppName} app restarts...");
        AppGlobals.Logger.LogInformation(AppGlobals.AppStartParameter.AppVersion);

        StartApplicationService();
    }

    /// <summary>
    /// Stops the application
    /// </summary>
    public virtual void StopApplication()
    {
        AppGlobals.EventWaitHandle?.Reset();
        ApplicationServer?.StopApplication();
    }

    /// <summary>
    /// Load the app starter service from a background service
    /// </summary>
    /// <param name="appStarter">Current app starter instance</param>
    public void LoadAppStarterUi(IAppStarter appStarter)
    {
        AppStarter = appStarter;
    }

    /// <summary>
    /// Handle an unhandled exception
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Arguments</param>
    public void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        // Report the crash
        ReportCrash((Exception)e.ExceptionObject);
        AsyncHelper.Delay(1000);

        var ex = (Exception)e.ExceptionObject;
        throw ex;
    }

    private void ReportCrash(Exception unhandledException)
    {

        var gms = AppGlobals.DiContainer.Get<IGeneralAppManagementManager>();

        var fileName = Path.Combine(AppGlobals.AppStartParameter.DataPath, $"{AppGlobals.AppStartParameter.AppFolderName}_Crash.log");

        var request = new EmptyBusinessTransactionRequestData();
        // ToDo: fill request with useful information

        var logger = AppGlobals.DiContainer.Get<IAppLoggerProxy>();

        try
        {
            const string logMessage = "Unhandled exception caught";
            logger?.LogCritical(unhandledException, logMessage);

            File.AppendAllText(fileName, $"Crash at {DateTime.Now}: {unhandledException}{Environment.NewLine}");

            var result = gms?.CreateLogDump(request);

            if (result == null)
            {
                return;
            }

            logger?.LogWarning(fileName, $"CreateLogDump after crash: error code {result.ErrorCode}: {result.Message}");
        }
        catch (Exception e)
        {
            LogFinalException(fileName, e);
        }

        try
        {
            StopApplication();
        }
        catch
        {
            //
        }
    }

    private static void LogFinalException(string fileName, Exception e)
    {
        try
        {
            File.AppendAllText(fileName, $"Crash at {DateTime.Now}: {e}{Environment.NewLine}");
        }
        catch
        {
            // Do nothing
        }
    }

    private void RequestApplicationStop()
    {
        StopApplication();

        AppStarter.TerminateAppWithMessage("App shutdown requested", AppGlobals.AppStartParameter.AppName);

    }

    private void StatusMessageDelegate(string message)
    {
        AppGlobals.Logger?.LogInformation(message);
    }

    protected void TerminateIfLicenseMissing(string message)
    {
        AppGlobals.Logger?.LogError("License not found");

        AppStarter?.TerminateAppWithMessage(UiMessages.MsgLicenseNotFoundNowTerminate, AppGlobals.AppStartParameter.AppName);
    }
}