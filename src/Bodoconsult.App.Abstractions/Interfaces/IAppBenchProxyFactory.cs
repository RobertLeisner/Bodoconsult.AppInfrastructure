// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Microsoft.Extensions.Logging;

namespace Bodoconsult.App.Abstractions.Interfaces
{
    /// <summary>
    /// Interface for creating an instance of a <see cref="IAppBenchProxy"/> implementation logging data for benchmark viewer https://github.com/crep4ever/benchmark-viewer. Implementation by Freddy Darsonville
    /// </summary>
    public interface IAppBenchProxyFactory
    {
        /// <summary>
        /// Create an instance of a <see cref="IAppLoggerProxy"/> implementation
        /// </summary>
        /// <param name="benchProxyFactory">Current logger factory to use</param>
        /// <param name="logDataFactory">Current logdata factory. Should be singleton instance for loggers</param>
        /// <returns>An instance of a <see cref="IAppLoggerProxy"/></returns>
        IAppBenchProxy CreateInstance(ILoggerFactory benchProxyFactory, ILogDataFactory logDataFactory);

    }
}
