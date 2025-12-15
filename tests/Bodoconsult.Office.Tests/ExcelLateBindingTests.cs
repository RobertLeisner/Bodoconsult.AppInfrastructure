// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using System.Runtime.Versioning;
using Bodoconsult.Office.Tests.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Office.Tests;

[TestFixture]
[SupportedOSPlatform("windows")]
public class ExcelLateBindingTests
{
    [Test]
    public void FillDataTable_ValidDataTable_FileCreated()
    {
        // Assert
        var dt = TestHelper.GetDataTable("LineChart.xml");

        var excel = new ExcelLateBinding();
        excel.Status += ExcelStatus;
        excel.NewWorkbook();
        //if (e.ErrorCode != 0) return;

        //excel.NewSheet("Daten");
        excel.SelectSheetFirst("TransactionData");
        excel.Header("Test");
        excel.NumberFormat = "#,##0.000000";

        // Act
        excel.FillDataTable(dt, 4, 1);

        excel.NewSheet("Daten2");
        excel.Header("Test2");
        excel.NumberFormat = "#,##0.00";
        excel.FillDataTable(dt, 4, 1);

        excel.Quit();

        // Assert
    }

    //private static void ExcelError(Exception ex, string message)
    //{
    //    var s = $"Error:{ex.Message}:{message}";
    //    Debug.Print(s);
    //}

    private static void ExcelStatus(string message)
    {
        Debug.Print(message);
    }
}