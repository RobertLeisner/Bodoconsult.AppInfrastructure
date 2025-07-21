// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Abstractions.DependencyInjection;

namespace Bodoconsult.I18N.DependencyInjection
{
    /// <summary>
    /// DI container service provider for loading I18N instance
    /// </summary>
    public class I18NDiContainerServiceProvider : IDiContainerServiceProvider
    {
        private readonly II18NFactory _i18NFactory;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="i18NFactory">Current factory for a configured I18N instance</param>
        public I18NDiContainerServiceProvider(II18NFactory i18NFactory)
        {
            _i18NFactory = i18NFactory;
        }

        /// <summary>
        /// Add DI container services to a DI container
        /// </summary>
        /// <param name="diContainer">Current DI container</param>
        public void AddServices(DiContainer diContainer)
        {
            var i18N = (II18N)_i18NFactory.CreateInstance();
            diContainer.AddSingleton(i18N);
        }

        /// <summary>
        /// Late bind DI container references to avoid circular DI references
        /// </summary>
        /// <param name="diContainer">Current DI container</param>
        public void LateBindObjects(DiContainer diContainer)
        {
            // Do nothing
        }
    }
}
