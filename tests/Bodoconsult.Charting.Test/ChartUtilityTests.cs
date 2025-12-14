// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System;
using System.Diagnostics;
using Bodoconsult.Charting.Base.Interfaces;
using Bodoconsult.Charting.Util;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Charting.Test;

[TestFixture]
public class ChartUtilityTests
{

    const double Tolerance = 0.00000001;

    ///// <summary>
    ///// Constructor to initialize class
    ///// </summary>
    //public ChartUtilityTests()
    //{

    //}


    /// <summary>
    /// Runs in front of each test method
    /// </summary>
    [SetUp]
    public void Setup()
    {


    }

    /// <summary>
    /// Cleanup aft test methods
    /// </summary>
    [TearDown]
    public void Cleanup()
    {

            
    }


    [Test]
    public void TestMappingChartItemData()
    {

        var x = new ChartItemData {XValue = 1};


        var y = (IChartItemData) x;


        var z = (ChartItemData) y;



    }


    [Test]
    public void GetMinMaxForLineChart_ValidInput1_ScalinglineChartsMechanism()
    {
        //Arrange
        var max = 10.17;
        var min = 0.0;

        // Act
        var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

        //Assert
        Debug.Print("{0:#,##0.000000}", min);
        Debug.Print("{0:#,##0.000000}", max);
        Debug.Print("{0:#,##0.000000}", interval);

        Assert.That(max - 11.0 <Tolerance);
        Assert.That(min - 0.0 < Tolerance);
        Assert.That(Math.Abs(interval - 1) < Tolerance);
    }

    [Test]
    public void GetMinMaxForLineChart_ValidInput2_ScalinglineChartsMechanism()
    {
        //Arrange
        var max = 1.47;
        var min = 0.76;

        // Act
        var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

        //Assert
        Debug.Print("{0:#,##0.000000}", min);
        Debug.Print("{0:#,##0.000000}", max);
        Debug.Print("{0:#,##0.000000}", interval);

        Assert.That(max - 1.5 < Tolerance);
        Assert.That(min - 0.7 < Tolerance);
        Assert.That(Math.Abs(interval - 0.1) < Tolerance);
    }


    [Test]
    public void GetMinMaxForLineChart_SmallValues_ScalinglineChartsMechanism()
    {
        //Arrange
        var max = 0.00004556;
        var min = 0.000003;

        // Act
        var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

        //Assert
        Debug.Print("{0:#,##0.000000}", min);
        Debug.Print("{0:#,##0.000000}", max);
        Debug.Print("{0:#,##0.000000}", interval);


        Assert.That(max > 0 && max - 0.00005 < Tolerance);
        Assert.That(min - 0.00000 < Tolerance);
        Assert.That(Math.Abs(interval - 0.00001) < Tolerance);


    }


    [Test]
    public void GetMinMaxForLineChart_SmallValuesMinus_ScalinglineChartsMechanism1()
    {
        //Arrange
        var max = -0.00004556;
        var min = -0.000003;

        // Act
        var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

        //Assert
        Debug.Print("{0:#,##0.000000}", min);
        Debug.Print("{0:#,##0.000000}", max);
        Debug.Print("{0:#,##0.000000}", interval);


        Assert.That(max < 0 && max + 0.00003 < Tolerance);
        Assert.That(min + 0.000003 < Tolerance);
        Assert.That(Math.Abs(interval - 0.00001) < Tolerance);


    }

    [Test]
    public void GetMinMaxForLineChart_SmallValuesOneNull_ScalinglineChartsMechanism()
    {
        //Arrange
        var max = 0.00004556;
        var min = 0.00000;

        // Act
        var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

        //Assert
        Debug.Print("{0:#,##0.000000}", min);
        Debug.Print("{0:#,##0.000000}", max);
        Debug.Print("{0:#,##0.000000}", interval);


        Assert.That(max > 0 && max - 0.00005 < Tolerance);
        Assert.That(min > -0.00000001 && min - 0.0 < Tolerance);
        // Assert.That(Math.Abs(interval - 0.00001) < Tolerance);
    }


    [Test]
    public void GetMinMaxForLineChart_SmallValuesOneNullMinus_ScalinglineChartsMechanism()
    {
        //Arrange
        var max = 0.00000;
        var min = -0.00004556;

        // Act
        var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

        //Assert
        Debug.Print("{0:#,##0.000000}", min);
        Debug.Print("{0:#,##0.000000}", max);
        Debug.Print("{0:#,##0.000000}", interval);


        Assert.That(max >= 0 && max - 0.0 < Tolerance);
        Assert.That(min + 0.00005 < Tolerance);
        Assert.That(Math.Abs(interval - 0.00001) < Tolerance);


    }


    [Test]
    public void GetMinMaxForLineChart_BigValues_ScalinglineChartsMechanism()
    {
        //Arrange
        var max = 196.46;
        var min = 101.96;

        // Act
        var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

        //Assert
        Debug.Print("{0:#,##0.000000}", min);
        Debug.Print("{0:#,##0.000000}", max);
        Debug.Print("{0:#,##0.000000}", interval);


        Assert.That(max > 0 && max - 200 < Tolerance);
        Assert.That(min > -0.00000001 && min - 100.0 < Tolerance);
        Assert.That(Math.Abs(interval - 10) < Tolerance);


    }

    [Test]
    public void GetMinMaxForLineChart_SmallValuesOneNullOneOne_ScalinglineChartsMechanism1()
    {
        //Arrange
        var max = 1.00000;
        var min = 0.0;

        // Act
        var interval = ChartUtility.GetMinMaxForLineChart(ref min, ref max);

        //Assert
        Debug.Print("{0:#,##0.000000}", min);
        Debug.Print("{0:#,##0.000000}", max);
        Debug.Print("{0:#,##0.000000}", interval);


        Assert.That(max >= 0 && max - 1.0 < Tolerance);
        Assert.That(min + 0.0000 < Tolerance);
        Assert.That(Math.Abs(interval - 0.1) < Tolerance);


    }

}