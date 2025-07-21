// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Interface for Benchmark Viewer logging entities
/// </summary>
public interface IBench: IDisposable
{
    /// <summary>
    /// Start benchmark
    /// </summary>
    /// <param name="comment"></param>
    void Start(string comment);

    /// <summary>
    /// Stop benchmark
    /// </summary>
    /// <param name="comment"></param>
    void Stop(string comment);

    /// <summary>
    /// Add Step benchmark
    /// </summary>
    /// <param name="comment"></param>
    void AddStep(string comment);

}