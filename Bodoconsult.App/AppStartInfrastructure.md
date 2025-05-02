# App start infrastructure for console and Winforms apps

The Bodoconsult.App contains the infrastructure to set up a console with commonly used features like

-   Reading appsettings.json, keep it in memory for later usage and extract connection string and logging settings from it

-   Setup a central logger

-   Setup DI containers for production and testing environment

-   Start the console app and run workload in a separate thread

Base classes for app start infrastructure are the BaseAppBuilder class for console app, BasWinFormsAppBuilder class for WinForms based projects and XXX for windows services.

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

 #if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
#endif

            IAppBuilder builder = new ConsoleApp1AppBuilder(Globals.Instance);

            // Load basic app meta data
            builder.LoadBasicSettings(typeof(Program));

            // Process the config file
            builder.ProcessConfiguration();


            // Set additional app start parameters as required
            var param = builder.AppStartProvider.AppStartParameter;
            param.AppName = "ConsoleApp1: Demo app";
            param.SoftwareTeam = "Robert Leisner";
            param.LogoRessourcePath = "ConsoleApp1.Resources.logo.jpg";
            param.AppFolderName = "ConsoleApp1";

            const string performanceToken = "--PERF";

            if (args.Contains(performanceToken))
            {
                param.IsPerformanceLoggingActivated = true;
            }

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

## Using app start infrastructure for a OS service like WinForms based apps

If you want to implement a OS service like application without implementing a real OS service you can use WinFormsStarterUi class. 

By default WinFormsStarterUi class loads the app as a simple window not shown on Windows task bar but task tray. The app can be closed only with keys STRC + C / CTRL + C or from task tray.

Here a sample from Program.cs Main() how to setup the console app in project WinFormsConsoleApp1 contained in this repo:


``` csharp

#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
#endif

            var builder = new WinFormsConsoleApp1AppBuilder(Globals.Instance);

            // Load basic app meta data
            builder.LoadBasicSettings(typeof(Program));

            // Process the config file
            builder.ProcessConfiguration();


            // Set additional app start parameters as required
            var param = builder.AppStartProvider.AppStartParameter;
            param.AppName = "WinFormsConsoleApp1: Demo app";
            param.SoftwareTeam = "Robert Leisner";
            param.LogoRessourcePath = "WinFormsConsoleApp1.Resources.logo.jpg";
            param.AppFolderName = "WinFormsConsoleApp1";

            const string performanceToken = "--PERF";

            if (args.Contains(performanceToken))
            {
                param.IsPerformanceLoggingActivated = true;
            }

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

To run your own workload simply start adjusting method StartApplication in WinFormsConsoleApp1Service class.

## Using app start infrastructure for a classical Winforms app

Here a sample from Program.cs Main() how to setup the console app in project WinFormsApp1 contained in this repo:


``` csharp

#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
#endif

            var builder = new WinFormsApp1AppBuilder(Globals.Instance);

            // Load basic app meta data
            builder.LoadBasicSettings(typeof(Program));

            // Process the config file
            builder.ProcessConfiguration();


            // Set additional app start parameters as required
            var param = builder.AppStartProvider.AppStartParameter;
            param.AppName = "WinFormsApp1: Demo app";
            param.SoftwareTeam = "Robert Leisner";
            param.LogoRessourcePath = "WinFormsApp1.Resources.logo.jpg";
            param.AppFolderName = "WinFormsApp1";

            const string performanceToken = "--PERF";

            if (args.Contains(performanceToken))
            {
                param.IsPerformanceLoggingActivated = true;
            }

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

## Using app start infrastructure for a Windows service

Here a sample from Program.cs Main() how to setup the console app in project WorkerService1 contained in this repo:


``` csharp



```

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

For a sample implementation see poject WinFormsApp1.
