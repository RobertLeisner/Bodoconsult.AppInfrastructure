// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.Delegates;
using Bodoconsult.App.DependencyInjection;
using Bodoconsult.App.Logging;

namespace Bodoconsult.App.Interfaces
{
    /// <summary>
    /// Interface for global app settings with lifetime for the whole app lifetime. I
    /// </summary>
    public interface IAppGlobals: IDisposable
    {
        /// <summary>
        /// Is the app started as singleton?
        /// </summary>
        public bool IsSingletonApp { get; set; }

        /// <summary>
        /// This event is set if the application is started only as singleton
        /// </summary>
        public EventWaitHandle EventWaitHandle { get; set; }

        /// <summary>
        /// App start parameter
        /// </summary>
        IAppStartParameter AppStartParameter { get; set; }

        /// <summary>
        /// Current log data entry factory
        /// </summary>
        ILogDataFactory LogDataFactory { get; set; }

        /// <summary>
        /// Current logging config
        /// </summary>
        LoggingConfig LoggingConfig { get; set; }

        /// <summary>
        /// Current app logger. Use this instance only if no DI container is available. Otherwise use DiContainer.Get&lt;IAppLoggerProxy&gt; to fetch the default app logger from DI container. Don't forget to load it during DI setup!
        /// </summary>
        IAppLoggerProxy Logger { get; set; }

        /// <summary>
        /// Current dependency injection (DI) container
        /// </summary>
        DiContainer DiContainer { get; set; }

        /// <summary>
        /// Base path, where the app stores data created by the app like backups, migrations logs and normal log files.
        /// </summary>
        string DataPath { get; set; }

        /// <summary>
        /// Folder to to store log files. Normally the folder <see cref="DataPath"/> to make log dump creation easier
        /// </summary>
        string LogfilePath { get; set; }

        /// <summary>
        /// Folder to to store migration log files and SQL scripts in. Normally a subfolder of the folder <see cref="DataPath"/> 
        /// </summary>
        string MigrationLogfilePath { get; set; }

        /// <summary>
        /// Folder to to store backups in. Normally a subfolder of the folder <see cref="DataPath"/>
        /// </summary>
        string BackupPath { get; set; }

        /// <summary>
        /// Delegate called if a fatale app exception has been raised and a message to the UI has to be sent before app terminates
        /// </summary>
        HandleFatalExceptionDelegate HandleFatalExceptionDelegate  { get; set; }

        /// <summary>
        /// Current app storage connection check instance or null
        /// </summary>
        IAppStorageConnectionCheck AppStorageConnectionCheck { get; set; }

    }
}