// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

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
            var provider = new DebugAppStartProvider();
            provider.LoadConfigurationProvider();
            provider.LoadAppStartParameter();
            
            var param = provider.AppStartParameter;
            param.AppName = "ConsoleApp1: Demo app";
            param.SoftwareTeam = "Robert Leisner";
            param.LogoRessourcePath = "ConsoleApp1.Resources.logo.jpg";
            param.AppFolderName = "ConsoleApp1";

            provider.LoadDefaultAppLoggerProvider();
            provider.SetValuesInAppGlobal(Globals.Instance);

            Globals.Instance.Logger.LogInformation("Starting tests...");

        }
    }
}
