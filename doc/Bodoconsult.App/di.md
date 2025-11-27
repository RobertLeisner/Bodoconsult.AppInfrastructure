# Dependency injection container DiContainer

## Basics on Dependency injection

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

The purpose of a dependency injection container class like Dicontainer is to resolve the dependencies injected by constructur when a class is instanciated.

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

This type of dependency injection works but is not very transparent from outside the class. Therefore it should by avoided and replaced by constructor injection.

## How to use DiContainer class

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
