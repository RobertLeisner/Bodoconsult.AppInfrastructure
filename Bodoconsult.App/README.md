# What does the library

Bodoconsult.App is a library with basic functionality for multilayered monolithic applications like database based client server apps. 
It delivers the following main functionality:

1. App start infrastructure for console apps
1. Single-threaded high-performance logging for single-threaded or multi-threaded environments (IAppLoggerProxy / AppLoggerProxy )
2. Basic watchdog implementation IWatchDog / WatchDog as replacement for timers for non-time critical tasks
3. Infrastructure for handling event counts for application performance measurement (IAppEventSource / AppEventSource)
4. Using PerformanceCounters to log application performance metrics (IPerformanceLogger / PerformanceLogger and IPerformanceLoggerManager / PerformanceLoggerManager) 


# How to use the library

The source code contains NUnit test classes the following source code is extracted from. The samples below show the most helpful use cases for the library.

## App start infrastructure for console and Winforms apps

The Bodoconsult.App contains the infrstructure to set up a console with commonly used features like

-   Reading appsettings.json, keep it in memory for later usage and extract connection string and logging settings from it

-   Setup a central logger

-   Setup DI containers for production and testing environment

-   Start the console app and run workload in a separate thread

### App start infrastructure for console apps

Here a sample from Program.cs Main() how to setup the console app in project ConsoleApp1. contained in this repo:


``` csharp

            // Prepare basic information needed for preparing the app start
            var s = typeof(Program).Assembly.Location;
            var path = new FileInfo(s).DirectoryName;
            var configFile = "appsettings.json";

#if DEBUG
            // Load app settings from dev app settings file in DEBUG mode
            if (File.Exists(Path.Combine(path, "appsettings.Development.json")))
            {
                configFile = "appsettings.Development.json";
            }
#endif

            // Now prepare the app start
            var provider = new DefaultAppStartProvider
            {
                ConfigFile = configFile
            };

            provider.LoadConfigurationProvider();
            provider.LoadAppStartParameter();

            // Set additional app start parameters as required
            var param = provider.AppStartParameter;
            param.AppName = "ConsoleApp1: Demo app";
            param.SoftwareTeam = "Robert Leisner";
            param.LogoRessourcePath = "ConsoleApp1.Resources.logo.jpg";
            param.AppFolderName = "ConsoleApp1";

            provider.LoadDefaultAppLoggerProvider();
            provider.SetValuesInAppGlobal(Globals.Instance);

            // Write first log entry with default logger
            Globals.Instance.Logger.LogInformation($"{provider.AppStartParameter.AppName} {provider.AppStartParameter.AppVersion} starts...");
            Console.WriteLine("Logging started...");

            // App is ready now for doing something
            //Console.WriteLine("Preparing app start done. To proceed press any key");
            //Console.ReadLine();

            Console.WriteLine($"Connection string loaded: {provider.AppStartParameter.DefaultConnectionString}");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"App name loaded: {provider.AppStartParameter.AppName}");
            Console.WriteLine($"App version loaded: {provider.AppStartParameter.AppVersion}");
            Console.WriteLine($"App path loaded: {provider.AppStartParameter.AppPath}");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"Logging config: {ObjectHelper.GetObjectPropertiesAsString(Globals.Instance.LoggingConfig)}");

            //Console.WriteLine("To proceed press any key");
            //Console.ReadLine();

            var factory = new ConsoleApp1ProductionDiContainerServiceProviderPackageFactory(Globals.Instance);
            IApplicationServiceHandler startProcess = new ApplicationServiceHandler(factory);

            const string performanceToken = "--PERF";

            if (args.Contains(performanceToken))
            {
                startProcess.AppGlobals.AppStartParameter.IsPerformanceLoggingActivated = true;
            }


            IAppStarterUi appStarter = new ConsoleAppStarterUi(startProcess)
                {
                    MsgHowToShutdownServer = UiMessages.MsgHowToShutdownServer,
                    MsgConsoleWait = UiMessages.MsgAppIsReady,
                };

            
            // Run as singleton app
            if (appStarter.IsAnotherInstance)
            {
                Console.WriteLine($"Another instance of {param.AppName} is already running! Press any key to proceed!");
                Console.ReadLine();
                Environment.Exit(0);
                return;
            }

#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
#endif

            appStarter.Start();

            appStarter.Wait();

            
            Environment.Exit(0);

```

To run your own workload simply start adjusting method StartApplication in ConsoleApp1Service class.

### App start infrastructure for  WIN service like WinForms based apps

If you want to implement a OS service like application without implementing a real OS service you can use WinFormsStarterUi class. 

By default WinFormsStarterUi class loads the app as a simple window not shown on Windows task bar but task tray. The app can be closed only with keys STRC + C / CTRL + C or from task tray.

Here a sample from Program.cs Main() how to setup the console app in project WinFormsConsoleApp1 contained in this repo:


``` csharp

            // Prepare basic information needed for preparing the app start
            var s = typeof(Program).Assembly.Location;
            var path = new FileInfo(s).DirectoryName;
            var configFile = "appsettings.json";

#if DEBUG
            // Load app settings from dev app settings file in DEBUG mode
            if (File.Exists(Path.Combine(path, "appsettings.Development.json")))
            {
                configFile = "appsettings.Development.json";
            }
#endif

            // Now prepare the app start
            var provider = new DefaultAppStartProvider
            {
                ConfigFile = configFile
            };

            provider.LoadConfigurationProvider();
            provider.LoadAppStartParameter();

            // Set additional app start parameters as required
            var param = provider.AppStartParameter;
            param.AppName = "WinFormsConsoleApp1: Demo app";
            param.SoftwareTeam = "Robert Leisner";
            param.LogoRessourcePath = "WinFormsConsoleApp1.Resources.logo.jpg";
            param.AppFolderName = "WinFormsConsoleApp1";

            provider.LoadDefaultAppLoggerProvider();
            provider.SetValuesInAppGlobal(Globals.Instance);

            // Write first log entry with default logger
            Globals.Instance.Logger.LogInformation($"{provider.AppStartParameter.AppName} {provider.AppStartParameter.AppVersion} starts...");
            Console.WriteLine("Logging started...");

            // App is ready now for doing something
            //Console.WriteLine("Preparing app start done. To proceed press any key");
            //Console.ReadLine();

            Console.WriteLine($"Connection string loaded: {provider.AppStartParameter.DefaultConnectionString}");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"App name loaded: {provider.AppStartParameter.AppName}");
            Console.WriteLine($"App version loaded: {provider.AppStartParameter.AppVersion}");
            Console.WriteLine($"App path loaded: {provider.AppStartParameter.AppPath}");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"Logging config: {ObjectHelper.GetObjectPropertiesAsString(Globals.Instance.LoggingConfig)}");

            //Console.WriteLine("To proceed press any key");
            //Console.ReadLine();

            var factory = new WinFormsConsoleApp1ProductionDiContainerServiceProviderPackageFactory(Globals.Instance);
            IApplicationServiceHandler startProcess = new ApplicationServiceHandler(factory);

            const string performanceToken = "--PERF";

            if (args.Contains(performanceToken))
            {
                startProcess.AppGlobals.AppStartParameter.IsPerformanceLoggingActivated = true;
            }


            IAppStarterUi appStarter = new WinFormsStarterUi(startProcess);


            // Run as singleton app
            if (appStarter.IsAnotherInstance)
            {
                Console.WriteLine($"Another instance of {param.AppName} is already running! Press any key to proceed!");
                Console.ReadLine();
                Environment.Exit(0);
                return;
            }

#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
#endif

            appStarter.Start();

            appStarter.Wait();


            Environment.Exit(0);

```

To run your own workload simply start adjusting method StartApplication in WinFormsConsoleApp1Service class.

### App start infrastructure for console apps

Here a sample from Program.cs Main() how to setup the console app in project WinFormsApp1 contained in this repo:


``` csharp

            // Prepare basic information needed for preparing the app start
            var s = typeof(Program).Assembly.Location;
            var path = new FileInfo(s).DirectoryName;
            var configFile = "appsettings.json";

#if DEBUG
            // Load app settings from dev app settings file in DEBUG mode
            if (File.Exists(Path.Combine(path, "appsettings.Development.json")))
            {
                configFile = "appsettings.Development.json";
            }
#endif

            // Now prepare the app start
            var provider = new DefaultAppStartProvider
            {
                ConfigFile = configFile
            };

            provider.LoadConfigurationProvider();
            provider.LoadAppStartParameter();

            // Set additional app start parameters as required
            var param = provider.AppStartParameter;
            param.AppName = "WinFormsApp1: Demo app";
            param.SoftwareTeam = "Robert Leisner";
            param.LogoRessourcePath = "WinFormsApp1.Resources.logo.jpg";
            param.AppFolderName = "WinFormsApp1";

            provider.LoadDefaultAppLoggerProvider();
            provider.SetValuesInAppGlobal(Globals.Instance);

            // Write first log entry with default logger
            Globals.Instance.Logger.LogInformation($"{provider.AppStartParameter.AppName} {provider.AppStartParameter.AppVersion} starts...");
            Console.WriteLine("Logging started...");

            // App is ready now for doing something
            //Console.WriteLine("Preparing app start done. To proceed press any key");
            //Console.ReadLine();

            Console.WriteLine($"Connection string loaded: {provider.AppStartParameter.DefaultConnectionString}");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"App name loaded: {provider.AppStartParameter.AppName}");
            Console.WriteLine($"App version loaded: {provider.AppStartParameter.AppVersion}");
            Console.WriteLine($"App path loaded: {provider.AppStartParameter.AppPath}");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"Logging config: {ObjectHelper.GetObjectPropertiesAsString(Globals.Instance.LoggingConfig)}");

            //Console.WriteLine("To proceed press any key");
            //Console.ReadLine();

            var factory = new WinFormsApp1ProductionDiContainerServiceProviderPackageFactory(Globals.Instance);
            IApplicationServiceHandler startProcess = new ApplicationServiceHandler(factory);

            const string performanceToken = "--PERF";

            if (args.Contains(performanceToken))
            {
                startProcess.AppGlobals.AppStartParameter.IsPerformanceLoggingActivated = true;
            }

            // Create the viewmodel now
            var eventLevel = EventLevel.Warning;
            var listener = new AppEventListener(eventLevel);
            var viewModel = new Forms1MainWindowViewModel(listener, startProcess);

            // Inject it to UI
            IAppStarterUi appStarter = new WinFormsStarterUi(startProcess, viewModel);


            // Run as singleton app
            if (appStarter.IsAnotherInstance)
            {
                Console.WriteLine($"Another instance of {param.AppName} is already running! Press any key to proceed!");
                Console.ReadLine();
                Environment.Exit(0);
                return;
            }

#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
#endif

            appStarter.Start();

            appStarter.Wait();


            Environment.Exit(0);      

```

Start by creating your own viewmodel class similar to Forms1MainWindowViewModel

## IAppGlobals

Using Bodoconsult.App should should first implement a class Globals inheriting from IAppGlobals as a singleton instance class without ctor:

``` csharp

/// <summary>
/// App global values
/// </summary>
public class Globals : IAppGlobals
{

    #region Singleton factory

    // Thread-safe implementation of singleton pattern
    private static Lazy<Globals> _instance;

    /// <summary>
    /// Get a singleton instance of 
    /// </summary>
    /// <returns></returns>
    public static Globals Instance
    {
        get
        {
            try
            {
                _instance ??= new Lazy<Globals>(() => new Globals());
                return _instance.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }

    #endregion

    ...

}

```

For a sample implementation see poject ConsoleApp1.

## IAppLoggerProxy / AppLoggerProxy

AppLoggerProxy is a high performance logger infrastructure for multithreaded and or multitasked apps with low resulting garbage pressure. 

Log entries are stored to a intermediate queue and then processed on a single thread during app runtime using a IWatchdog implementation. This avoids file access errors resulting from different threads trying to access the destinantion log at the same time.

To reduce garbage pressure log entries are reused. Therefore you should use a singelton instance of a LogDataFactory for the whole app.



### Using log4net as logger

If you want to use log4net for logging you can use the Log4NetLoggerFactory. 

``` csharp

var logger = new AppLoggerProxy(new Log4NetLoggerFactory.(), Globals.LogDataFactory);

_log.LogWarning("Hallo");
			
```

You can configure the logger with a log4net.config file in the project main folder. See log4net documentation for details.



### Fake logger for unit tests 

For unit tests you can use a fake implementation of a logger. It logs to the output window only.

``` csharp

var logger = new AppLoggerProxy(new FakeLoggerFactory(), Globals.LogDataFactory);

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

