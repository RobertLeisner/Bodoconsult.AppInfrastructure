﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Benchmarking;

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Interface for a factory based on <see cref="BenchReusable"/> handling one bench log file with a separate buffer pool for reusing <see cref="BenchReusable"/> instances
/// </summary>
public interface IAppBenchReusableFactory
{
    /// <summary>
    /// Create a fresh <see cref="BenchReusable"/> instance
    /// </summary>
    /// <param name="key">Key to identify the nechmarked object in the CSV file or Benchmark Viewer</param>
    /// <param name="comment">Your comment if required</param>
    /// <param name="autoStart">Start automatically</param>
    BenchReusable CreateInstance(string key, string comment = "", bool autoStart = true);

    /// <summary>
    /// Pre-allocate a certain number of <see cref="BenchReusable"/> instances stored in the pool
    /// </summary>
    /// <param name="numberOfInstances">Number of <see cref="BenchReusable"/> instances stored in the pool</param>
    void Allocate(int numberOfInstances);

    /// <summary>
    /// Queue a used <see cref="BenchReusable"/> instance back to the buffer pool
    /// </summary>
    /// <param name="buffer">Reusable <see cref="BenchReusable"/> instance to store in the pool</param>
    void Enqueue(BenchReusable buffer);

}