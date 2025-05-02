// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.BusinessTransactions.RequestData;
using Bodoconsult.App;
using Bodoconsult.App.BackgroundService;
using Bodoconsult.App.DependencyInjection;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;
using WorkerService1.App;
using WorkerService1.DiContainerProvider;

namespace WorkerService1;


internal static class Program
{

    private static void Main(string[] args)
    {

        Debug.Print("Hello, World!");

        Debug.Print("WorkerService1 initiation starts...");

#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
#endif

        IAppBuilder builder = new WorkerService1AppBuilder(Globals.Instance);

        // Load basic app meta data
        builder.LoadBasicSettings(typeof(Program));

        // Process the config file
        builder.ProcessConfiguration();


        // Set additional app start parameters as required
        var param = builder.AppStartProvider.AppStartParameter;
        param.AppName = "WorkerService1: Demo app";
        param.SoftwareTeam = "Robert Leisner";
        param.LogoRessourcePath = "WorkerService1.Resources.logo.jpg";
        param.AppFolderName = "WorkerService1";

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
        // builder.FinalizeDiContainerSetup(); Do call this method for a background service. It is too early for it

        // Now finally start the app and wait
        builder.StartApplication();

        Environment.Exit(0);
    }


    private static void CurrentDomainOnUnhandledException(object sender,
        UnhandledExceptionEventArgs unhandledExceptionEventArgs)
    {

        // Report the crash
        ReportCrash((Exception)unhandledExceptionEventArgs.ExceptionObject);

        AsyncHelper.Delay(1000);

        var ex = (Exception)unhandledExceptionEventArgs.ExceptionObject;
        throw ex;

    }

    private static void ReportCrash(Exception unhandledException)
    {

        var gms = Globals.Instance.DiContainer.Get<IGeneralAppManagementManager>();

        const string fileName = "C:\\ProgramData\\WorkerService1\\WorkerService1_Crash.log";

        var request = new EmptyBusinessTransactionRequestData();
        // ToDo: fill request with useful information

        var logger = Globals.Instance.DiContainer.Get<IAppLoggerProxy>();

        try
        {
            const string logMessage = "Unhandled exception caught";
            logger?.LogCritical(unhandledException, logMessage);

            File.AppendAllText(fileName, $"Crash at {DateTime.Now}: {unhandledException}{Environment.NewLine}");

            var result = gms?.CreateLogDump(request);

            if (result == null)
            {
                return;
            }

            logger?.LogWarning(fileName, $"CreateLogDump after crash: error code {result.ErrorCode}: {result.Message}");
        }
        catch (Exception e)
        {
            LogFinalException(fileName, e);
        }


        try
        {
            var appHandler = Globals.Instance.DiContainer.Get<IAppBuilder>();
            appHandler.StopApplication();
        }
        catch
        {
            //
        }
    }

    private static void LogFinalException(string fileName, Exception e)
    {
        try
        {
            File.AppendAllText(fileName, $"Crash at {DateTime.Now}: {e}{Environment.NewLine}");
        }
        catch
        {
            // Do nothing
        }
    }
}






