// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.DependencyInjection;
using Bodoconsult.App.Interfaces;

namespace GrpcServerApp.Grpc.DiContainerProvider
{
    /// <summary>
    /// Load all the complete package of GrpcServerApp services based on GRPC to DI container. Intended mainly for production
    /// </summary>
    public class GrpcServerAppAllServicesDiContainerServiceProviderPackage : BaseDiContainerServiceProviderPackage
    {

        public GrpcServerAppAllServicesDiContainerServiceProviderPackage(IAppGlobals appGlobals) : base(appGlobals)
        {

            DoNotBuildDiContainer = true;

            // Performance measurement
            IDiContainerServiceProvider  provider = new ApmDiContainerServiceProvider(appGlobals.AppStartParameter, appGlobals.StatusMessageDelegate);
            ServiceProviders.Add(provider);

            // App default logging
            provider = new DefaultAppLoggerDiContainerServiceProvider(appGlobals.LoggingConfig, appGlobals.Logger);
            ServiceProviders.Add(provider);

            // SGrpcServerApp specific services
            provider = new GrpcServerAppAllServicesContainerServiceProvider(appGlobals.AppStartParameter, appGlobals.LicenseMissingDelegate);
            ServiceProviders.Add(provider);
        }

    }
}
