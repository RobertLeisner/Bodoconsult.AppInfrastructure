More tools for developers
=============

# Overview

> [Basic watchdog implementation IWatchDog / WatchDog as replacement for timers for non-time critical tasks](#iwatchdog--watchdog)

> [BufferPool\<T\> for reusing frequently used tiny to medium size classes](#bufferpoolt)

> [ProducerConsumerQueue/<T/> implementing the producer-consumer-pattern for one or many producers but only one consumer](#producerconsumerqueue)

> [DataProtectionManager for protecting secrets like credentials](#dataprotectionmanager-for-protecting-secrets-like-credentials)


# IWatchDog / WatchDog

WatchDog is something similar to a timer. Timers do have the potential issue with multiple running tasks if tasks may run longer than the timer interval. 
So if your timer task will potentially run longer then the timer interval you should think about using IWatchDog implementations.

The runner method is fired and processed until done. Then the watchdog waits for the delay interval until it restarts the runner method.

For time critical tasks WatchDog is not a good solution. If you have to ensure that your task is running i.e. every minute exactly, you better should use a Timer.

The runner method is running always on the same separated background thread.


``` csharp
WatchDogRunnerDelegate runner = Runner;

var w = new WatchDog(runner, delayTime);
w.StartWatchDog();
...

w.StopWatchDog();		
```

``` csharp
/// <summary>
/// Runner method for the watchdog
/// </summary>
private void Runner()
{
    // Do your tasks here
}
```


# BufferPool\<T\>

BufferPool\<T\> is used to handle and reuse multiple instances of potentially small objects of a type to reduce garbage pressure.

Heavily used small objects of a type lead to a relatively high demand for object creation and disposing. In such cases it might be a good idea to reuse the already created instances.

Classes used with BufferPool\<T\> should implement IResetable interface.

``` csharp
// Arrange 

var myPool = new BufferPool<byte[]>(() => new byte[65535]);
myPool.Allocate(1000);

var buffer = myPool.Dequeue();

// Act  
myPool.Enqueue(buffer);

// Assert
Assert.That(myPool.LengthOfQueue, Is.EqualTo(NumberOfItems));
```

# ProducerConsumerQueue/<T/>

ProducerConsumerQueue/<T/> implements the producer-consumer-pattern for one or many producers but only one consumer. This may be helpful if the consumer is maybe a database or a file which should not be accessed by multiple threads at the same time.

``` csharp
const string s1 = "Blubb";
const string s2 = "Blabb";
const string s3 = "Blobb";

var pc = new ProducerConsumerQueue<string>();
pc.ConsumerTaskDelegate = ConsumerTaskDelegate;
pc.StartConsumer();

// Act  
pc.Enqueue(s1);
pc.Enqueue(s2);
pc.Enqueue(s3);

// Assert
Wait.Until(() => _counter > 0);
Assert.That(_counter, Is.EqualTo(3));
Assert.That(_received.Count, Is.EqualTo(3));
Assert.That(_received.Contains(s1), Is.True);
Assert.That(_received.Contains(s2), Is.True);
Assert.That(_received.Contains(s3), Is.True);

...

private void ConsumerTaskDelegate(string value)
{
    _counter++;
    _received.Add(value);
    _wasFired = true;
}
```

# DataProtectionManager for protecting secrets like credentials

DataProtectionManager implements a file based solution for save storage of sensitive data based on Microsoft.AspNetCore.DataProtection to be used in console apps etc. without the need of more sophisticated tools like Azure Vault etc..

``` csharp
[Test]
public void Unprotect_ValidSetup_SecretUnprotectedCorrectly()
{
    // Arrange 
    var path = Globals.Instance.AppStartParameter.DataPath;
    var instance = DataProtectionService.CreateInstance(path, AppName);

    var filePath = Path.Combine(path, $"appData.{Extension}");
    if (File.Exists(filePath))
    {
        File.Delete(filePath);
    }

    var dpm = new DataProtectionManager(instance, FileProtectionService, filePath);

    dpm.Protect(Key, Secret);

    // Act  
    var result = dpm.Unprotect(Key);

    // Assert
    Assert.That(result, Is.EqualTo(Secret));
    dpm.Dispose();
}
```

# IExceptionReplyBuilder / ExceptionReplyBuilder

ExceptionReplyBuilder delivers a central exception management to be used standalone or in conjunction with business transactions.

ToDo: add more information
