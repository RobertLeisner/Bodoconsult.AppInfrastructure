// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Interfaces;

/// <summary>
/// Basic interface for data protection implementations
/// </summary>
public interface IDataProtectionService
{
    /// <summary>
    /// Store a value in a safe manner
    /// </summary>
    /// <param name="key">Key name for the value</param>
    /// <param name="value">Value to store</param>
    string Protect(string key, string value);

    /// <summary>
    /// Load a value stored in a safe manner
    /// </summary>
    /// <param name="key">Key name for the value</param>
    /// <param name="cipherValue">The encrypted value to decrypt</param>
    string Unprotect(string key, string cipherValue);
}