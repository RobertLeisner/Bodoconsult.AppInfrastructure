// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.I18N.DependencyInjection;

/// <summary>
/// Base class for a II18NFactory instancing a singleton I18NMock instance.
/// </summary>
public class BaseI18NMockFactory : II18NFactory
{
    /// <summary>
    /// Current <see cref="II18N"/> instance
    /// </summary>
    protected II18N I18NInstance;
    
    /// <summary>
    /// Default ctor
    /// </summary>
    public BaseI18NMockFactory()
    {
        I18NInstance = I18NMock.Current;
    }

    /// <summary>
    /// Creating a configured II18N instance
    /// </summary>
    /// <returns>An II18N instance</returns>
    public II18N CreateInstance()
    {
        return I18NInstance;
    }
}