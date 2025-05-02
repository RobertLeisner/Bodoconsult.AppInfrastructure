// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Delegates;
using Bodoconsult.App.Interfaces;

namespace WorkerService1.DiContainerProvider
{
    /// <summary>
    /// The current DI container used for production 
    /// </summary>
    public class WorkerService1ProductionDiContainerServiceProviderPackageFactory : IDiContainerServiceProviderPackageFactory
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public WorkerService1ProductionDiContainerServiceProviderPackageFactory(IAppGlobals appGlobals)
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
            
            return new WorkerService1AllServicesDiContainerServiceProviderPackage(AppGlobals);
        }
    }
}