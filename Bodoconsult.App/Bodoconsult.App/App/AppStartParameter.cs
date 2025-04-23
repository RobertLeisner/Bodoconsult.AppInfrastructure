// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using System.Reflection;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App
{
    public class AppStartParameter: IAppStartParameter
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public AppStartParameter()
        {
            var ass = Assembly.GetEntryAssembly();

            if (ass == null)
            {
                throw new ArgumentNullException(nameof(ass));
            }

            var assemName = ass.GetName();
            SoftwareRevision = assemName.Version;

            AppVersion = $"{assemName.Name}, Version {SoftwareRevision}";

            var fi = new FileInfo(ass.Location);

            AppPath = fi.DirectoryName;
        }

        /// <summary>
        /// Clear text name of the app to show in windows and message boxes
        /// </summary>
        public string AppName { get; set; } = "MyApp";

        /// <summary>
        /// String with the current app version
        /// </summary>
        public string AppVersion { get; }

        /// <summary>
        /// Current software version
        /// </summary>
        public Version SoftwareRevision { get; }

        /// <summary>
        /// Should the logging of performance counters to logfile be activated
        /// </summary>
        public bool IsPerformanceLoggingActivated { get; set; }

        /// <summary>
        /// Application path
        /// </summary>
        public string AppPath { get; }

        /// <summary>
        /// Default conenction string
        /// </summary>
        public string DefaultConnectionString { get; set; }

        /// <summary>
        /// Load a fake license
        /// </summary>
        public bool LoadFakeLicense { get; set; }

        /// <summary>
        /// The software team
        /// </summary>
        public string SoftwareTeam { get; set; }

        /// <summary>
        /// Ressource path for the app logo (NO file system path!!!)
        /// </summary>
        public string LogoRessourcePath { get; set; }

        /// <summary>
        /// The folder name of the app in C:\ProgramData\
        /// </summary>
        public string AppFolderName { get; set; }
    }
}