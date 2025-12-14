// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.Charting.Base.Interfaces;
using Bodoconsult.Charting.Test.Helpers;
using NUnit.Framework;
using System.IO;
using Bodoconsult.Drawing.SkiaSharp.Factories;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Charting.Test.ChartHandlerTests;

[TestFixture]

public class ChartHandler_NoDatabase_LowRes_Tests : BaseChartHandlerTests
{

    public ChartHandler_NoDatabase_LowRes_Tests()
    {
        HighResolution = false;
        UseDatabase = false;
        FileNameExt = "_LowRes";
    }


    [Test]
    public void Ctor_ValidSetup_PropertiesSetCorrectly()
    {
        // Arrange 
        var data = new ChartData();
        var bitmapServiceFactory = new BitmapServiceFactory();

        // Act  
        var result = new ChartHandler(data, bitmapServiceFactory);

        // Assert
        Assert.That(result.ChartData, Is.SameAs(data));

    }

    [Test]
    public void BarChart_AsJpeg()
    {

        var fileName = Path.Combine(TestHelper.TestResultPath, "ScottPlott_BarChart.jpg");

        if (File.Exists(fileName)) File.Delete(fileName);

        var data = new ChartData
        {
            Title = "Test portfolio",
            Copyright = "Testfirma",
            XLabelText = "Anlageklassen",
            YLabelText = "Anteil in %",

            FileName = fileName,
            ChartType = ChartType.BarChart,
            Quality = 60
        };

        TestHelper.LoadDefaultChartStyle(data, HighResolution);

        TestDataHelper.BarChartSample(UseDatabase, data);

        data.ChartStyle.XAxisNumberformat = "0%";

        var bitmapServiceFactory = new BitmapServiceFactory();

        var x = new ChartHandler(data, bitmapServiceFactory);

        x.Export();

        TestHelper.StartFile(fileName);
    }

}