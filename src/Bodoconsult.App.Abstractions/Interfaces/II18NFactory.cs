// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Factory for creating an II18N instance
/// </summary>
public interface II18NFactory
{
    /// <summary>
    /// Creating a configured II18N instance
    /// </summary>
    /// <returns>An II18N instance</returns>
    II18N CreateInstance();

}