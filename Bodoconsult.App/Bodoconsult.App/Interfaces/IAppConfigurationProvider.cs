// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Microsoft.Extensions.Configuration;

namespace Bodoconsult.App.Interfaces;

public interface IAppConfigurationProvider
{

    /// <summary>
    /// The file path to the config file
    /// </summary>
    string ConfigFilePath { get; set; }


    /// <summary>
    /// Name of the config file to use. Default: appsettings.json
    /// </summary>
    string ConfigFile { get; set; }

    /// <summary>
    /// Current configuration loaded from <see cref="ConfigFile"/>
    /// </summary>
    IConfigurationRoot Configuration { get; }

    /// <summary>
    /// Load <see cref="Configuration"/> from <see cref="ConfigFile"/>
    /// </summary>
    /// <returns>Config object</returns>
    void LoadConfigurationFromConfigFile();

    /// <summary>
    /// Load the default connection from <see cref="Configuration"/> from section ConnectionStrings value DefaultConnection
    /// </summary>
    string ReadDefaultConnection();

    /// <summary>
    /// Read the logging section
    /// </summary>
    /// <returns>Logging section</returns>
    IConfigurationSection ReadLoggingSection();

    /// <summary>
    /// Read a section by its name
    /// </summary>
    /// <param name="sectionName">Section name requested</param>
    /// <returns>Section</returns>
    IConfigurationSection ReadConfigurationSection(string sectionName);
}