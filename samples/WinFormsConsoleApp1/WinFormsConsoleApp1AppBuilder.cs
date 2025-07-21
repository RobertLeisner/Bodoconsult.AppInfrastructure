// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.WinForms.App;
using WinFormsConsoleApp1.DiContainerProvider;

namespace WinFormsConsoleApp1;

public class WinFormsConsoleApp1AppBuilder : BaseWinFormsAppBuilder
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="appGlobals">Global app settings</param>
    public WinFormsConsoleApp1AppBuilder(IAppGlobals appGlobals) : base(appGlobals)
    {

    }

    /// <summary>
    /// Load the <see cref="IAppBuilder.DiContainerServiceProviderPackage"/>
    /// </summary>
    public override void LoadDiContainerServiceProviderPackage()
    {
        var factory = new WinFormsConsoleApp1ProductionDiContainerServiceProviderPackageFactory(AppGlobals);
        DiContainerServiceProviderPackage = factory.CreateInstance();
    }
}