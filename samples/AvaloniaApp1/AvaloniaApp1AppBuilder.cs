// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using AvaloniaApp1.AppData;
using AvaloniaApp1.DiContainerProvider;
using Bodoconsult.App;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Avalonia.App;
using System.Configuration;

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

    /// <summary>
    /// Process the configuration from <see cref="IAppStartParameter.ConfigFile"/>. Uses the <see cref="DefaultAppStartProvider"/>.
    /// </summary>
    public override void ProcessConfiguration()
    {
        // Load basic config
        base.ProcessConfiguration();

        // Now get the root comfiguration element
        var root = AppStartProvider.AppConfigurationProvider.Configuration;

        // Get your derived IAppGlobals instance here to access added properties
        var globals = (Globals)AppGlobals;

        // Now get the requested config elements out of the root config element
        globals.TestProperty = root?.GetSection("DemoSection")["TestProperty"];
    }
}