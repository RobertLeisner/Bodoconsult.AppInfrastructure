// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Delegates;
using Bodoconsult.App.DependencyInjection;
using Bodoconsult.App.Interfaces;

namespace ConsoleApp1.DiContainerProvider
{
    /// <summary>
    /// Load all the complete package of ConsoleApp1 services based on GRPC to DI container. Intended mainly for production
    /// </summary>
    public class ConsoleApp1AllServicesDiContainerServiceProviderPackage : BaseDiContainerServiceProviderPackage
    {

        public ConsoleApp1AllServicesDiContainerServiceProviderPackage(IAppGlobals appGlobals,
            StatusMessageDelegate statusMessageDelegate, LicenseMissingDelegate licenseMissingDelegate) : base(appGlobals)
        {

            // Performance measurement
            IDiContainerServiceProvider  provider = new ApmDiContainerServiceProvider(appGlobals.AppStartParameter, statusMessageDelegate);
            ServiceProviders.Add(provider);

            // App default logging
            provider = new DefaultAppLoggerDiContainerServiceProvider(appGlobals.LoggingConfig, appGlobals.Logger);
            ServiceProviders.Add(provider);

            // SConsoleApp1 specific services
            provider = new ConsoleApp1AllServicesContainerServiceProvider(appGlobals.AppStartParameter, licenseMissingDelegate);
            ServiceProviders.Add(provider);
        }

    }
}
