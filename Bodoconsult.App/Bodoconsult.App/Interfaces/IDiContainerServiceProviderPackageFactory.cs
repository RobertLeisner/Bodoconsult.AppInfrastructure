// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.Delegates;

namespace Bodoconsult.App.Interfaces
{
    /// <summary>
    /// Interface for creating <see cref="IDiContainerServiceProviderPackage"/>
    /// </summary>
    public interface IDiContainerServiceProviderPackageFactory
    {

        /// <summary>
        /// App globals
        /// </summary>
        IAppGlobals AppGlobals { get; }

        /// <summary>
        /// Create an instance of <see cref="IDiContainerServiceProviderPackage"/>. Should be a singleton instance
        /// </summary>
        /// <returns>Singleton instance of <see cref="IDiContainerServiceProviderPackage"/></returns>

        IDiContainerServiceProviderPackage CreateInstance();

    }
}