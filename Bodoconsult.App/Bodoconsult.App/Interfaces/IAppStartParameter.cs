// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

namespace Bodoconsult.App.Interfaces
{
    /// <summary>
    /// Interface for app start parameter
    /// </summary>
    public interface IAppStartParameter
    {
        /// <summary>
        /// Clear text name of the app to show in windows and message boxes
        /// </summary>
        string AppName { get; set; }

        /// <summary>
        /// String with the current app version
        /// </summary>
        string AppVersion { get; }

        /// <summary>
        /// Current software version
        /// </summary>
        Version SoftwareRevision { get; }

        /// <summary>
        /// Should the logging of performance counters to logfile be activated
        /// </summary>
        bool IsPerformanceLoggingActivated { get; set; }

        /// <summary>
        /// Application path
        /// </summary>
        string AppPath { get; }

        /// <summary>
        /// Default conenction string
        /// </summary>
        string DefaultConnectionString { get; set; }

        /// <summary>
        /// Load a fake license
        /// </summary>
        bool LoadFakeLicense { get; set; }

        /// <summary>
        /// The software team
        /// </summary>
        string SoftwareTeam { get; set; }

        /// <summary>
        /// Ressource path for the app logo (NO file system path!!!)
        /// </summary>
        string LogoRessourcePath { get; set; }

        /// <summary>
        /// The folder name of the app in C:\ProgramData\
        /// </summary>
        string AppFolderName { get; set; }
    }
}
