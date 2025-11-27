// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Concurrent;
using System.Diagnostics.Tracing;

namespace Bodoconsult.App.Abstractions.Interfaces;

public interface IAppEventListener: IDisposable
{
    /// <summary>
    /// Event level for the listener. Default: 
    /// </summary>
    EventLevel EventLevel { get; set; }

    /// <summary>
    /// Stores the log messages for later use
    /// </summary>
    ConcurrentQueue<string> Messages { get; }

}