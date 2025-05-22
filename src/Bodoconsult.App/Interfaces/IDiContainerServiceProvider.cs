// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.DependencyInjection;

namespace Bodoconsult.App.Interfaces
{
    /// <summary>
    /// Interface for classes adding DI container services to a DI container
    /// </summary>
    public interface IDiContainerServiceProvider
    {
        /// <summary>
        /// Add DI container services to a DI container
        /// </summary>
        /// <param name="diContainer">Current DI container</param>
        void AddServices(DiContainer diContainer);

        /// <summary>
        /// Late bind DI container references to avoid circular DI references
        /// </summary>
        /// <param name="diContainer"></param>
        void LateBindObjects(DiContainer diContainer);

    }
}