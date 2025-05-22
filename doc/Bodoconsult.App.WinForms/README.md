Bodoconsult.App.WinForms nuget package
============

# What does the library

Bodoconsult.App is a library with basic functionality for multilayered monolithic applications like database based client server apps or windows services. 


# App start infrastructure basics

See page [app start infrastructure](../Bodoconsult.App/AppStartInfrastructure.md) for details.

## Using app start infrastructure for a OS service like WinForms based apps

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

## Using app start infrastructure for a classical WinForms based apps

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


# About us

Bodoconsult <http://www.bodoconsult.de> is a Munich based software company from Germany.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

