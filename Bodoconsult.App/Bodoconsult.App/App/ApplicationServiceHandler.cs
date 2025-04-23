// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.Exceptions;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App;

/// <summary>
/// Current implementation of <see cref="IApplicationServiceHandler"/> for console apps
/// </summary>
public class ApplicationServiceHandler : IApplicationServiceHandler
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ApplicationServiceHandler(IDiContainerServiceProviderPackageFactory diContainerServiceProviderPackageFactory)
    {
        DiContainerServiceProviderPackageFactory = diContainerServiceProviderPackageFactory;
        AppGlobals = diContainerServiceProviderPackageFactory.AppGlobals;

        DiContainerServiceProviderPackageFactory.LicenseMissingDelegate = TerminateIfLicenseMissing;
        DiContainerServiceProviderPackageFactory.StatusMessageDelegate = StatusMessageDelegate;
    }

    /// <summary>
    /// Current app server
    /// </summary>
    public IApplicationService ApplicationServer { get; private set; }

    /// <summary>
    /// Current <see cref="IDiContainerServiceProviderPackageFactory"/> instance
    /// </summary>
    public IDiContainerServiceProviderPackageFactory DiContainerServiceProviderPackageFactory { get; }

    /// <summary>
    /// App globals
    /// </summary>
    public IAppGlobals AppGlobals { get; }

    /// <summary>
    /// Current <see cref="IAppStarterUi"/> instance
    /// </summary>
    public IAppStarterUi AppStarterUi { get; private set; }

    /// <summary>
    /// Load the current app starter in the start process
    /// </summary>
    /// <param name="appStarter">Current <see cref="IAppStarterUi"/> instance</param>
    public void SetAppStarterUi(IAppStarterUi appStarter)
    {
        AppStarterUi = appStarter;
    }

    /// <summary>
    /// Start the application
    /// </summary>
    public void StartApplication()
    {

        CheckStorageConnection();

        AppGlobals.Logger.LogWarning($"{AppGlobals.AppStartParameter.AppName} app {AppGlobals.AppStartParameter.AppVersion} starts...");

        RegisterGlobalAndDatabaseServices();

        AppGlobals.Logger.LogDebug($"{AppGlobals.AppStartParameter.AppName} app global and database services successfully registered!");

        Console.WriteLine(AppGlobals.AppStartParameter.AppVersion);

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

        CheckStorageConnection();

        AppGlobals.Logger.LogWarning($"{AppGlobals.AppStartParameter.AppName} app is recovering from suspend mode...");

        RegisterGlobalAndDatabaseServices();

        AppGlobals.Logger = AppGlobals.DiContainer.Get<IAppLoggerProxy>();
        AppGlobals.Logger.LogInformation("Global and database services successfully registered!");

        AppGlobals.Logger.LogInformation($"{AppGlobals.AppStartParameter.AppName} app restarts...");
        AppGlobals.Logger.LogInformation(AppGlobals.AppStartParameter.AppVersion);
        Console.WriteLine(AppGlobals.AppStartParameter.AppVersion);

        ApplicationServer = null;
        ApplicationServer = AppGlobals.DiContainer.Get<IApplicationService>();
        ApplicationServer.RequestApplicationStopDelegate = RequestApplicationStop;
        ApplicationServer.RegisterServices();
        ApplicationServer.StartApplication();
    }

    private void RequestApplicationStop()
    {
        StopApplication();
        AppStarterUi?.TerminateAppWithMessage("App shutdown requested", AppGlobals.AppStartParameter.AppName);
    }

    /// <summary>
    /// Stops the application
    /// </summary>
    public void StopApplication()
    {
        AppGlobals.EventWaitHandle?.Reset();
        ApplicationServer?.StopApplication();
    }

    public void CheckStorageConnection()
    {
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
    /// Register all DI container services required for app start. Do NOT use directly. Only public for unit testing
    /// </summary>
    public void RegisterGlobalAndDatabaseServices()
    {
        try
        {

            var package = DiContainerServiceProviderPackageFactory.CreateInstance();
            package.AddServices(AppGlobals.DiContainer);

            package.LateBindObjects(AppGlobals.DiContainer);

            //// Di tests to find circular refernces in DI container
            //var a = Globals.Instance.DiContainer.Get<ITTraceManagementDelegate>();
            //var b = Globals.Instance.DiContainer.Get<ITTowerMagazineSlotService>();
            //var c = Globals.Instance.DiContainer.Get<ServerUiRequestsImplementationFactory>().Invoke();

        }
        catch (Exception e)
        {
            Debug.Print($"{e}");
            AppGlobals.Logger?.LogError("Setting up DI container failed", e);
            ApplicationServer?.StopApplication();
        }
    }

    private void StatusMessageDelegate(string message)
    {
        AppGlobals.Logger?.LogInformation(message);
    }

    protected void TerminateIfLicenseMissing(string message)
    {
        AppGlobals.Logger?.LogError("License not found");

        AppStarterUi?.TerminateAppWithMessage(UiMessages.MsgLicenseNotFoundNowTerminate, AppGlobals.AppStartParameter.AppName);
    }
}
