﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.IO;
using System.Runtime.Versioning;
using Bodoconsult.App.Helpers;
using Bodoconsult.Pdf.PdfSharp;
using Bodoconsult.Pdf.Stylesets;
using Bodoconsult.Text.Test.Helpers;
using MigraDoc.DocumentObjectModel;
using NUnit.Framework;
using ResourceHelper = Bodoconsult.Text.Test.Helpers.ResourceHelper;

namespace Bodoconsult.Pdf.Test;

[SupportedOSPlatform("windows")]
[TestFixture]
public class PdfCreatorTests
{
    [Test]
    public void TestPdfCreatorWithDefaultStyleSheet()
    {
        var fileName = Path.Combine(TestHelper.TempPath, "pdf1.pdf");
        CreateFile(fileName);
    }


    [Test]
    public void TestPdfCreatorWithDefaultStyleSheetLandScape()
    {
        var fileName = Path.Combine(TestHelper.TempPath, "pdf1quer.pdf");
        CreateFile(fileName, true);
    }

    [Test]
    public void TestPdfCreatorWithDefaultStyleSheet2Files()
    {

        var fileName1 = Path.Combine(TestHelper.TempPath, "pdf1.pdf");

        CreateFile(fileName1);

        var fileName2 = Path.Combine(TestHelper.TempPath, "pdf2.pdf");

        CreateFile(fileName2);

    }


    private void CreateFile(string fileName, bool landscape = false)
    {
        var code = ResourceHelper.GetTextResource("code1.txt").Replace("\\t", "\t");


        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        var styleset = new DefaultStyleSet();
        if (landscape)
        {
            LoadLandScapeSettings(styleset);
        }

        var pdf = new PdfCreator(styleset);

        pdf.SetDocInfo("Test", "Subject", "Author");

        pdf.SetHeader("Header", "Header1", TestHelper.TestLogoImage2);
        pdf.SetFooter("Footer \t<<page>> / <<pages>>");

        pdf.CreateTocSection("Document title");
        pdf.CreateContentSection();

         
        pdf.AddParagraph("Heading 1", "Heading1");

        pdf.AddParagraph(TestDataHelper.MassText, "Normal");

        pdf.AddParagraph(code, "Code");
        pdf.AddParagraph(TestDataHelper.MassText, "Normal");


        pdf.AddDefinitionList(DataHelper.GetDefinitionListAsDataTable(), "DefinitionListTerm", "DefinitionListItem");

        pdf.AddParagraph(TestDataHelper.MassText, "Normal");
        pdf.AddTable(DataHelper.GetSmallDataTable(), "Tabellenüberschrift", "NoHeading1", "some additional info",
            "Details", pdf.Width);


        pdf.AddTableFrame(DataHelper.GetSmallDataTable(), "Tabellenüberschrift Frame", "NoHeading1", "some additional info",
            "Details", pdf.Width / 2);

        pdf.AddTableFrame(DataHelper.GetSmallDataTable(), "Tabellenüberschrift Frame", "NoHeading1", null,
            "Details", pdf.Width / 2);

        pdf.AddParagraph(TestDataHelper.MassText, "Normal");

        pdf.AddParagraph("Heading 2", "Heading1");
        pdf.AddParagraph(TestDataHelper.MassText, "Normal");

        pdf.AddParagraph("Heading 2-1", "Heading2");
        pdf.AddParagraph(TestDataHelper.MassText, "Normal");

        pdf.AddImage(TestHelper.TestChartImage, 10, 6);

        pdf.AddParagraph("Heading 2-2", "Heading2");
        pdf.AddParagraph(TestDataHelper.MassText, "Normal");

        pdf.AddParagraph("Aufzählung 1", "Bullet1");
        pdf.AddParagraph("Aufzählung 2", "Bullet1");
        pdf.AddParagraph("Aufzählung 3", "Bullet1");
        pdf.AddParagraph("Aufzählung 4", "Bullet1");

        pdf.AddParagraph(TestDataHelper.MassText, "Normal");

        pdf.AddParagraph(code, "Code");

        pdf.AddParagraph(TestDataHelper.MassText, "Normal");

        pdf.AddParagraph(TestDataHelper.MassText, "Info");

        pdf.AddParagraph(TestDataHelper.MassText, "Normal");

        pdf.AddParagraph(TestDataHelper.MassText, "Warning");

        pdf.AddParagraph(TestDataHelper.MassText, "Normal");

        pdf.AddParagraph(TestDataHelper.MassText, "Error");

        pdf.AddParagraph("Blubb blabb blubb", "Citation");

        pdf.AddParagraph("Robert Leisner", "CitationSource");

        pdf.AddParagraph(TestDataHelper.MassText, "Normal");

        pdf.RenderToPdf(fileName, false);

        Assert.That(File.Exists(fileName));

        FileSystemHelper.RunInDebugMode(fileName);


    }

    private void LoadLandScapeSettings(IStyleSet styleSet)
    {
        var ps = styleSet.PageSetup;
        ps.Orientation = Orientation.Landscape;
        ps.LeftMargin = Unit.FromCentimeter(1.5);
        ps.RightMargin = Unit.FromCentimeter(1.5);
        ps.TopMargin = Unit.FromCentimeter(1.5);
        ps.BottomMargin = Unit.FromCentimeter(1.5);


        var width = Unit.FromCentimeter( ps.PageHeight.Centimeter - ps.TopMargin.Centimeter - ps.BottomMargin.Centimeter);

        var style = styleSet.Normal;
        style.Font.Name = "Arial Narrow";
        style.Font.Size = 9;

        // Spezielles Format für Tabellenbasis (nicht ändern!)
        style = styleSet.NormalTable;
        style.Font.Name = "Arial Narrow";
        style.Font.Size = 8;
        style.ParagraphFormat.SpaceBefore = 0;
        style.ParagraphFormat.SpaceAfter = 0;
        style.ParagraphFormat.PageBreakBefore = false;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

        style = styleSet.Heading1;
        style.Font.Name = "Arial Black";
        style.Font.Size = 12;
        style.Font.Color = Colors.Black;
        style.ParagraphFormat.PageBreakBefore = true;
        style.ParagraphFormat.KeepTogether = true;
        style.ParagraphFormat.KeepWithNext = true;
        style.ParagraphFormat.SpaceAfter = 2;
        style.ParagraphFormat.SpaceBefore = 4;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

        style = styleSet.Title;
        style.Font.Name = "Arial Black";
        style.Font.Size = 16;
        style.Font.Color = Colors.Black;
        style.ParagraphFormat.SpaceAfter = 9;
        style.ParagraphFormat.SpaceBefore = 12;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

        style = styleSet.NoHeading1;
        style.Font.Name = "Arial Black";
        style.Font.Size = 10;
        style.Font.Color = Colors.Black;
        style.ParagraphFormat.SpaceAfter = 2;
        style.ParagraphFormat.SpaceBefore = 4;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

        //style.ParagraphFormat.
        //style.ParagraphFormat.Shading.Color = Colors.Orange;


        style = styleSet.ChartTitle;
        style.Font.Name = "Arial Narrow";
        style.Font.Size = 10;
        style.Font.Bold = true;
        style.Font.Color = Colors.Black;
        style.ParagraphFormat.SpaceBefore = 3;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        style.ParagraphFormat.SpaceAfter = 3;

        style = styleSet.ChartYLabel;
        style.Font.Name = "Arial Narrow";
        style.Font.Size = 8;
        style.Font.Color = Colors.Black;

        style = styleSet.Toc1;
        style.Font.Name = "Arial";
        style.Font.Size = 10;
        style.Font.Color = Colors.Black;
        style.ParagraphFormat.SpaceBefore = 3;
        style.ParagraphFormat.TabStops.ClearAll();
        style.ParagraphFormat.AddTabStop(width, TabAlignment.Right);
        style.ParagraphFormat.SpaceAfter = 0;
        style.ParagraphFormat.Borders.Bottom.Width = 0;
        style.ParagraphFormat.Borders.Top.Width = 0;
        style.ParagraphFormat.Borders.Right.Width = 0;
        style.ParagraphFormat.Borders.Left.Width = 0;


        style = styleSet.TocHeading;
        style.Font.Name = "Arial Black";
        style.Font.Size = 12;
        style.Font.Color = Colors.Black;
        style.ParagraphFormat.SpaceAfter = 3;
        style.ParagraphFormat.SpaceAfter = 6;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

        // Kopfzeile
        style = styleSet.Header;
        style.Font.Name = "Arial Narrow";
        style.Font.Size = 8;
        style.Font.Color = Colors.Black;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Right;
        style.ParagraphFormat.SpaceAfter = Unit.FromCentimeter(0.2);
        style.ParagraphFormat.SpaceBefore = Unit.FromCentimeter(0.5);
        style.ParagraphFormat.Borders.Bottom.Width = 1;
        style.ParagraphFormat.Borders.Bottom.Color = Colors.Black;


        style = styleSet.Details;
        style.Font.Name = "Arial Narrow";
        style.Font.Size = 10;
        style.Font.Color = Colors.Black;
        style.ParagraphFormat.SpaceAfter = 6;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

        style = styleSet.ChartCell;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

        style = styleSet.Footer;
        style.Font.Name = "Arial Narrow";
        style.Font.Size = 8;
        style.Font.Color = Colors.Black;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        //style.ParagraphFormat.SpaceAfter = Unit.FromCentimeter(0.5);
        style.ParagraphFormat.SpaceBefore = Unit.FromCentimeter(0.5);
        style.ParagraphFormat.TabStops.ClearAll();
        style.ParagraphFormat.AddTabStop(width, TabAlignment.Right);
        style.ParagraphFormat.Borders.Top.Width = 1;
        style.ParagraphFormat.Borders.Top.Color = Colors.Black;

        
    }
}