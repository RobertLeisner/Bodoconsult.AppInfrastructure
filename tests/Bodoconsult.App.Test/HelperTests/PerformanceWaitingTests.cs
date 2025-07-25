// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.Helpers;

namespace Bodoconsult.App.Test.HelperTests;

[TestFixture]
[Explicit]
public class PerformanceWaitingTests
{

    [Test]
    public void WaitUntil_1ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 1;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        Wait.Until(() => false, timeout);
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"Wait: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void WaitUntil_5ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 5;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        Wait.Until(() => false, timeout);
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"Wait: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void WaitUntil_10ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 10;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        Wait.Until(() => false, timeout);
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"Wait: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void WaitUntil_1000ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 1000;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        Wait.Until(() => false, timeout);
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"Wait: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void WaitUntil_10000ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 10000;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        Wait.Until(() => false, timeout);
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"Wait: requested timeout {timeout} ms leads to runtime of {time} ms");
    }
        
    [Test]
    public void ThreadSleep_1ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 1;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        Thread.Sleep(timeout);
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"ThreadSleep: requested timeout {timeout} ms leads to runtime of {time} ms");
    }


    [Test]
    public void ThreadSleep_5ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 5;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        Thread.Sleep(timeout);
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"ThreadSleep: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void ThreadSleep_10ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 10;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        Thread.Sleep(timeout);
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"ThreadSleep: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void ThreadSleep_1000ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 1000;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        Thread.Sleep(timeout);
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"ThreadSleep: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void ThreadSleep_10000ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 10000;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        Thread.Sleep(timeout);
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"ThreadSleep: requested timeout {timeout} ms leads to runtime of {time} ms");
    }


    [Test]
    public void CancellationTokenSource_1ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 1;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        using (var cts = new CancellationTokenSource(timeout))
        {
            while (!cts.IsCancellationRequested)
            {
                Thread.Sleep(1);
            }
        }
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"CancellationTokenSource: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void CancellationTokenSource_5ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 5;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        using (var cts = new CancellationTokenSource(timeout))
        {
            while (!cts.IsCancellationRequested)
            {
                Thread.Sleep(1);
            }
        }
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"CancellationTokenSource: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void CancellationTokenSource_10ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 10;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        using (var cts = new CancellationTokenSource(timeout))
        {
            while (!cts.IsCancellationRequested)
            {
                Thread.Sleep(1);
            }
        }
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"CancellationTokenSource: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void CancellationTokenSource_1000ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 1000;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        using (var cts = new CancellationTokenSource(timeout))
        {
            while (!cts.IsCancellationRequested)
            {
                Thread.Sleep(1);
            }
        }
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"CancellationTokenSource: requested timeout {timeout} ms leads to runtime of {time} ms");
    }

    [Test]
    public void CancellationTokenSource_10000ms_RuntimeMeasured()
    {
        // Arrange 
        const int timeout = 10000;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        // Act  
        using (var cts = new CancellationTokenSource(timeout))
        {
            while (!cts.IsCancellationRequested)
            {
                Thread.Sleep(1);
            }
        }
        stopWatch.Stop();

        // Assert
        var time = stopWatch.ElapsedMilliseconds;

        Assert.That(time, Is.Not.EqualTo(0));
        Debug.Print($"CancellationTokenSource: requested timeout {timeout} ms leads to runtime of {time} ms");
    }
}