// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Interfaces;
using Microsoft.Extensions.Logging;

namespace Bodoconsult.App.Benchmarking
{

    /// <summary>
    /// Factory for creating <see cref="AppBenchProxy"/> instances logging data for benchmark viewer https://github.com/crep4ever/benchmark-viewer. Implementation by Freddy Darsonville
    /// </summary>
    public class AppBenchProxyFactory : IAppBenchProxyFactory
    {
        /// <summary>
        /// Create an instance of a <see cref="IAppLoggerProxy"/> implementation
        /// </summary>
        /// <param name="benchProxyFactory">Current logger factory to use</param>
        /// <param name="logDataFactory">Current logdata factory. Should be singleton instance for loggers</param>
        /// <returns>An instance of a <see cref="IAppLoggerProxy"/></returns>
        public IAppBenchProxy CreateInstance(ILoggerFactory benchProxyFactory, ILogDataFactory logDataFactory)
        {
            return new AppBenchProxy(benchProxyFactory, logDataFactory);
        }
    }
}
