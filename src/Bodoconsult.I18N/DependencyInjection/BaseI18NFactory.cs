// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.I18N.DependencyInjection;

/// <summary>
/// Base class for a II18NFactory instancing a singleton I18N instance. Access this instance with property I18NInstance when overriding CreateInstance() method
/// </summary>
public class BaseI18NFactory : II18NFactory
{

    protected II18N I18NInstance;


    /// <summary>
    /// Default ctor
    /// </summary>
    public BaseI18NFactory()
    {
        I18NInstance = I18N.Current;
    }

    /// <summary>
    /// Creating a configured II18N instance. Access this II18N instance with property I18NInstance when overriding CreateInstance() method
    /// </summary>
    /// <returns>An II18N instance</returns>
    public virtual II18N CreateInstance()
    {
        throw new System.NotSupportedException("Overload this method to configure your I18N instance");
    }
}