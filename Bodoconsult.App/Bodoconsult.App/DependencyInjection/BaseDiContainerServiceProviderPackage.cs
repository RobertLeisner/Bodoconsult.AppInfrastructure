// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.DependencyInjection
{
    /// <summary>
    /// Base class for <see cref="IDiContainerServiceProviderPackage"/>. Concrete implementations of <see cref="IDiContainerServiceProviderPackage"/> should inherit from this class and only load <see cref="ServiceProviders"/> list in its ctor
    /// </summary>
    public abstract class BaseDiContainerServiceProviderPackage : IDiContainerServiceProviderPackage
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        protected BaseDiContainerServiceProviderPackage(IAppGlobals appGlobals)
        {
            AppGlobals = appGlobals;
        }

        /// <summary>
        /// Current app globals
        /// </summary>
        public IAppGlobals AppGlobals { get; }

        /// <summary>
        /// Do not build the DI container
        /// </summary>
        public bool DoNotBuildDiContainer { get; protected set; }

        /// <summary>
        /// Current list of services providers
        /// </summary>
        public IList<IDiContainerServiceProvider> ServiceProviders { get; } = new List<IDiContainerServiceProvider>();

        /// <summary>
        /// Add DI container services to a DI container
        /// </summary>
        /// <param name="diContainer">Current DI container</param>
        public void AddServices(DiContainer diContainer)
        {
            // Clear the container (only if needed)
            if (!DoNotBuildDiContainer)
            {
                diContainer.ClearAll();
            }

            // No add the app globals singleton instance as singleton to make it available for DI
            diContainer.AddSingletonInstance(AppGlobals);

            // Now add all services required
            foreach (var serviceProvider in ServiceProviders)
            {
                serviceProvider.AddServices(diContainer);
            }

            // Now build the container services (only if needed)
            if (!DoNotBuildDiContainer)
            {
                diContainer.BuildServiceProvider();
            }
        }

        /// <summary>
        /// Late bind DI container references to avoid circular DI references
        /// </summary>
        /// <param name="diContainer"></param>
        public void LateBindObjects(DiContainer diContainer)
        {
            foreach (var serviceProvider in ServiceProviders)
            {
                serviceProvider.LateBindObjects(diContainer);
            }
        }
    }
}