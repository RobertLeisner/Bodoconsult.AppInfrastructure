// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Reflection;
using Bodoconsult.App.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Bodoconsult.App
{
    /// <summary>
    /// Current implementation of <see cref="IAppConfigurationProvider"/>
    /// </summary>
    public class AppConfigurationProvider : IAppConfigurationProvider
    {

        /// <summary>
        /// Default ctor
        /// </summary>
        public AppConfigurationProvider()
        {
            var ass = Assembly.GetEntryAssembly();

            if (ass == null)
            {
                ass = GetType().Assembly;
            }

            var s = ass.Location;
            ConfigFilePath = new FileInfo(s).DirectoryName;
        }

        /// <summary>
        /// The file path to the config file. Default value is the current app path
        /// </summary>
        public string ConfigFilePath { get; set; }

        /// <summary>
        /// Name of the config file to use. Default: appsettings.json
        /// </summary>
        public string ConfigFile { get; set; } = "appsettings.json";

        /// <summary>
        /// Current configuration loaded from <see cref="IAppConfigurationProvider.ConfigFile"/>
        /// </summary>
        public IConfigurationRoot Configuration { get; private set; }

        /// <summary>
        /// Load <see cref="IAppConfigurationProvider.Configuration"/> from <see cref="IAppConfigurationProvider.ConfigFile"/>
        /// </summary>
        /// <returns>Config object</returns>
        public void LoadConfigurationFromConfigFile()
        {
            //#if DEBUG
            //            ConfigFile = File.Exists(Path.Combine(path, "appsettings.Development.json")) ?
            //                "appsettings.Development.json" :
            //                "appsettings.json";
            //#endif
            Configuration = new ConfigurationBuilder()
                .SetBasePath(ConfigFilePath)
                .AddJsonFile(ConfigFile)
                //.AddEnvironmentVariables()
                //.AddCommandLine(args)

                .Build();
        }

        /// <summary>
        /// Load the default connection from <see cref="IAppConfigurationProvider.Configuration"/> from section ConnectionStrings value DefaultConnection
        /// </summary>
        public string ReadDefaultConnection()
        {
            return Configuration?.GetSection("ConnectionStrings")["DefaultConnection"];
        }

        /// <summary>
        /// Read the logging section
        /// </summary>
        /// <returns>Logging section</returns>
        public IConfigurationSection ReadLoggingSection()
        {
            return Configuration?.GetSection("Logging");
        }

        /// <summary>
        /// Read a section by its name
        /// </summary>
        /// <param name="sectionName">Section name requested</param>
        /// <returns>Section</returns>
        public IConfigurationSection ReadConfigurationSection(string sectionName)
        {
            return Configuration?.GetSection(sectionName);
        }
    }
}