// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Extensions;
using Bodoconsult.App.Helpers;
using WorkerService1.App;

namespace WorkerService1;


internal static class Program
{

    private static void Main(string[] args)
    {

        Debug.Print("Hello, World!");

        Debug.Print("WorkerService1 initiation starts...");

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
    }
}







