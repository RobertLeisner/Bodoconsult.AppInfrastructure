// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Diagnostics;
using System.IO;
using Bodoconsult.Test.Test.Helpers;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Test.Test;

[TestFixture]
#pragma warning disable 1591
public class TestHelperHtmlTests
{
    private readonly string Path = System.IO.Path.Combine(TestHelper.TempPath, "ProtocolUnitTesting.htm");

    [Test]
    public void TestDiverseMethoden()
    {
        // Arrange
        var helper = new TestDocuHelperHandler();

        helper.AddDebugWindowOutput();
        helper.AddHtmlOutput(Path);

        helper.HelperInitialize();

        // Act

        helper.PrintHeader("Document header");
        helper.PrintClassHeader("1 Class header", "ClassName");
        helper.PrintMethodHeader("1 Method header 1");
        helper.PrintMethodHeader2("1 Method header 2");
   
        helper.PrintClassHeader("2 Class header", "ClassName");
        helper.PrintMethodHeader("2 Method header 1");
        helper.PrintMethodHeader2("2 Method header 2");


        var data = new string[2, 3];

        data[0, 0] = "R0C0";
        data[0, 1] = "R0C1";
        data[1, 0] = "R1C0";
        data[1, 1] = "R1C1";

        helper.PrintTable(data);

        var imagePath = helper.PrintImage();

        //Debug.Print(imagePath);

        helper.CurrentClass = "smaller";
        helper.PrintIt("Hallo klein");
        helper.PrintIt("Hallo klein");

        helper.SetDefaults();
        helper.PrintIt("Hallo normal");

        helper.PrintClassHeader("2 Print data table", "UnitTestTestHelperHtml");
        helper.PrintTable(TestData.GetDataTable());

        // Assert
        helper.HelperFinalize();
        Assert.That(File.Exists(Path));


        if (!Debugger.IsAttached)
        {
            return;
        }

        var p = new Process
        {
            StartInfo = new ProcessStartInfo(Path)
            {
                UseShellExecute = true
            }
        };
        p.Start();


    }
}