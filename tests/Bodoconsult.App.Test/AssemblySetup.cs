﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Extensions;
using Bodoconsult.App.Test.App;

namespace Bodoconsult.App.Test
{
    /// <summary>
    /// Setup for the assembly for all tests
    /// </summary>
    [SetUpFixture]
    public static class AssemblySetup
    {
        /// <summary>
        /// At startup of the assembly
        /// </summary>
        [OneTimeSetUp]
        public static void AssemblyStartUp()
        {

            var globals = Globals.Instance;
            globals.LoggingConfig.AddDefaultLoggerProviderConfiguratorsForUiApp();

            // Set additional app start parameters as required
            var param = globals.AppStartParameter;
            param.AppName = "WinAppTests: Demo app";
            param.SoftwareTeam = "Robert Leisner";
            //param.LogoRessourcePath = "WinFormsConsoleApp1.Resources.logo.jpg";
            param.AppFolderName = "WinAppTests";


            // Now start the app building process
            var builder = new MyDebugAppBuilder(globals);
#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += builder.CurrentDomainOnUnhandledException;
#endif

            // Load basic app metadata

            builder.LoadBasicSettings(typeof(AssemblySetup));

            // Process the config file
            builder.ProcessConfiguration();

            // Now load the globally needed settings
            builder.LoadGlobalSettings();

            Globals.Instance.Logger.LogInformation("Starting tests...");

        }
    }
}
