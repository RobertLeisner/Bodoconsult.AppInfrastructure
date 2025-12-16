Bodoconsult.Office
===================

# Overview

## What does the library

Bodoconsult.Office library simplifies creating OpenXML spredsheets (XLSX) for database data in form of System.Data.DataTable objects.

It was developed with the intention to easily export database data to OpenXML XLSX spreadsheet files for use in Microsoft Excel (R).

For users of older versions of this library: the central classes were renamed starting with package version 1.0.8:

-   Csv => CsvBuilder

-   XslxOpenXml => XslxBuilder

-   ExcelLateBinding => XslxLateBindingBuilder

## How to use the library

The source code contain NUnit test classes, the following source code is extracted from. The samples below show the most helpful use cases for the library.

# Use XlsxBuilder class

The XlsxBuilder class writes the content of a DataTable (in the sample code the variable dt) directly to an OpenXML spreadsheet file.

``` csharp
var path = Path.Combine(FileHelper.TempPath, "openxml.xlsx");

if (File.Exists(path))
{
    File.Delete(path);
}

var dt = TestHelper.GetDataTable("LineChart.xml");

var oe = new XlsxBuilder();
oe.Status += ShowStatus;
oe.Error += ShowError;
oe.NumberFormatDouble = "#,##0.000000";
oe.NewWorkbook(path);

oe.NewSheet("Daten");

oe.SelectRange(1, 1);
oe.Style = XlsxStyles.Header;
oe.SetValue("Hallo Welt1");
			
oe.FillDataTable(dt, 4, 1);

oe.Quit();
```

# Use XlsxLateBindingBuilder class

The XlsxLateBindingBuilder class uses COM late binding to export a DataTable (in the sample code the variable dt) to an Excel spreadsheet.

``` csharp
var dt = TestHelper.GetDataTable("LineChart.xml");

var excel = new XlsxLateBindingBuilder();
excel.Status += ShowStatus;
excel.NewWorkbook();
//if (e.ErrorCode != 0) return;

//excel.NewSheet("Daten");
excel.SelectSheetFirst("TransactionData");
excel.Header("Test");
excel.NumberFormat = "#,##0.000000";
excel.FillDataTable(dt, 4, 1);

excel.NewSheet("Daten2");
excel.Header("Test2");
excel.NumberFormat = "#,##0.00";
excel.FillDataTable(dt, 4, 1);

excel.Dispose();
```

# Use CsvBuilder class

Use the CsvBuilder class to create CSV formatted data files.

``` csharp
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
```

# About us

Bodoconsult (<http://www.bodoconsult.de>) is a Munich based software development company.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

