Bodoconsult.App nuget package
============

# App start infrastructure for console and Winforms apps

The Bodoconsult.App contains the infrastructure to set up certain types of apps with commonly used features like

-   Reading appsettings.json, keep it in memory for later usage and extract connection string and logging settings from it
-   Setup a central logger
-   Setup DI containers for production and testing environment
-   Start the console app and run workload in a separate thread
-   Unhandled exception handling

Bodoconsult.App supports the following MS Windows apps:

-   Console app
-   WinForms apps (classical WinForms app or service-like app with a very limited WinForms based UI)
-   Windows background service
-   Windows background service hosting a GRPC server service

Base classes for app start infrastructure are the 

-   BaseAppBuilder class for console app, 
-   BaseWinFormsAppBuilder class for WinForms based projects, 
-   BaseBackgroundServiceAppBuilder for windows services,
-   BaseGrpcBackgroundServiceAppBuilder for windows services hosting a GRPC server service.


## Implementation steps

### IAppGlobals

Interface IAppGlobals requires basic properties like logging config, central app logger or the DI container used for the app etc. often needed in apps to be implemented:

``` csharp
/// <summary>
/// Interface for global app settings with lifetime for the whole app lifetime. I
/// </summary>
public interface IAppGlobals: IDisposable
{

    /// <summary>
    /// This event is set if the application is started only as singleton
    /// </summary>
    public EventWaitHandle EventWaitHandle { get; set; }

    /// <summary>
    /// App start parameter
    /// </summary>
    IAppStartParameter AppStartParameter { get; set; }

    /// <summary>
    /// Current log data entry factory
    /// </summary>
    ILogDataFactory LogDataFactory { get; set; }

    /// <summary>
    /// Current logging config
    /// </summary>
    LoggingConfig LoggingConfig { get; set; }

    /// <summary>
    /// Current app logger. Use this instance only if no DI container is available. Nonetheless, use DiContainer.Get&lt;IAppLoggerProxy&gt; to fetch the default app logger from DI container. Don't forget to load it during DI setup!
    /// </summary>
    IAppLoggerProxy Logger { get; set; }

    /// <summary>
    /// Current dependency injection (DI) container
    /// </summary>
    DiContainer DiContainer { get; set; }

    /// <summary>
    /// Delegate called if a fatale app exception has been raised and a message to the UI has to be sent before app terminates
    /// </summary>
    HandleFatalExceptionDelegate HandleFatalExceptionDelegate  { get; set; }

    /// <summary>
    /// Current app storage connection check instance or null
    /// </summary>
    IAppStorageConnectionCheck AppStorageConnectionCheck { get; set; }


    /// <summary>
    /// Current status message delegate
    /// </summary>
    public StatusMessageDelegate StatusMessageDelegate { get; set; }

    /// <summary>
    /// Current license management delegate
    /// </summary>
    public LicenseMissingDelegate LicenseMissingDelegate { get; set; }

  }
```
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

The properties AppStartParameter and LoggingConfig must have a default value not null.

For a sample implementation see project WinFormsApp1.

### Create your own IAppBuilder instance

You have to derive a class from one of this base classes and implement the method LoadDiContainerServiceProviderPackage to load a IDiContainerServiceProviderPackage base implementation providing your DI container setup.

``` csharp

public class ConsoleApp1AppBuilder: BaseAppBuilder
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="appGlobals">Global app settings</param>
    public ConsoleApp1AppBuilder(IAppGlobals appGlobals) : base(appGlobals)
    {

    }

    /// <summary>
    /// Load the <see cref="IAppBuilder.DiContainerServiceProviderPackage"/>
    /// </summary>
    public override void LoadDiContainerServiceProviderPackage()
    {
        var factory = new ConsoleApp1ProductionDiContainerServiceProviderPackageFactory(AppGlobals);
        DiContainerServiceProviderPackage = factory.CreateInstance();
    }
}

```

## Using app start infrastructure for console apps

Here a sample from Program.cs Main() how to setup the console app in project ConsoleApp1. contained in this repo:


``` csharp

            var globals = Globals.Instance;
            globals.LoggingConfig.AddDefaultLoggerProviderConfiguratorsForConsoleApp();

            // Set additional app start parameters as required
            var param = globals.AppStartParameter;
            param.AppName = "ConsoleApp1: Demo app";
            param.SoftwareTeam = "Robert Leisner";
            param.LogoRessourcePath = "ConsoleApp1.Resources.logo.jpg";
            param.AppFolderName = "ConsoleApp1";

            const string performanceToken = "--PERF";

            if (args.Contains(performanceToken))
            {
                param.IsPerformanceLoggingActivated = true;
            }

            // Now start app buiding process
            IAppBuilder builder = new ConsoleApp1AppBuilder(globals);
#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += builder.CurrentDomainOnUnhandledException;
#endif

            // Load basic app metadata
            builder.LoadBasicSettings(typeof(Program));

            // Process the config file
            builder.ProcessConfiguration();

            // Now load the globally needed settings
            builder.LoadGlobalSettings();

            // Write first log entry with default logger
            Globals.Instance.Logger.LogInformation($"{param.AppName} {param.AppVersion} starts...");
            Console.WriteLine("Logging started...");

            // App is ready now for doing something
            Console.WriteLine($"Connection string loaded: {param.DefaultConnectionString}");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"App name loaded: {param.AppName}");
            Console.WriteLine($"App version loaded: {param.AppVersion}");
            Console.WriteLine($"App path loaded: {param.AppPath}");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"Logging config: {ObjectHelper.GetObjectPropertiesAsString(Globals.Instance.LoggingConfig)}");

            // Prepare the DI container package
            builder.LoadDiContainerServiceProviderPackage();
            builder.RegisterDiServices();
            builder.FinalizeDiContainerSetup();

            // Now finally start the app and wait
            builder.StartApplication();

            Environment.Exit(0);

```

To run your own workload simply start adjusting method StartApplication in ConsoleApp1Service class.


## Loading app start parameters from appsettings.json

Certain properties existing in IAppStartParameters and its implementations can be loaded from appsettings.json at app start.

See the following example of appsettings.json from project WinFormsApp1 with all possible properties loaded:


``` json

{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(LocalDB)\\MSSQLLocalDb;Initial Catalog=XYDatabase;Integrated Security=true;MultipleActiveResultSets=True;App=WinFormsApp1"
  },
  "AppStartParameter": {
    "AppName": "Your app name",
    "AppFolderName": "YorAppName",
    "Port": "",
    "BackupPath": "",
    "NumberOfBackupsToKeep": "25"
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
