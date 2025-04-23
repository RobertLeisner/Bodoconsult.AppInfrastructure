# What does the library

Bodoconsult.App is a library with basic functionality for multilayered monolithic applications like database based client server apps. 
It delivers the following main functionality:

1. Single-threaded high-performance logging for single-threaded or multi-threaded environments (IAppLoggerProxy / AppLoggerProxy )
2. Basic watchdog implementation IWatchDog / WatchDog as replacement for timers for non-time critical tasks
3. Infrastructure for handling event counts for application performance measurement (IAppEventSource / AppEventSource)
4. Using PerformanceCounters to log application performance metrics (IPerformanceLogger / PerformanceLogger and IPerformanceLoggerManager / PerformanceLoggerManager) 


# How to use the library

The source code contains NUnit test classes the following source code is extracted from. The samples below show the most helpful use cases for the library.

## IAppLoggerProxy / AppLoggerProxy

AppLoggerProxy is a high performance logger infrastructure for multithreaded and or multitasked apps. 
Log entries are stored to a intermediate queue and then processed on a single thread during app runtime using a IWatchdog implementation. 
This avoids file access errors resulting from different threads trying to access the destinantion log at the same time.

### Using log4net as logger

If you want to use log4net for logging you can use the Log4NetLoggerFactory. 

``` csharp

            var logger = new AppLoggerProxy(new Log4NetLoggerFactory.());
			
			_log.LogWarning("Hallo");
			
```

You can configure the logger with a log4net.config file in the project main folder. See log4net documentation for details.



### Fake logger for unit tests 

For unit tests you can use a fake implementation of a logger. It logs to the output window only.

``` csharp

            var logger = new AppLoggerProxy(new FakeLoggerFactory());
			
			_log.LogWarning("Hallo");
			
```


## IWatchDog / WatchDog

WatchDog is a replacement for timers. Timers do have the potential issue with multiple runnings tasks if tasks may run longer than the timer interval. 
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

## IAppEventSource / AppEventSource

Event counters are a platform independent feature of .NET to implement application performance measurement. 
For basic information on ecvent counters see [Microsoft: basics on event counters](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/event-counter-perf, "Microsoft: basics on event counters").

The implementations of IAppEventSource like AppEventSource deliver basic infrastructure for adding event counters to an app as easily as possible. 

To define event counters for your app implement one or more IEventSourceProvider based instances an load them into IAppEventSource implementations via IAppEventSource.AddProvider. 
Using multiple providers is recommend if your requires certain event counters only under certain circumstances.

As example see the implemtation of the BusinessTransactionEventSourceProvider:

``` csharp

/// <summary>
/// Provider for business transaction management relevante event counters
/// </summary>
public class BusinessTransactionEventSourceProvider: IEventSourceProvider
{
    public const string BtmRunBusinessTransactionSuccess = "Btm.RunBusinessTransaction.Success";

    public const string BtmRunBusinessTransactionDuration = "Btm.RunBusinessTransaction.Duration";

    /// <summary>
    /// Add <see cref="EventCounter"/> to the event source
    /// </summary>
    /// <param name="eventSource">Current event source</param>
    public void AddEventCounters(AppApmEventSource eventSource)
    {
        CreateBtRunTransactionDurationEventCounter(eventSource);
    }

    private void CreateBtRunTransactionDurationEventCounter(AppApmEventSource eventSource)
    {
        var ec = new EventCounter(BtmRunBusinessTransactionDuration, eventSource);
        ec.DisplayName = "Business transaction duration";
        ec.DisplayUnits = "ms";

        eventSource.EventCounters.Add(BtmRunBusinessTransactionDuration, ec);
    }


    /// <summary>
    /// Add <see cref="IncrementingEventCounter"/> to the event source
    /// </summary>
    /// <param name="eventSource">Current event source</param>
    public void AddIncrementingEventCounters(AppApmEventSource eventSource)
    {
        CreateRunBtSuccessIncrementEventCounter(eventSource);
    }

    private void CreateRunBtSuccessIncrementEventCounter(AppApmEventSource eventSource)
    {
        var ec = new IncrementingEventCounter(BtmRunBusinessTransactionSuccess, eventSource);
        ec.DisplayName = "Business transaction running successfully";
        ec.DisplayUnits = "runs";

        eventSource.IncrementingEventCounters.Add(BtmRunBusinessTransactionSuccess, ec);
    }

    /// <summary>
    /// Add e<see cref="PollingCounter"/> to the event source
    /// </summary>
    /// <param name="eventSource">Current event source</param>
    public void AddPollingCounters(AppApmEventSource eventSource)
    {
        // Do nothing
    }

    /// <summary>
    /// Add <see cref="IncrementingPollingCounter"/> to the event source
    /// </summary>
    /// <param name="eventSource">Current event source</param>
    public void AddIncrementingPollingCounters(AppApmEventSource eventSource)
    {
        // Do nothing
    }
}

```

## IPerformanceLogger / PerformanceLogger

The IPerformanceLogger implementations read performance counters and provide them as formatted string. PerformanceLogger class read main event counters provided by .NET runtime.

``` csharp

            // Arrange 
            var logger = new PerformanceLogger();

            // Act  
            var s = logger.GetCountersAsString();

            // Assert
            Assert.That(!string.IsNullOrEmpty(s));
            Debug.Print(s);

```

## IPerformanceLoggerManager / PerformanceLoggerManager

The IPerformanceLoggerManager implementations are intended to fetch performance counter data from IPerformanceLogger implementations in a scheduled manner 
and provide it as string to a delegate for further usage like logging.

``` csharp

        var logger = new PerformanceLogger();

        var manager = new PerformanceLoggerManager(logger)
        {
            StatusMessageDelegate = StatusMessageDelegate
        };

        Assert.That(manager);
        Assert.That(manager.PerformanceLogger);

        // Act  
        manager.StartLogging();

```

## IBusinessTransactionManager / IBusinessTransactionManager 

A business transaction is defined here as an external call for a certain functionality of an app by a UI client, webservice or any other client of the app. IBusinessTransactionManager is intended as central point for inbound business transactions for the app.

IBusinessTransactionManager delivers central features like logging and performance measurement for business transaction.

ToDo: add more information

## IExceptionReplyBuilder / ExceptionReplyBuilder

ExceptionReplyBuilder delivers a central exception management to be used standalone or in conjunction with business transactions.

ToDo: add more information

# About us

Bodoconsult <http://www.bodoconsult.de> is a Munich based software company from Germany.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

