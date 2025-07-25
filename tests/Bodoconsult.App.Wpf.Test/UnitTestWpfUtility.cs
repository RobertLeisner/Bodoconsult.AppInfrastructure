// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.IO;
using System.Runtime.Versioning;
using System.Threading;
using System.Windows.Controls;
using Bodoconsult.App.Wpf.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Wpf.Application.Test;

[TestFixture]
[RequiresThread(ApartmentState.STA)]
[SupportedOSPlatform("windows")]
public class UnitTestWpfUtility
{
    //[Test]
    //public void TestFindResource_OnlyRessourceName()
    //{

    //    var brush = (Brush)WpfUtility.FindResource("BackgroundBrush02");

    //    Assert.IsNotNull(brush);
    //}

    [Test]
    public void TestSaveElementAsXamlFile()
    {

        const string xamlFile = @"C:\temp\XamlTestFile.xaml";

        if (File.Exists(xamlFile)) File.Delete(xamlFile);

        var button = new Button { Content = "Hallo" };

        WpfHelper.SaveElementAsXamlFile(button, xamlFile);

        Assert.That(File.Exists(xamlFile));

    }


    [Test]
    public void TestLoadElementFromXamlFile()
    {

        const string xamlFile = @"C:\temp\XamlTestFile.xaml";

        if (File.Exists(xamlFile))
        {
            File.Delete(xamlFile);
        }

        var button = new Button { Content = "Hallo" };

        WpfHelper.SaveElementAsXamlFile(button, xamlFile);

        Assert.That(File.Exists(xamlFile));

        var buttonErg = (Button)WpfHelper.LoadElementFromXamlFile(xamlFile);

        Assert.That(buttonErg != null);
        Assert.That(buttonErg.Content.ToString() == "Hallo");
    }

}


[TestFixture]
public class UnitTestDisptacherService
{
    ///// <summary>
    ///// Constructor to initialize class
    ///// </summary>
    //public UnitTestDisptacherService()
    //{

    //}


    ///// <summary>
    ///// Runs in front of each test method
    ///// </summary>
    //[TestInitialize]
    //public void Setup()
    //{


    //}

    ///// <summary>
    ///// Cleanup aft test methods
    ///// </summary>
    //[TestCleanup]
    //public void Cleanup()
    //{


    //}


}