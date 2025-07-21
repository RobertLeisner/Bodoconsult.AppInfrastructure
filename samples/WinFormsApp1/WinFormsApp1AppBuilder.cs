// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.WinForms.App;
using WinFormsApp1.DiContainerProvider;

namespace WinFormsApp1;

public class WinFormsApp1AppBuilder : BaseWinFormsAppBuilder
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="appGlobals">Global app settings</param>
    public WinFormsApp1AppBuilder(IAppGlobals appGlobals) : base(appGlobals)
    {

    }

    /// <summary>
    /// Load the <see cref="IAppBuilder.DiContainerServiceProviderPackage"/>
    /// </summary>
    public override void LoadDiContainerServiceProviderPackage()
    {
        var factory = new WinFormsApp1ProductionDiContainerServiceProviderPackageFactory(AppGlobals);
        DiContainerServiceProviderPackage = factory.CreateInstance();
    }
}