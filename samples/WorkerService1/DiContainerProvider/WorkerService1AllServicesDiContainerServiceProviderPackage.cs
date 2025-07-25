// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.DependencyInjection;

namespace WorkerService1.DiContainerProvider;

/// <summary>
/// Load all the complete package of WorkerService1 services based on GRPC to DI container. Intended mainly for production
/// </summary>
public class WorkerService1AllServicesDiContainerServiceProviderPackage : BaseDiContainerServiceProviderPackage
{

    public WorkerService1AllServicesDiContainerServiceProviderPackage(IAppGlobals appGlobals) : base(appGlobals)
    {

        DoNotBuildDiContainer = true;

        // Performance measurement
        IDiContainerServiceProvider  provider = new ApmDiContainerServiceProvider(appGlobals.AppStartParameter, appGlobals.StatusMessageDelegate);
        ServiceProviders.Add(provider);

        // App default logging
        provider = new DefaultAppLoggerDiContainerServiceProvider(appGlobals.LoggingConfig, appGlobals.Logger);
        ServiceProviders.Add(provider);

        // SWorkerService1 specific services
        provider = new WorkerService1AllServicesContainerServiceProvider(appGlobals.AppStartParameter, appGlobals.LicenseMissingDelegate);
        ServiceProviders.Add(provider);
    }

}