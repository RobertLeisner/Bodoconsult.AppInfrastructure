
# What does the library

Bodoconsult.App.Wpf is a library with basic functionality for multilayered monolithic WPF based applications. 


# App start infrastructure basics

See page [app start infrastructure](../Bodoconsult.App/AppStartInfrastructure.md) for details.

## Using app start infrastructure for a classical Wpf based apps

Here a sample from Program.cs Main() how to setup the Wpf app with a main form Forms1 in project WpfApp1 contained in this repo:

``` csharp
var type = typeof(App);

Debug.Print("Hello, World!");

Console.WriteLine("WpfApp1 initiation starts...");

var globals = Globals.Instance;
globals.LoggingConfig.AddDefaultLoggerProviderConfiguratorsForUiApp();

// Set additional app start parameters as required
var param = globals.AppStartParameter;
param.AppName = "WpfApp1: Demo app";
param.SoftwareTeam = "Robert Leisner";
param.LogoRessourcePath = "WpfApp1.Resources.logo.jpg";
param.AppFolderName = "WpfApp1";

const string performanceToken = "--PERF";

if (e.Args.Contains(performanceToken))
{
    param.IsPerformanceLoggingActivated = true;
}

// Now start app buiding process
var builder = new WpfApp1AppBuilder(globals);
#if !DEBUG
AppDomain.CurrentDomain.UnhandledException += builder.CurrentDomainOnUnhandledException;
#endif

// Load basic app metadata
builder.LoadBasicSettings(type);

// Process the config file
builder.ProcessConfiguration();

// Now load the globally needed settings
builder.LoadGlobalSettings();

// Prepare the DI container package
builder.LoadDiContainerServiceProviderPackage();
builder.RegisterDiServices();
builder.FinalizeDiContainerSetup();

// Create the viewmodel now
var eventLevel = EventLevel.Warning;
var listener = new AppEventListener(eventLevel);
var viewModel = new WpfApp1MainWindowViewModel(listener)
{
    HeaderBackColor = Colors.DarkBlue,
    BodyBackColor = Colors.Beige,
    AppExe = param.AppExe
};

// Load the logo now
viewModel.LoadLogo(type.Assembly, param.LogoRessourcePath);

// Set the view model 
builder.MainWindowViewModel = viewModel;

// Now finally start the app and wait
builder.StartApplication();

base.OnStartup(e);
```

Start by creating your own viewmodel class WpfApp1MainWindowViewModel derived from MainWindowViewModel and override CreateWindow() method to load your custom start window.

## Using app start infrastructure for a console app employing a WPF dispatcher

If you want to use WPF features like FlowDocuments in a console app you need to employ a WPF dispatcher. 
In a classical WPF app starting the WPF dispatcher is done by the App.xaml start process internally. 
In a console app you do not have a App.xaml so the disptacher has to be started separately.
Using Bodoconsult.App.Wpf you can handles this easily.

Here a sample from Program.cs Main() how to setup the console app employing a WPF dispatcher in project ConsoleWpfApp1 contained in this repo:

``` csharp
var globals = Globals.Instance;
globals.LoggingConfig.AddDefaultLoggerProviderConfiguratorsForConsoleApp();

// Set additional app start parameters as required
var param = globals.AppStartParameter;
param.AppName = "ConsoleWpfApp1: Demo app";
param.SoftwareTeam = "Robert Leisner";
param.AppFolderName = "ConsoleWpfApp1";

const string performanceToken = "--PERF";

if (args.Contains(performanceToken))
{
    param.IsPerformanceLoggingActivated = true;
}

// Now start app buiding process
IAppBuilder builder = new ConsoleWpfApp1AppBuilder(globals);
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

// Prepare the DI container package
builder.LoadDiContainerServiceProviderPackage();
builder.RegisterDiServices();
builder.FinalizeDiContainerSetup();

// Now finally start the app and wait
builder.StartApplication();

Environment.Exit(0);
```

Start by creating your own app builder class similar to ConsoleWpfApp1AppBuilder class based on BaseConsoleWpfAppBuilderl.

## Using app start infrastructure for a OS service like WPF based apps

If you want to implement a OS service like application without implementing a real OS service you can use WpfStarterUi class. 

By default WpfStarterUi class loads the app as a simple window not shown on Windows task bar but task tray. The app can be closed only with keys STRC + C / CTRL + C or from task tray.

Here a sample from App.Xaml.cs OnStartup() how to setup the WPF console app in project WpfConsoleApp1 contained in this repo:

``` csharp
var type = typeof(App);

Debug.Print("Hello, World!");

Console.WriteLine("WpfConsoleApp1 initiation starts...");

var globals = Globals.Instance;
globals.LoggingConfig.AddDefaultLoggerProviderConfiguratorsForUiApp();

// Set additional app start parameters as required
var param = globals.AppStartParameter;
param.AppName = "WpfConsoleApp1: Demo app";
param.SoftwareTeam = "Robert Leisner";
param.LogoRessourcePath = "WpfConsoleApp1.Resources.logo.jpg";
param.AppFolderName = "WpfConsoleApp1";

const string performanceToken = "--PERF";

if (e.Args.Contains(performanceToken))
{
    param.IsPerformanceLoggingActivated = true;
}

// Now start app buiding process
var builder = new WpfConsoleApp1AppBuilder(globals);
#if !DEBUG
AppDomain.CurrentDomain.UnhandledException += builder.CurrentDomainOnUnhandledException;
#endif

// Load basic app metadata
builder.LoadBasicSettings(type);

// Process the config file
builder.ProcessConfiguration();

// Now load the globally needed settings
builder.LoadGlobalSettings();

// Write first log entry with default logger
Globals.Instance.Logger.LogInformation($"{param.AppName} {param.AppVersion} starts...");
Console.WriteLine("Logging started...");

// Prepare the DI container package
builder.LoadDiContainerServiceProviderPackage();
builder.RegisterDiServices();
builder.FinalizeDiContainerSetup();

// Create the viewmodel now
var eventLevel = EventLevel.Warning;
var listener = new AppEventListener(eventLevel);
var viewModel = new MainWindowViewModel(listener)
{
    HeaderBackColor = Colors.Coral,
    AppExe = param.AppExe
};

// Load the logo now
viewModel.LoadLogo(type.Assembly, param.LogoRessourcePath);

// Set the view model 
builder.MainWindowViewModel = viewModel;

// Now finally start the app and wait
builder.StartApplication();

base.OnStartup(e);
```

Remark: Bodoconsult.App.Wpf uses Chapter.Net.WPF.SystemTray Nuget package to show system tray icons. See https://github.com/dwndland/Chapter.Net.WPF.SystemTray/tree/master.

# About us

Bodoconsult <http://www.bodoconsult.de> is a Munich based software company from Germany.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

