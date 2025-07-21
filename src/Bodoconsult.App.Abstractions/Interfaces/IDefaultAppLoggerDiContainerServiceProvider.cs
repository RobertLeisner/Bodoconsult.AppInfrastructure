// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

namespace Bodoconsult.App.Abstractions.Interfaces
{
    /// <summary>
    /// Interface for classes adding default app related DI container services to a DI container
    /// </summary>
    public interface IDefaultAppLoggerDiContainerServiceProvider: IDiContainerServiceProvider
    {

        /// <summary>
        /// Current logging config
        /// </summary>
        LoggingConfig LoggingConfig { get; }

        /// <summary>
        /// Current app logger
        /// </summary>
        IAppLoggerProxy Logger { get;  }

    }
}