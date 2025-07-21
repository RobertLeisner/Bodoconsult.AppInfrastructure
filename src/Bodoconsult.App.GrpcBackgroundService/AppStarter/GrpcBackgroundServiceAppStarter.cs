// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

#region GRPC copyright notice and license

// Copyright 2019 The gRPC Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.GrpcBackgroundService.AppStarter
{
    /// <summary>
    /// <see cref="IAppStarter"/> implementation for a background service using GRPC
    /// </summary>
    public class GrpcBackgroundServiceAppStarter : Microsoft.Extensions.Hosting.BackgroundService, IAppStarter
    {
        private readonly IAppLoggerProxy _logger;

        public GrpcBackgroundServiceAppStarter(IAppLoggerProxy logger, IAppBuilder appBilder)
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

            //var task = Task.Run(Start, stoppingToken);
            Start();

            await Task.Run(() =>
            {
                while (true)
                {
                    var isStopped = stoppingToken.IsCancellationRequested;
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
            //AppBuilder.StartApplication();
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
