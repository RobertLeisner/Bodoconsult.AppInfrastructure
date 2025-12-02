// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Delegates;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.DependencyInjection;

namespace WpfConsoleApp1.DiContainerProvider;

/// <summary>
/// Load all the complete package of WpfConsoleApp1 services based on GRPC to DI container. Intended mainly for production
/// </summary>
public class WpfConsoleApp1AllServicesDiContainerServiceProviderPackage : BaseDiContainerServiceProviderPackage
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="appGlobals">Current app globals</param>
    /// <param name="statusMessageDelegate">Current statis message delegate to send status messages to UI</param>
    public WpfConsoleApp1AllServicesDiContainerServiceProviderPackage(IAppGlobals appGlobals,
        StatusMessageDelegate statusMessageDelegate) : base(appGlobals)
    {
        // Basic app services
        IDiContainerServiceProvider provider = new BasicAppServicesConfig2ContainerServiceProvider(appGlobals);
        ServiceProviders.Add(provider);

        // Performance measurement
        provider = new ApmDiContainerServiceProvider(appGlobals.AppStartParameter, statusMessageDelegate);
        ServiceProviders.Add(provider);

        // App default logging
        provider = new DefaultAppLoggerDiContainerServiceProvider(appGlobals.LoggingConfig, appGlobals.Logger);
        ServiceProviders.Add(provider);

        // SWpfConsoleApp1 specific services
        provider = new WpfConsoleApp1AllServicesContainerServiceProvider();
        ServiceProviders.Add(provider);
    }
}