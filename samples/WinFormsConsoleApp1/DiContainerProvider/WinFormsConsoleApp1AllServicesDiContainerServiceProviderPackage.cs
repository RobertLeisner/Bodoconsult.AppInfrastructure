// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Delegates;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.DependencyInjection;

namespace WinFormsConsoleApp1.DiContainerProvider;

/// <summary>
/// Load all the complete package of WinFormsConsoleApp1 services based on GRPC to DI container. Intended mainly for production
/// </summary>
public class WinFormsConsoleApp1AllServicesDiContainerServiceProviderPackage : BaseDiContainerServiceProviderPackage
{

    public WinFormsConsoleApp1AllServicesDiContainerServiceProviderPackage(IAppGlobals appGlobals,
        StatusMessageDelegate statusMessageDelegate, LicenseMissingDelegate licenseMissingDelegate) : base(appGlobals)
    {
        // Basic app services
        IDiContainerServiceProvider provider = new BasicAppServicesConfig1ContainerServiceProvider(appGlobals);
        ServiceProviders.Add(provider);

        // Performance measurement
        provider = new ApmDiContainerServiceProvider(appGlobals.AppStartParameter, statusMessageDelegate);
        ServiceProviders.Add(provider);

        // App default logging
        provider = new DefaultAppLoggerDiContainerServiceProvider(appGlobals.LoggingConfig, appGlobals.Logger);
        ServiceProviders.Add(provider);

        // SWinFormsConsoleApp1 specific services
        provider = new WinFormsConsoleApp1AllServicesContainerServiceProvider();
        ServiceProviders.Add(provider);
    }

}