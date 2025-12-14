# Performance logging

Performance logging infrastructure is implemented based on the https://learn.microsoft.com/en-us/dotnet/core/diagnostics/. 
So it can be used with professionell APM tools like Application Insights, dotnet-counters, and dotnet-monitor.

## IAppEventSource / AppEventSource

Event counters are a platform independent feature of .NET to implement application performance measurement. They are directly supported by Visual Studio, Application Insights, dotnet-counters and dotnet-monitor.

For basic information on event counters see [Microsoft diagnostics: Metrics](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/metrics, "Microsoft diagnostics: Metrics").

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
    /// Add the <see cref="PollingCounter"/> to the event source
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

The IPerformanceLogger implementations read performance counters and provide them as formatted string. PerformanceLogger class read main event counters provided by .NET runtime. It is intended to be used from inside the application.


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