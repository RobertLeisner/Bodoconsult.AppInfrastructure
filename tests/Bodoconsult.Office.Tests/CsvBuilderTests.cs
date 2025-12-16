// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.IO;
using Bodoconsult.Office.Tests.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Office.Tests;

[TestFixture]
public class CsvBuilderTests
{
    [Test]
    public void Export_ValidDataTable_FileCreated()
    {
        // Assert
        var path = Path.Combine(FileHelper.TempPath, "test.csv");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var dt = TestHelper.GetDataTable("LineChart.xml");

        var excel = new CsvBuilder(dt)
        {
            FileName = path
        };

        // Act
        excel.Export();

        // Assert
        Assert.That(File.Exists(path));
    }

}