# What does the library

Bodoconsult.App is a library with basic functionality for multilayered monolithic applications like database based client server apps. 
It delivers the following main functionality:

1. App start infrastructure for console apps
1. Single-threaded high-performance logging for single-threaded or multi-threaded environments (IAppLoggerProxy / AppLoggerProxy )
2. Basic watchdog implementation IWatchDog / WatchDog as replacement for timers for non-time critical tasks
3. Application perfromance measurement (APM) tools for performnce logging
4. Business transactions to simplify transportation layer implementations for  technologies like GRPC, WebAPI, etc...
5. ProducerConsumerQueue/<T/> implementing the producer-consumer-pattern for one or many producers but only one consumer.


# How to use the library

The source code contains NUnit test classes the following source code is extracted from. The samples below show the most helpful use cases for the library.

# App start infrastructure for console and Winforms apps

See page [app start infrastructure](AppStartInfrastructure.md) for details.

## IAppLoggerProxy / AppLoggerProxy

AppLoggerProxy is a high performance logger infrastructure for multithreaded and or multitasked apps with low resulting garbage pressure. 

Log entries are stored to a intermediate queue and then processed on a single thread during app runtime using a IWatchdog implementation. This avoids file access errors resulting from different threads trying to access the destinantion log at the same time.

To reduce garbage pressure log entries are reused. Therefore you should use a singelton instance of a LogDataFactory for the whole app. You can store this singleton instance i.e. in a singleton IAppGlobals instance for your app.

Each instance of IAppLoggerProxy is representing a separate logging target.

Log entries are written to the logging target in a single threaded way to avoid trouble with accessing log file from multiple threads.

### Supported logging targets

IAppLoggerProxy supports the following logging targets by default:

-   Log4Net

-   Console

-   Debug window (only in debug mode)

-   Eventlog

-   EventSource (to use log entries in the app itself i.e. for showing it in a GUI)

This logging targets can be activated seperately or in a combined manor. Combine Log4Net and EventSource in appsettings.json if you want to log to a file and to the GUI at the same time for example.

### Configuring central app logging in appsettings.json

Central app logging with IAppLoggerProxy can be configured in the appsettings.json file. See  a typical example here:

``` json

{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(LocalDB)\\MSSQLLocalDb;Initial Catalog=XYDatabase;Integrated Security=true;MultipleActiveResultSets=True;App=ConsoleApp1"
  },
  "Logging": {
    "MinimumLogLevel": "Debug",
    "LogLevel": {
      "Default": "Information",
      "System": "Information",
      "Microsoft": "Information",
      "Microsoft.EntityFrameworkCore": "Warning"
    },
    "Log4Net": {
      "LogLevel": {
        "Default": "Debug"
      }
    },
    //"Console": {
    //  "IncludeScopes": true,
    // "DisableColors": false
    //},
    //, "EventLog": {
    // "SourceName": "MyApp"
    // "LogName": "MyLogName"
    // "MachineName": "MyMachineName"
    //},
    "Debug": {
      "LogLevel": {
        "Default": "Debug"
      }
    },
    "EventSource": {
      "LogLevel": {
        "Default": "Error"
      }
    }
  }
}

``` 

### Configuring other loggers 

#### Creating multiple logfiles

If you want to setup multiple logfiles for your app for example per device the app handles you can create multiple instances of IAppLoggerProxy. See class MonitorLoggerFactory. It takes a full path for the logfile to log in and the other settings from log4net.config.

#### Using log4net as logger

If you want to use log4net for logging you can use the Log4NetLoggerFactory. 

``` csharp

var logger = new AppLoggerProxy(new Log4NetLoggerFactory.(), Globals.LogDataFactory);

_log.LogWarning("Hallo");
			
```

You can configure the logger with a log4net.config file in the project main folder. See log4net documentation for details.

#### Fake logger for unit tests 

For unit tests you can use a fake implementation of a logger. It logs to the output window only.

``` csharp

var logger = new AppLoggerProxy(new FakeLoggerFactory(), Globals.LogDataFactory);

_log.LogWarning("Hallo");
			
```


## IWatchDog / WatchDog

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


## BufferPool\<T\>

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

## Performance logging

See page [Performance logging](PerformanceLogging.md) for details.


## Business transactions

See page [Business transactions](BusinessTransactions.md) for details.


## ProducerConsumerQueue/<T/>

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




## IExceptionReplyBuilder / ExceptionReplyBuilder

ExceptionReplyBuilder delivers a central exception management to be used standalone or in conjunction with business transactions.

ToDo: add more information

# About us

Bodoconsult <http://www.bodoconsult.de> is a Munich based software company from Germany.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

