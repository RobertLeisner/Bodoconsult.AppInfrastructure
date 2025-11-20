// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using AvaloniaConsoleApp1.DiContainerProvider;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Avalonia.App;

namespace AvaloniaConsoleApp1;

public class AvaloniaConsoleApp1AppBuilder : BaseAvaloniaAppBuilder
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="appGlobals">Global app settings</param>
    public AvaloniaConsoleApp1AppBuilder(IAppGlobals appGlobals) : base(appGlobals)
    { }

    /// <summary>
    /// Load the <see cref="IAppBuilder.DiContainerServiceProviderPackage"/>
    /// </summary>
    public override void LoadDiContainerServiceProviderPackage()
    {
        var factory = new AvaloniaConsoleApp1ProductionDiContainerServiceProviderPackageFactory(AppGlobals);
        DiContainerServiceProviderPackage = factory.CreateInstance();
    }
}