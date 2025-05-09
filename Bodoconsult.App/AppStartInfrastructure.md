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

## Using app start infrastructure

### Using app start infrastructure for console apps

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

### Using app start infrastructure for a OS service like WinForms based apps

If you want to implement a OS service like application without implementing a real OS service you can use WinFormsStarterUi class. 

By default WinFormsStarterUi class loads the app as a simple window not shown on Windows task bar but task tray. The app can be closed only with keys STRC + C / CTRL + C or from task tray.

Here a sample from Program.cs Main() how to setup the console app in project WinFormsConsoleApp1 contained in this repo:

``` csharp

            var globals = Globals.Instance;
            globals.LoggingConfig.AddDefaultLoggerProviderConfiguratorsForUiApp();

            // Set additional app start parameters as required
            var param = globals.AppStartParameter;
            param.AppName = "WinFormsConsoleApp1: Demo app";
            param.SoftwareTeam = "Robert Leisner";
            param.LogoRessourcePath = "WinFormsConsoleApp1.Resources.logo.jpg";
            param.AppFolderName = "WinFormsConsoleApp1";

            const string performanceToken = "--PERF";

            if (args.Contains(performanceToken))
            {
                param.IsPerformanceLoggingActivated = true;
            }

            // Now start app buiding process
            var builder = new WinFormsConsoleApp1AppBuilder(globals);
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

            // Create the viewmodel now
            var eventLevel = EventLevel.Warning;
            var listener = new AppEventListener(eventLevel);
            var viewModel = new MainWindowViewModel(listener);

            // Set the view model 
            builder.MainWindowViewModel = viewModel;

            // Now finally start the app and wait
            builder.StartApplication();

            Environment.Exit(0);

```

### Using app start infrastructure for a classical WinForms based apps

Here a sample from Program.cs Main() how to setup the WinForms app with a main form Forms1 in project WinFormsApp1 contained in this repo:

``` csharp

            var globals = Globals.Instance;
            globals.LoggingConfig.AddDefaultLoggerProviderConfiguratorsForUiApp();

            // Set additional app start parameters as required. Take some settings from appsettings.json here
            var param = globals.AppStartParameter;
            //param.AppName = "WinFormsApp1: Demo app"; // from appsettings.json
            param.SoftwareTeam = "Robert Leisner";
            param.LogoRessourcePath = "WinFormsApp1.Resources.logo.jpg";
            //param.AppFolderName = "WinFormsApp1"; // from appsettings.json

            const string performanceToken = "--PERF";

            if (args.Contains(performanceToken))
            {
                param.IsPerformanceLoggingActivated = true;
            }

            // Now start app buiding process
            var builder = new WinFormsApp1AppBuilder(Globals.Instance);
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

            // Create the viewmodel now
            var eventLevel = EventLevel.Warning;
            var listener = new AppEventListener(eventLevel);
            var viewModel = new Forms1MainWindowViewModel(listener);

            // Set the view model 
            builder.MainWindowViewModel = viewModel;

            // Now finally start the app and wait
            builder.StartApplication();

            Environment.Exit(0);

```

Start by creating your own viewmodel class similar to Forms1MainWindowViewModel

### Using app start infrastructure for a Windows service

Here a sample from Program.cs Main() how to setup the console app in project WorkerService1 contained in this repo:


``` csharp

        var globals = Globals.Instance;
        globals.LoggingConfig.AddDefaultLoggerProviderConfiguratorsForBackgroundServiceApp();

        // Set additional app start parameters as required
        var param = globals.AppStartParameter;
        param.AppName = "WorkerService1: Demo app";
        param.SoftwareTeam = "Robert Leisner";
        param.LogoRessourcePath = "WorkerService1.Resources.logo.jpg";
        param.AppFolderName = "WorkerService1";

        const string performanceToken = "--PERF";

        if (args.Contains(performanceToken))
        {
            param.IsPerformanceLoggingActivated = true;
        }

        // Now start app buiding process
        IAppBuilder builder = new WorkerService1AppBuilder(globals);
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
        // builder.FinalizeDiContainerSetup(); Do call this method for a background service. It is too early for it

        // Now finally start the app and wait
        builder.StartApplication();

        Environment.Exit(0);

```

### Using app start infrastructure for a Windows service hosting a GRPC server

Here a sample from Program.cs Main() how to setup the console app in project GrpcServerApp contained in this repo:

``` csharp

        var globals = Globals.Instance;
        globals.LoggingConfig.AddDefaultLoggerProviderConfiguratorsForBackgroundServiceApp();

        // Set additional app start parameters as required
        var param = globals.AppStartParameter;
        param.AppName = "GrpcServerApp: Demo app";
        param.SoftwareTeam = "Robert Leisner";
        param.LogoRessourcePath = "GrpcServerApp.Resources.logo.jpg";
        param.AppFolderName = "GrpcServerApp";

        const string performanceToken = "--PERF";

        if (args.Contains(performanceToken))
        {
            param.IsPerformanceLoggingActivated = true;
        }

        // Now start app buiding process
        _builder = new GrpcServerAppAppBuilder(globals, args);

#if !DEBUG
        AppDomain.CurrentDomain.UnhandledException += builder.CurrentDomainOnUnhandledException;
#endif

        // Load basic app metadata
        _builder.LoadBasicSettings(typeof(Program));

        // Process the config file
        _builder.ProcessConfiguration();

        // Now load the globally needed settings
        _builder.LoadGlobalSettings();

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
        _builder.RegisterGrpcDiServices();
        _builder.LoadDiContainerServiceProviderPackage();
        _builder.RegisterDiServices();

        // Now configure GRPC IP, port, protocol
        _builder.ConfigureGrpc();

        // Proto services load in GrpcServerAppAppBuilder.RegisterProtoServices()

        // builder.FinalizeDiContainerSetup(); Do call this method for a background service. It is too early for it

        // Now finally start the app and wait
        _builder.StartApplication();

        Environment.Exit(0);

```


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
  //"TowerRuns": {
  //  "TrialRunCancellationPolicy": "DEFAULT"
  //},
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
