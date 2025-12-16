Bodoconsult.App.GrpcBackgroundServices
=====================

# Overview

## What does the library

Bodoconsult.App is a library with basic functionality for multilayered monolithic applications like database based client server apps or windows services. 

Bodoconsult.App.GrpcBackgroundServices enhances the functionality of Bodoconsult.App for Windows services hosting GRPC service.

It delivers the following main functionality:

1. App start infrastructure for Windows services apps using GRPC

## How to use the library

The source code contains NUnit test classes the following source code is extracted from. The samples below show the most helpful use cases for the library.

# App start infrastructure basics

See page [app start infrastructure](../Bodoconsult.App/AppStartInfrastructure.md) for details.

# Using Protobuf definitions (protos) from Bodoconsult.App.GrpcBackgroundServices in GRPC clients

## Using the source code

You can integrate the protos to your project directly from repo. Simply copy the files to your project and used it same as your own protos.

## Using the Bodoconsult.App.GrpcBackgroundServices nuget package

See https://github.com/grpc/grpc/blob/master/src/csharp/BUILD-INTEGRATION.md#proto-only-nuget

Bodoconsult.App.GrpcBackgroundServices contains the following protos:

-	Protos\business_transaction_description.proto
-	Protos\common.proto
-	Protos\reply_data.proto
-	Protos\request_data.proto

Consuming the .proto file at client side:

-	Install the Bodoconsult.App.GrpcBackgroundServices Nuget package in your gRPC client project.
-	Add GeneratePathProperty="true" property to package reference in your gRPC client project file.
-	Add prefix $(PkgBodoconsult_App_GrpcBackgroundServices)\content\ while including the Protobuf reference. ('\content' is the directory name where all the content files are available by default.)

Note that, $(PkgBodoconsult_App_GrpcBackgroundServices) is by conventions where $(PkgGrpc_Shared) will be resolved to Grpc.Shared Nuget directory (the variable name starts with Pkg and is followed by the package name when . is replaced by _)

``` xml

	<ItemGroup>
		<Protobuf Include="$(PkgBodoconsult_App_GrpcBackgroundServices)\content\Protos\business_transaction_description.proto" GrpcServices="Client" Link="Protos\business_transaction_description.proto" />
		<Protobuf Include="$(PkgBodoconsult_App_GrpcBackgroundServices)\content\Protos\common.proto" Protos\common.proto" GrpcServices="Client"  Link="Protos\common.proto" />
		<Protobuf Include="$(PkgBodoconsult_App_GrpcBackgroundServices)\content\Protos\reply_data.proto" GrpcServices="Client"  Link="Protos\reply_data.proto" />
		<Protobuf Include="$(PkgBodoconsult_App_GrpcBackgroundServices)\content\Protos\request_data.proto" GrpcServices="Client"  Link="Protos\request_data.proto" />
	</ItemGroup>

```

Source: https://sanket-naik.medium.com/sharing-grpc-proto-files-with-nuget-packages-made-easy-dd366a094b25

## Using app start infrastructure for a Windows service hosting a GRPC server

Here a sample from Program.cs Main() how to setup the GRPC (server) service app in project GrpcServerApp contained in this repo:

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

# About us

Bodoconsult <http://www.bodoconsult.de> is a Munich based software company from Germany.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

