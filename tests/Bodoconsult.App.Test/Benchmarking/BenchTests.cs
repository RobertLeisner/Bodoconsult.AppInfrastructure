// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Benchmarking;
using Bodoconsult.App.Benchmarking;
using Bodoconsult.App.Test.App;

namespace Bodoconsult.App.Test.Benchmarking;

public class BenchTests
{

    [Test]
    public void CreateABench_DefaultSetup_FileWritten()
    {
        var path = Path.Combine(Path.GetTempPath(), "BenchmarkViewer1.csv");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // Arrange 
        var loggerfactory = new BenchLoggerFactory(path);

        var benchLogger = new AppBenchProxy(loggerfactory, Globals.Instance.LogDataFactory);

        var bench = new Bench(benchLogger, "Identifying key");

        // Act  
        bench.Start("Starts");

        Task.Delay(500).Wait();

        bench.AddStep("Do something 1");

        Task.Delay(500).Wait();

        bench.AddStep("Do something 2");

        Task.Delay(500).Wait();

        bench.Stop("Stops");

        bench.Dispose();

        // Assert
        Assert.That(File.Exists(path));

    }

    [Test]
    public void CreateABenchReusable_DefaultSetup_FileWritten()
    {
        var path = Path.Combine(Path.GetTempPath(), "BenchmarkViewer2.csv");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // Arrange 
        var loggerfactory = new BenchLoggerFactory(path);

        var benchLogger = new AppBenchProxy(loggerfactory, Globals.Instance.LogDataFactory);

        var benchReusableFactory = new BenchReusableFactory();

        var bench = benchReusableFactory.CreateInstance(benchLogger, "Identifying key");

        // Act  
        bench.Start("Starts");

        Task.Delay(500).Wait();

        bench.AddStep("Do something 1");

        Task.Delay(500).Wait();

        bench.AddStep("Do something 2");

        Task.Delay(500).Wait();

        bench.Stop("Stops");

        bench.Dispose();

        benchReusableFactory.Enqueue(bench);

        // Assert
        Assert.That(File.Exists(path));

    }

    [Test]
    public void CreateABenchReusable_TypicalSetupForAnApp_FileWritten()
    {
        var path = Path.Combine(Path.GetTempPath(), "BenchmarkViewer3.csv");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // Arrange 
        var loggerfactory = new BenchLoggerFactory(path);

        var centralLogDataFactory = Globals.Instance.LogDataFactory;

        var benchReusableFactory = new AppBenchReusableFactory(loggerfactory, centralLogDataFactory); // Load this instance into DI container to be available via ctor injection!

        var bench = benchReusableFactory.CreateInstance( "Identifying key");

        // Act  
        bench.Start("Starts");

        Task.Delay(500).Wait();

        bench.AddStep("Do something 1");

        Task.Delay(500).Wait();

        bench.AddStep("Do something 2");

        Task.Delay(500).Wait();

        bench.Stop("Stops");

        bench.Dispose();

        benchReusableFactory.Enqueue(bench);

        // Assert
        Assert.That(File.Exists(path));

    }
}