// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Interfaces;

/// <summary>
/// Interface for implementing for protecting the whole file content
/// </summary>
public interface IFileProtectionService
{
    /// <summary>
    /// Protect unprotected data
    /// </summary>
    /// <param name="data">Unprotected data</param>
    /// <returns>Protected data</returns>
    byte[] Protect(byte[] data);

    /// <summary>
    /// Unprotect protected data
    /// </summary>
    /// <param name="data">Protected data</param>
    /// <returns>Unprotected</returns>
    byte[] Unprotect(byte[] data);
}