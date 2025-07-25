// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Wpf.Services;
using NUnit.Framework;

namespace Bodoconsult.Wpf.Application.Test;

[TestFixture]
public class UnitTestLanguageResourceService
{

    private const string German =
        "pack://application:,,,/Bodoconsult.Wpf.Application.Test;component/Resources/Culture.de.xaml";

    private const string English =
        "pack://application:,,,/Bodoconsult.Wpf.Application.Test;component/Resources/Culture.en.xaml";



    [Test]
    public void TestFindResource()
    {
        //Arrange
        LanguageResourceService.RegisterLanguageResourceFile("de", "UnitTest", German);
        LanguageResourceService.RegisterLanguageResourceFile("en", "UnitTest", English);


        // Act
        var erg = LanguageResourceService.FindResource("de", "UnitTest", "Simulation.Asset");

        //Assert
        Assert.That(erg == "Gegenstand");

        erg = LanguageResourceService.FindResource("en", "UnitTest", "Simulation.Asset");
        Assert.That(erg == "Asset");

        erg = LanguageResourceService.FindResource("de", "UnitTest", "Simulation.Asset");

        //Assert
        Assert.That(erg == "Gegenstand");
    }
}