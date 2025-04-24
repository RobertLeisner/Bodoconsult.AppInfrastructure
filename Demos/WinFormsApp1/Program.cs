// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using System.Diagnostics.Tracing;
using Bodoconsult.App;
using Bodoconsult.App.BusinessTransactions.RequestData;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Logging;
using Bodoconsult.App.WinForms.AppStarter;
using WinFormsApp1.App;
using WinFormsApp1.DiContainerProvider;

// ReSharper disable LocalizableElement

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Debug.Print("Hello, World!");

            Console.WriteLine("WinFormsApp1 initiation starts...");


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

            const string fileName = "C:\\ProgramData\\ConsoleApp1\\ConsoleApp1_Crash.log";

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
                var appHandler = Globals.Instance.DiContainer.Get<IApplicationServiceHandler>();
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
}