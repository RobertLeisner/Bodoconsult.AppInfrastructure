﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace GrpcServerApp.Grpc.DiContainerProvider
{
    /// <summary>
    /// The current DI container used for production 
    /// </summary>
    public class GrpcServerAppProductionDiContainerServiceProviderPackageFactory : IDiContainerServiceProviderPackageFactory
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public GrpcServerAppProductionDiContainerServiceProviderPackageFactory(IAppGlobals appGlobals)
        {
            AppGlobals = appGlobals;
        }

        /// <summary>
        /// App globals
        /// </summary>
        public IAppGlobals AppGlobals { get; }

        /// <summary>
        /// Create an instance of <see cref="IDiContainerServiceProviderPackage"/>. Should be a singleton instance
        /// </summary>
        /// <returns>Singleton instance of <see cref="IDiContainerServiceProviderPackage"/></returns>
        public IDiContainerServiceProviderPackage CreateInstance()
        {
            
            return new GrpcServerAppAllServicesDiContainerServiceProviderPackage(AppGlobals);
        }
    }
}