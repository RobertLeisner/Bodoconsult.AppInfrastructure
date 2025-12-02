Dependency injection (DI) container DiContainer
=====================

>   [Learn basics on dependency injection ()](#basics-on-dependency-injection-di)

>>  [Constructor injection](#constructor-injection)

>>  [Service locator style of injection](#service-locator-style-of-injection)

>>  [Method injection](#method-injection)



>   [How to use DiContainer class: the simple way](#how-to-use-dicontainer-class-the-simple-way)

>   [How to use DiContainer class: organize your DI with IDiContainerServiceProvider interface](#how-to-use-dicontainer-class-organize-your-di-with-idicontainerserviceprovider-interface)

>   [IDiContainerServiceProvider implementations in Bodoconsult.App.Infrastructure repo](#idicontainerserviceprovider-implementations-in-bodoconsultappinfrastructure-repo)

>   [BasicAppServicesConfig1ContainerServiceProvider](#basicappservicesconfig1containerserviceprovider)

>   [BasicAppServicesConfig2ContainerServiceProvider](#basicappservicesconfig2containerserviceprovider)

>   [ApmDiContainerServiceProvider]()

>   []()

# Basics on dependency injection (DI)

Dependency injection makes loose coupling of classes possible. The main question is: how do I get my required dependencies in a class from outside the class. Benefits of using DI are:
	
-	Helps in unit testing.

-	Boiler plate code is reduced, as initializing of dependencies is done by the injector component.

-	Extending the application becomes easier.

-	Helps to enable loose coupling, which is important in application programming.

There are basically three types of dependency injection:
	
-	constructor injection: the dependencies are provided through a class constructor.

-	setter injection: the client exposes a setter method that the injector uses to inject the dependency.

-	interface injection: the dependency provides an injector method that will inject the dependency into any client passed to it. Clients must 
implement an interface that exposes a setter method that accepts the dependency.

Service locator style of injection may be called a type of dependency injection too but its usage isn't recommend (see below).

The purpose of a dependency injection container class like DiContainer is to resolve the dependencies injected by constructur when a class is instanciated.

## Constructor injection

The dependencies of a class are injected via the constructor of a class. This is the preferred way on dependency injection.

``` csharp
// Using default spellchecker	
IEngine engine = new XEngine()
var carWithEngineX = new Car(engine)

// Using another spellchecker
engine = new YEngine()
var carWithEngineY = new Car(engine)

// Using a fake for testing	
engine = new FakeEngine()
var carWithFakeEngine = new Car(engine)
```

## Service locator style of injection

Via a central dependency manager like DiContainer class a required dependency is resolved from inside the class:

``` csharp
var instance = DiContainer.Get<ICar>()
```

This type of dependency injection works but is not very transparent from outside the class. Therefore it should by avoided and replaced by constructor injection or method injection.

## Method injection

Method dependency injection you normally do not need very often. You may need it if you have circular references if loading dependencies via ctor(). This may happen .e.e. if to classes are dependent on each other. Normally this should be avoided by class design but under rare circumstances especially during refatoring projects this may happen.

``` csharp
private IEngine _engine;

public void InjectDependecy(IEngine engine)
{
    _engine = engine;
}
```

# How to use DiContainer class: the simple way

Normally the DiContainer class is a central static singleton class. If you use Bodoconsult.App you can store the DiContainer instance in your implementation of IAppGlobals. There is a proeprty DiContainer for it.

Easiest but in larger projects not the best way of setting up the services delivered the DiContainer is as follows:

``` csharp
[Test]
public void BuildServiceProvider_DefaultSetup_ServicesAddedAndServiceProviderBuilt()
{
    // Arrange
    var diContainer = new DiContainer();

    Assert.That(diContainer.ServiceCollection.Count, Is.EqualTo(0));

    // Now add the services provided by a MS builder class
    var builder = diContainer.ServiceCollection.AddDataProtection()
        .SetApplicationName("TestApp")
        .PersistKeysToFileSystem(new DirectoryInfo(TestHelper.TempPath))
        ;

    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
        builder.ProtectKeysWithDpapi();
    }

    // Add your own classes
    diContainer.AddSingleton<IFileProtectionService, NoFileProtectionService>();
    diContainer.AddSingleton<IDataProtectionServiceFactory, DataProtectionServiceFactory>();
    diContainer.AddSingleton<IDataProtectionManagerFactory, DataProtectionManagerFactory>();

    // Act  
    diContainer.BuildServiceProvider();

    // Assert
    Assert.That(diContainer.ServiceCollection.Count, Is.Not.EqualTo(0));
    Assert.That(diContainer.ServiceProvider, Is.Not.Null);

    // Try to use an instance
    var dpm = diContainer.Get<IDataProtectionManagerFactory>();
    Assert.That(dpm, Is.Not.Null);
}
```

# How to use DiContainer class: organize your DI with IDiContainerServiceProvider interface

In the above sample you see all required services added line by line. This may lead to a complex method loading the required services in the DI container.

``` csharp
/// <summary>
/// Interface for classes adding DI container services to a DI container
/// </summary>
public interface IDiContainerServiceProvider
{
    /// <summary>
    /// Add DI container services to a DI container
    /// </summary>
    /// <param name="diContainer">Current DI container</param>
    void AddServices(DiContainer diContainer);

    /// <summary>
    /// Late bind DI container references to avoid circular DI references
    /// </summary>
    /// <param name="diContainer">Current DI container</param>
    void LateBindObjects(DiContainer diContainer);

}
```

Implement a provider based on IDiContainerServiceProvider to load your dependencies as required.

``` csharp
/// <summary>
/// Load all specific WpfConsoleApp1 services to DI container. Intended mainly for production
/// </summary>
public class WpfConsoleApp1AllServicesContainerServiceProvider : IDiContainerServiceProvider
{
    /// <summary>
    /// Add DI container services to a DI container
    /// </summary>
    /// <param name="diContainer">Current DI container</param>
    public void AddServices(DiContainer diContainer)
    {
        // Load all other services required for the app now
        diContainer.AddSingleton<IApplicationService, WpfConsoleApp1Service>();

        // ...
    }

    /// <summary>
    /// Late bind DI container references to avoid circular DI references
    /// </summary>
    /// <param name="diContainer"></param>
    public void LateBindObjects(DiContainer diContainer)
    {
        //// Example 1: Load the job scheduler now
        //var scheduler = diContainer.Get<IJobSchedulerManagementDelegate>();
        //scheduler.StartJobScheduler();

        //// Example 2: Load business transactions
        //var btl = diContainer.Get<IBusinessTransactionLoader>();
        //btl.LoadProviders();
    }
}
```

Now implement a class derived on BaseDiContainerServiceProviderPackage to build your DI setup package to load all required DI container provider:

``` csharp
/// <summary>
/// Load all the complete package of WpfConsoleApp1 services based on GRPC to DI container. Intended mainly for production
/// </summary>
public class WpfConsoleApp1AllServicesDiContainerServiceProviderPackage : BaseDiContainerServiceProviderPackage
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="appGlobals">Current app globals</param>
    /// <param name="statusMessageDelegate">Current statis message delegate to send status messages to UI</param>
    public WpfConsoleApp1AllServicesDiContainerServiceProviderPackage(IAppGlobals appGlobals,
        StatusMessageDelegate statusMessageDelegate) : base(appGlobals)
    {
        // Basic app services
        IDiContainerServiceProvider provider = new BasicAppServicesConfig2ContainerServiceProvider(appGlobals);
        ServiceProviders.Add(provider);

        // Performance measurement
        provider = new ApmDiContainerServiceProvider(appGlobals.AppStartParameter, statusMessageDelegate);
        ServiceProviders.Add(provider);

        // App default logging
        provider = new DefaultAppLoggerDiContainerServiceProvider(appGlobals.LoggingConfig, appGlobals.Logger);
        ServiceProviders.Add(provider);

        // SWpfConsoleApp1 specific services
        provider = new WpfConsoleApp1AllServicesContainerServiceProvider();
        ServiceProviders.Add(provider);
    }
}
```

And finally create your own IDiContainerServiceProviderPackageFactory implementation based on the above created IDiContainerServiceProviderPackage class:

``` csharp
/// <summary>
/// The current DI container used for production 
/// </summary>
public class WpfConsoleApp1ProductionDiContainerServiceProviderPackageFactory : IDiContainerServiceProviderPackageFactory
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public WpfConsoleApp1ProductionDiContainerServiceProviderPackageFactory(IAppGlobals appGlobals)
    {
        AppGlobals = appGlobals;
    }

    /// <summary>
    /// App globals
    /// </summary>
    public IAppGlobals AppGlobals { get; }

    /// <summary>
    /// Current status message delegate
    /// </summary>
    public StatusMessageDelegate StatusMessageDelegate { get; set; }

    /// <summary>
    /// Create an instance of <see cref="IDiContainerServiceProviderPackage"/>. Should be a singleton instance
    /// </summary>
    /// <returns>Singleton instance of <see cref="IDiContainerServiceProviderPackage"/></returns>
    public IDiContainerServiceProviderPackage CreateInstance()
    {
        return new WpfConsoleApp1AllServicesDiContainerServiceProviderPackage(AppGlobals, StatusMessageDelegate);
    }
}
```

The IDiContainerServiceProviderPackageFactory implementation 

```csharp
/// <summary>
/// <see cref="IAppBuilder"/> implementation for WPF base service-like console app
/// </summary>
public class WpfConsoleApp1AppBuilder : BaseWpfAppBuilder
{
    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="appGlobals">Global app settings</param>
    public WpfConsoleApp1AppBuilder(IAppGlobals appGlobals) : base(appGlobals)
    { }

    /// <summary>
    /// Load the <see cref="IAppBuilder.DiContainerServiceProviderPackage"/>
    /// </summary>
    public override void LoadDiContainerServiceProviderPackage()
    {
        var factory = new WpfConsoleApp1ProductionDiContainerServiceProviderPackageFactory(AppGlobals);
        DiContainerServiceProviderPackage = factory.CreateInstance();
    }
}
```

# IDiContainerServiceProvider implementations in Bodoconsult.App.Infrastructure repo

## BasicAppServicesConfig1ContainerServiceProvider 

Loads basic DI services configuration 1 used my most apps to DI container. Intended mainly for production

The following services are loaded:

-   IAppLoggerProxy as central logger instance

-   IAppLoggerProxyFactory for logging for creating specialized logfiles

-   IAppBenchProxy for benchmarking

-   IGeneralAppManagementManager for general app management

## BasicAppServicesConfig2ContainerServiceProvider 

Loads basic DI services configuration 2 used my most apps to DI container. Intended mainly for production

The following services are loaded:

-   IAppLoggerProxy as central logger instance

-   IAppLoggerProxyFactory for logging for creating specialized logfiles

-   IAppBenchProxy for benchmarking

-   IGeneralAppManagementManager for general app management

-   IAppEventListener for app event listening

## ApmDiContainerServiceProvider 

Loads all APM specific services to DI container. Intended mainly for production. See [Performance logging section](PerformanceLogging.md) in this documentation.



