// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
///  Interface for factories creating IDataProtectionService instances
/// </summary>
public interface IDataProtectionServiceFactory
{
    /// <summary>
    /// Create an IDataProtectionService instance
    /// </summary>
    /// <param name="destinationFolderPath">Destination folder path to store the data protection key infrastructure in</param>
    /// <param name="appName">App name</param>
    /// <returns>IDataProtectionService instance</returns>
    IDataProtectionService CreateInstance(string destinationFolderPath, string appName);
}