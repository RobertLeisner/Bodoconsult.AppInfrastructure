// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.Helpers;
using GrpcServerApp.Grpc.App;

namespace GrpcServerApp;

public static class Program
{
    private static GrpcServerAppAppBuilder builder;

    public static void Main(string[] args)
    {

        Debug.Print("Hello, World!");

        Debug.Print("GrpcServerApp initiation starts...");

        builder = new GrpcServerAppAppBuilder(Globals.Instance, args);

#if !DEBUG
        AppDomain.CurrentDomain.UnhandledException += builder.CurrentDomainOnUnhandledException;
#endif

        // Load basic app metadata
        builder.LoadBasicSettings(typeof(Program));

        // Process the config file
        builder.ProcessConfiguration();


        // Set additional app start parameters as required
        var param = builder.AppStartProvider.AppStartParameter;
        param.AppName = "GrpcServerApp: Demo app";
        param.SoftwareTeam = "Robert Leisner";
        param.LogoRessourcePath = "GrpcServerApp.Resources.logo.jpg";
        param.AppFolderName = "GrpcServerApp";

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
        builder.RegisterGrpcDiServices();
        builder.LoadDiContainerServiceProviderPackage();
        builder.RegisterDiServices();

        // Now configure GRPC IP, port, protocol
        builder.ConfigureGrpc();

        // Proto services load in GrpcServerAppAppBuilder.RegisterProtoServices()

        // builder.FinalizeDiContainerSetup(); Do call this method for a background service. It is too early for it

        // Now finally start the app and wait
        builder.StartApplication();

        Environment.Exit(0);
    }

    /// <summary>
    /// Shutdown the app (intended for testing)
    /// </summary>
    public static void Shutdown()
    {
        builder?.StopApplication();
    }

}







