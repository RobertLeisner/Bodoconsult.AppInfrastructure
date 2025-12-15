// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Abstractions.DependencyInjection;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.BackgroundService.AppStarter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bodoconsult.App.BackgroundService.App;

/// <summary>
/// Base class for <see cref="IAppBuilder"/> implementations running a background service but not using GRPC
/// </summary>
public class BaseBackgroundServiceAppBuilder: BaseAppBuilder
{

    private readonly HostApplicationBuilder _builder;
    private IHost _host;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="appGlobals">Current app globals</param>
    /// <param name="args">Current app args from command line</param>
    public BaseBackgroundServiceAppBuilder(IAppGlobals appGlobals, string[] args = null) : base(appGlobals)
    {
        // Prepare the service builder instance
        _builder = Host.CreateApplicationBuilder(args);
        AppGlobals.DiContainer = new DiContainer(_builder.Services);
    }

    /// <summary>
    /// Register DI container services
    /// </summary>
    public override void RegisterDiServices()
    {
        DiContainerServiceProviderPackage.AddServices(AppGlobals.DiContainer);

        AppGlobals.DiContainer.AddSingleton((IAppBuilder)this);
    }

    /// <summary>
    /// Start the application
    /// </summary>
    public override void StartApplication()
    {
        _builder.Services.AddHostedService<BackgroundServiceAppStarter>();

        _host = _builder.Build();
        AppGlobals.DiContainer.LoadServiceProvider(_host.Services);

        DiContainerServiceProviderPackage.LateBindObjects(AppGlobals.DiContainer);
            

        StartApplicationService();

        _host.Run();
    }

    /// <summary>
    /// Stops the application
    /// </summary>
    public override void StopApplication()
    {
        AppGlobals.EventWaitHandle?.Reset();
        ApplicationServer?.StopApplication();
        _host?.StopAsync();
    }

}