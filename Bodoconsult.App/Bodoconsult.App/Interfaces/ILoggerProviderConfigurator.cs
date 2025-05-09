// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodoconsult.App.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bodoconsult.App.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoggerProviderConfigurator
    {
        /// <summary>
        /// The name of the section in the appsettings.json file
        /// </summary>
        string SectionNameAppSettingsJson { get; }

        /// <summary>
        /// The configuration section from appsettings.json or null if not existing
        /// </summary>
        IConfigurationSection Section { get; set; }

        /// <summary>
        /// Add the DI container service used for the current logger provider
        /// </summary>
        /// <param name="builder">Current logging builder</param>
        /// <param name="loggingConfig">Current logging config</param>
        void AddServices(ILoggingBuilder builder, LoggingConfig loggingConfig);
    }
}
