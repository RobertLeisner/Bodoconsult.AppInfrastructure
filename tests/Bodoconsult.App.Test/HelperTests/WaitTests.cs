// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.Helpers;

namespace Bodoconsult.App.Test.HelperTests;

[TestFixture]
public class WaitTests
{


    [Test]
    public void Until_PredicateAlwaysFalse_Timeout()
    {
        // Arrange 
        const int timeout = 4500;

        var watch = Stopwatch.StartNew();

        // Act  
        Wait.Until(() => false, timeout);
        watch.Stop();

        // Assert
        Assert.That(watch.ElapsedMilliseconds >= timeout);

    }


    [Test]
    public void Until_PredicateSetToTrue_SuccessfulBeforeTimeout()
    {
        // Arrange 
        const int timeout = 4500;

        var watch = Stopwatch.StartNew();

        // Act  
        Wait.Until(() => true, timeout);
        watch.Stop();

        // Assert
        Assert.That(watch.ElapsedMilliseconds < timeout);

    }


    [Test]
    public void Until_PredicateAlwaysFalseCheckNonBlockingBehaviourTaskDelay_Timeout()
    {
        // Arrange 
        const int timeout = 3500;
        const int runs = 15;
        var count = 0;

        var watch = Stopwatch.StartNew();

        var task = Task.Run(() =>
        {
            while (count < runs)
            {
                Debug.Print($"TaskID {Task.CurrentId}: run {count}");
                Task.Delay(500).Wait();
                count++;
            }

        });

        // Act  
        Debug.Print($"Start waiting TaskID {Task.CurrentId}");
        Wait.Until(() => false, timeout);
        Debug.Print("Waiting done");
        watch.Stop();

        task.Wait();
        Debug.Print("Task stopped");

        // Assert
        Assert.That(watch.ElapsedMilliseconds >= timeout);
        Assert.That(count, Is.EqualTo(runs));

    }

    [Test]
    public void Until_PredicateAlwaysFalseCheckNonBlockingBehaviourAsyncHelperDelay_Timeout()
    {
        // Arrange 
        const int timeout = 3500;
        const int runs = 15;
        var count = 0;

        var watch = Stopwatch.StartNew();

        var task = Task.Run(() =>
        {
            while (count < runs)
            {
                Debug.Print($"TaskID {Task.CurrentId}: run {count}");
                AsyncHelper.Delay(500);
                count++;
            }
        });

        // Act  
        Debug.Print($"Start waiting TaskID {Task.CurrentId}");
        Wait.Until(() => false, timeout);
        Debug.Print("Waiting done");
        watch.Stop();

        task.Wait();
        Debug.Print("Task stopped");

        // Assert
        Assert.That(watch.ElapsedMilliseconds >= timeout);
        Assert.That(count, Is.EqualTo(runs));

    }

    [Test]
    public void Until_PredicateAlwaysFalseCheckBlockingBehaviourThreadSleep_Timeout()
    {
        // Arrange 
        const int timeout = 3500;
        const int runs = 15;
        var count = 0;

        var watch = Stopwatch.StartNew();

        var task = Task.Run(() =>
        {

            var thread = $"ThreadId {Thread.CurrentThread.ManagedThreadId} TaskID {Task.CurrentId}: run";

            while (count < runs)
            {
                Debug.Print($"{thread} {count}");
                Thread.Sleep(500);
                count++;
            }
        });

        // Act  
        Debug.Print($"Start waiting ThreadId {Thread.CurrentThread.ManagedThreadId} TaskID {Task.CurrentId}");
        Wait.Until(() => false, timeout);
        Debug.Print("Waiting done");
        watch.Stop();

        task.Wait();
        Debug.Print("Task stopped");

        // Assert
        Assert.That(watch.ElapsedMilliseconds >= timeout);
        Assert.That(count, Is.EqualTo(runs));

    }
}

