// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App;
using Bodoconsult.App.Benchmarking;
using Bodoconsult.App.BusinessTransactions;
using Bodoconsult.App.Delegates;
using Bodoconsult.App.DependencyInjection;
using Bodoconsult.App.EventCounters;
using Bodoconsult.App.Factories;
using Bodoconsult.App.GrpcBackgroundService.Interfaces;
using Bodoconsult.App.Interfaces;
using GrpcServerApp.BusinessLogic.BusinessLogic;
using GrpcServerApp.BusinessLogic.BusinessTransactions;
using GrpcServerApp.BusinessLogic.Interfaces;
using GrpcServerApp.Grpc.App;
using GrpcServerApp.Grpc.MappingServices;
using Microsoft.Extensions.Logging;

namespace GrpcServerApp.Grpc.DiContainerProvider
{
    /// <summary>
    /// Load all specific GrpcServerApp services to DI container. Intended mainly for production
    /// </summary>
    public class GrpcServerAppAllServicesContainerServiceProvider : IDiContainerServiceProvider
    {

        private readonly string _benchmarkFileName = Path.Combine("C:\\ProgramData\\GrpcServerApp", "GrpcServerApp_Benchmark.csv");

        public GrpcServerAppAllServicesContainerServiceProvider(IAppStartParameter appStartParameter, LicenseMissingDelegate licenseMissingDelegate)
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
            // Factories to create instance related objects (should be singletons)
            diContainer.AddSingletonInstance(Globals.Instance.LogDataFactory);
            diContainer.AddSingleton<IAppLoggerProxyFactory, AppLoggerProxyFactory>();
            diContainer.AddSingleton<IAppEventSource, AppApmEventSource>();

            // benchmark
            var benchProxy = AppBenchProxy.CreateAppBenchProxy(_benchmarkFileName, Globals.Instance.LogDataFactory);
            diContainer.AddSingletonInstance(benchProxy);

            // General app management
            diContainer.AddSingleton<IGeneralAppManagementService, GeneralAppManagementService>();
            diContainer.AddSingleton<IGeneralAppManagementManager, GeneralAppManagementManager>();

            // Load all other services required for the app now

            var factory = (IDiContainerServiceProviderPackageFactory)new GrpcServerAppProductionDiContainerServiceProviderPackageFactory(Globals.Instance);

            diContainer.AddSingleton(factory);
            diContainer.AddSingleton<IApplicationService, GrpcServerAppService>();
            
            diContainer.AddSingleton<IBusinessTransactionManager, BusinessTransactionManager>();
            diContainer.AddSingleton<IBusinessTransactionLoader, GrpcServerAppBusinessTransactionLoader>();

            diContainer.AddSingleton<IDemoBl, DemoBl>();
            diContainer.AddSingleton<IGrpcBusinessTransactionRequestMappingService, GrpcBusinessTransactionRequestMappingService>();
            diContainer.AddSingleton<IGrpcBusinessTransactionReplyMappingService, GrpcBusinessTransactionReplyMappingService>();

            // ...

        }

        /// <summary>
        /// Late bind DI container references to avoid circular DI references
        /// </summary>
        /// <param name="diContainer"></param>
        public void LateBindObjects(DiContainer diContainer)
        {
            var appLogger = diContainer.Get<IAppLoggerProxy>();

            //appLogger.LogInformation($"Benchmark starts logging to {_benchmarkFileName}...");

            // Set logger to current logger factory
            var loggerFactory = diContainer.Get<ILoggerFactory>();
            appLogger.UpdateILoggerFactory(loggerFactory);

            // Load business transactions
            var btl = diContainer.Get<IBusinessTransactionLoader>();
            btl.LoadProviders();

        }
    }
}