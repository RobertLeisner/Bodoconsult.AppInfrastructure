// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.BackgroundService.AppStarter
{
    /// <summary>
    /// <see cref="IAppStarter"/> implementation for a background service NOT using GRPC
    /// </summary>
    public class BackgroundServiceAppStarter : Microsoft.Extensions.Hosting.BackgroundService, IAppStarter
    {
        private readonly IAppLoggerProxy _logger;

        public BackgroundServiceAppStarter(IAppLoggerProxy logger, IAppBuilder appBilder)
        {
            _logger = logger;
            AppBuilder = appBilder;
            AppBuilder.LoadAppStarterUi( this);
        }

        /// <summary>
        /// This method is called when the <see cref="T:Microsoft.Extensions.Hosting.IHostedService" /> starts. The implementation should return a task that represents
        /// the lifetime of the longrunning operation(s) being performed.
        /// </summary>
        /// <param name="stoppingToken">Triggered when <see cref="M:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" /> is called.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that represents the longrunning operations.</returns>
        /// <remarks>See <see href="https://learn.microsoft.com/dotnet/core/extensions/workers">Worker Services in .NET</see> for implementation guidelines.</remarks>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var task = Task.Run(Start, stoppingToken);

            await Task.Run(() =>
            {
                while (true)
                {
                    var isStopped = stoppingToken.IsCancellationRequested
                                    || task.IsCompleted
                                    || task.IsCanceled ||
                                    task.IsFaulted
                        ;
                    if (isStopped)
                    {
                        break;
                    }
                    Task.Delay(1000);
                }

                return true;
            });

            AppBuilder.StopApplication();
        }

        /// <summary>
        /// The current app start process handler
        /// </summary>
        public IAppBuilder AppBuilder { get; }

        /// <summary>
        /// Start the app
        /// </summary>
        public void Start()
        {
            AppBuilder.StartApplication();
        }

        public void TerminateAppWithMessage(string message, string appTitle)
        {
            
        }

        public void HandleException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
