// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using AvaloniaApp1.DiContainerProvider;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Avalonia.App;

namespace AvaloniaApp1;

public class AvaloniaApp1AppBuilder : BaseAvaloniaAppBuilder
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="appGlobals">Global app settings</param>
    public AvaloniaApp1AppBuilder(IAppGlobals appGlobals) : base(appGlobals)
    { }

    /// <summary>
    /// Load the <see cref="IAppBuilder.DiContainerServiceProviderPackage"/>
    /// </summary>
    public override void LoadDiContainerServiceProviderPackage()
    {
        var factory = new AvaloniaApp1ProductionDiContainerServiceProviderPackageFactory(AppGlobals);
        DiContainerServiceProviderPackage = factory.CreateInstance();
    }
}