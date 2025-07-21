// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Factory for <see cref="LogData"/> instances
/// </summary>
public interface ILogDataFactory
{
    /// <summary>
    /// The current number of instances in the <see cref="LogData"/> buffer pool
    /// </summary>
    int CurrentNumberOfInstancesInPool { get; }

    /// <summary>
    /// Allocate the buffer pool
    /// </summary>
    /// <param name="numberOfInstances">Number of instances to pre-allocate in the buffer pool</param>
    void AllocateBufferPool(int numberOfInstances);

    /// <summary>
    /// Dequeue an instance of <see cref="LogData"/> to use it for logging
    /// </summary>
    /// <returns>Instance of <see cref="LogData"/></returns>
    LogData DequeueInstance();

    /// <summary>
    /// Reset the logdata entity and give it back to pool
    /// </summary>
    /// <param name="logData"></param>
    void EnqueueInstance(LogData logData);
}