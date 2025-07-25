// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Services;
using NUnit.Framework;

namespace Bodoconsult.Wpf.Application.Test;

[TestFixture]
public class ResourceFinderServiceTests
{

    private const string German =
        "pack://application:,,,/Bodoconsult.Wpf.Application.Test;component/Resources/Culture.de.xaml";

    private const string English =
        "pack://application:,,,/Bodoconsult.Wpf.Application.Test;component/Resources/Culture.en.xaml";


    ///// <summary>
    ///// Constructor to initialize class
    ///// </summary>
    //public UnitTestResourceFinderService()
    //{

    //}


    /// <summary>
    /// Runs in front of each test method
    /// </summary>
    [SetUp]
    public void Setup()
    {
        ResourceFinderService.ClearCache();
    }

    ///// <summary>
    ///// Cleanup aft test methods
    ///// </summary>
    //[TestCleanup]
    //public void Cleanup()
    //{


    //}




    [Test]
    public void FindResource_ExistingResources_ResourcesFound()
    {
        //Arrange

        // Act
        var erg = (string)ResourceFinderService.FindResource(German, "Simulation.Asset");

        //Assert
        Assert.That(erg, Is.EqualTo("Gegenstand"));

        erg = (string)ResourceFinderService.FindResource(English, "Simulation.Asset");
        Assert.That(erg, Is.EqualTo("Asset"));

        erg = (string)ResourceFinderService.FindResource(German, "Simulation.Asset");

        //Assert
        Assert.That(erg, Is.EqualTo("Gegenstand"));

        Assert.That(ResourceFinderService.Count, Is.EqualTo(2));
    }


    [Test]
    public void SetResource_ExistingResource_ResourceIsSet()
    {
        //Arrange

        // Act
        var erg = (string)ResourceFinderService.FindResource(German, "Simulation.Asset");

        //Assert
        Assert.That(erg, Is.EqualTo("Gegenstand"));

        ResourceFinderService.SetResource(German, "Simulation.Asset", "Asset");
        erg = (string)ResourceFinderService.FindResource(German, "Simulation.Asset");
        Assert.That(erg, Is.EqualTo("Asset"));
        ResourceFinderService.SetResource(German, "Simulation.Asset", "Gegenstand");

        erg = (string)ResourceFinderService.FindResource(German, "Simulation.Asset");

        //Assert
        Assert.That(erg, Is.EqualTo("Gegenstand"));

        Assert.That(ResourceFinderService.Count, Is.EqualTo(1));
    }

    [Test]
    public void SetResourceGeneric_ExistingResource_ResourceIsSet()
    {
        //Arrange

        // Act
        var erg = (string)ResourceFinderService.FindResource(German, "Simulation.Asset");

        //Assert
        Assert.That(erg == "Gegenstand");

        ResourceFinderService.SetResource<string>(German, "Simulation.Asset", "Asset");
        erg = (string)ResourceFinderService.FindResource(German, "Simulation.Asset");
        Assert.That(erg == "Asset");
        ResourceFinderService.SetResource<string>(German, "Simulation.Asset", "Gegenstand");

        erg = (string)ResourceFinderService.FindResource(German, "Simulation.Asset");

        //Assert
        Assert.That(erg == "Gegenstand");

        Assert.That(ResourceFinderService.Count, Is.EqualTo(1));
    }
}