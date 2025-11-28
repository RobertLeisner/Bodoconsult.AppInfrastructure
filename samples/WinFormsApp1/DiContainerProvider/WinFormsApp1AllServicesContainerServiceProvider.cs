// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App;
using Bodoconsult.App.Abstractions.Delegates;
using Bodoconsult.App.Abstractions.DependencyInjection;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Benchmarking;
using Bodoconsult.App.Factories;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Logging;
using Bodoconsult.App.WinForms.Interfaces;
using Microsoft.Extensions.Logging;
using WinFormsApp1.App;
using WinFormsApp1.Factories;

namespace WinFormsApp1.DiContainerProvider;

/// <summary>
/// Load all specific WinFormsApp1 services to DI container. Intended mainly for production
/// </summary>
public class WinFormsApp1AllServicesContainerServiceProvider : IDiContainerServiceProvider
{

    private readonly string _benchmarkFileName = Path.Combine("C:\\ProgramData\\WinFormsApp1", "WinFormsApp1_Benchmark.csv");

    public WinFormsApp1AllServicesContainerServiceProvider(IAppStartParameter appStartParameter, LicenseMissingDelegate licenseMissingDelegate)
    {
        AppStartParameter = appStartParameter;
        LicenseMissingDelegate = licenseMissingDelegate;
    }

    /// <summary>
    /// Current app start parameter
    /// </summary>
    public IAppStartParameter AppStartParameter { get; }

    /// <summary>
    /// Current <see cref="LicenseMissingDelegate"/>
    /// </summary>
    public LicenseMissingDelegate LicenseMissingDelegate { get; set; }

    /// <summary>
    /// Add DI container services to a DI container
    /// </summary>
    /// <param name="diContainer">Current DI container</param>
    public void AddServices(DiContainer diContainer)
    {
        // Factories to create tower instance related objects (should be singletons)
        diContainer.AddSingletonInstance(Globals.Instance.LogDataFactory);
        diContainer.AddSingleton<IAppLoggerProxyFactory, AppLoggerProxyFactory>();

        // benchmark
        var benchProxy = AppBenchProxy.CreateAppBenchProxy(_benchmarkFileName, Globals.Instance.LogDataFactory);
        diContainer.AddSingletonInstance(benchProxy);

        // General app management
        diContainer.AddSingleton<IGeneralAppManagementService, GeneralAppManagementService>();
        diContainer.AddSingleton<IGeneralAppManagementManager, GeneralAppManagementManager>();

        // I18N
        II18NFactory i18NFactory = new I18NFactory();
        var i18N = i18NFactory.CreateInstance();
        diContainer.AddSingleton(i18N);

        // AppEventListener 
        diContainer.AddSingleton<IAppEventListener, AppEventListener>();

        // Main view model
        diContainer.AddSingleton<IMainWindowViewModel, WinFormsApp1MainWindowViewModel>();

        // Load all other services required for the app now
        diContainer.AddSingleton<IApplicationService, WinFormsApp1Service>();

        // ...

    }

    /// <summary>
    /// Late bind DI container references to avoid circular DI references
    /// </summary>
    /// <param name="diContainer"></param>
    public void LateBindObjects(DiContainer diContainer)
    {
        var appLogger = diContainer.Get<IAppLoggerProxy>();

        appLogger.LogInformation($"Benchmark starts logging to {_benchmarkFileName}...");

        // Set logger to current logger factory
        var loggerFactory = diContainer.Get<ILoggerFactory>();
        appLogger.UpdateILoggerFactory(loggerFactory);

        //// Example 1: Load the job scheduler now
        //var scheduler = diContainer.Get<IJobSchedulerManagementDelegate>();
        //scheduler.StartJobScheduler();

        //// Example 2: Load business transactions
        //var btl = diContainer.Get<IBusinessTransactionLoader>();
        //btl.LoadProviders();

    }
}