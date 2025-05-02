// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.DependencyInjection;
using Bodoconsult.App.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bodoconsult.App.BackgroundService.App
{
    /// <summary>
    /// Base class for <see cref="IAppBuilder"/> implementations running a background service
    /// </summary>
    public class BaseBackgroundServiceAppBuilder: BaseAppBuilder
    {

        private readonly HostApplicationBuilder _builder;
        private IHost host;

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

            host = _builder.Build();
            AppGlobals.DiContainer.LoadServiceProvider(host.Services);

            DiContainerServiceProviderPackage.LateBindObjects(AppGlobals.DiContainer);
            

            StartApplicationService();

            host.Run();
        }

        /// <summary>
        /// Stops the application
        /// </summary>
        public override void StopApplication()
        {
            AppGlobals.EventWaitHandle?.Reset();
            ApplicationServer?.StopApplication();
            host?.StopAsync();
        }

    }
}
