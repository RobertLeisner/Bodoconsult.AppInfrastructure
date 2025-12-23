// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Info: https://ludovicperrichon.com/create-a-word-document-with-openxml-and-c/

// https://pvs-studio.com/en/blog/posts/csharp/0856/

// https://stackoverflow.com/questions/14144599/open-xml-word-c-sharp-split-into-two-columns

// https://github.com/devel0/netcore-docx/blob/master/src/docx/Styles.cs

using System.Collections.Generic;
using System.IO;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Helpers;
using Bodoconsult.Office.Tests.Helpers;
using Bodoconsult.Office.Tests.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using NUnit.Framework;

namespace Bodoconsult.Office.Tests;

// https://woodsworkblog.wordpress.com/2012/08/06/add-header-and-footer-to-an-existing-word-document-with-openxml-sdk-2-0/

[TestFixture]
internal class DocxBuilderTests
{

    [Test]
    public void Ctor_ValidSetup_PropsSetCorrectly()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // Act  
        var docx = new DocxBuilder();

        // Assert
        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Null);
        Assert.That(docx.MainDocumentPart, Is.Null);
        Assert.That(docx.Body, Is.Null);

        docx.Dispose();
    }

    [Test]
    public void Create_ValidSetupFilePath_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var docx = new DocxBuilder();

        // Act  
        docx.CreateDocument(path);

        // Assert
        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();
    }

    [Test]
    public void Create_ValidSetupMemoryStream_DocxCreated()
    {
        // Arrange 
        var docx = new DocxBuilder();

        // Act  
        docx.CreateDocument();

        // Assert

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();
    }

    [Test]
    public void SaveDocument_ValidSetupMemoryStream_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var docx = new DocxBuilder();
        docx.CreateDocument();
        docx.AddParagraph("Blubb", "Normal");

        // Act  
        docx.SaveDocument(path);

        // Assert
        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void AddSection_ValidSetupMemoryStream_DocxCreated()
    {
        // Arrange 
        var docx = new DocxBuilder();
        docx.CreateDocument();

        // Act  
        docx.AddSection();

        // Assert
        Assert.That(docx.CurrentSection, Is.Not.Null);

        docx.Dispose();
    }

    [Test]
    public void AddParagraph_SimpleTextNormal_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection();

        // Act  
        docx.AddParagraph("Blubb", "Normal");

        // Assert
        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void AddParagraph_MultipleRunsNormal_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection();
        docx.SetBasicPageProperties(21, 29.4, 5, 2, 2, 2);

        // Act  
        var runs = new List<OpenXmlElement>
        {
            DocxBuilder.CreateRun("Das ist "),
            DocxBuilder.CreateRunBold("ein "),
            DocxBuilder.CreateRunItalic("Test für einen Hyperlink "),
            DocxBuilder.CreateHyperlink("http://www.bodoconsult.de", "Bodoconsult", docx.MainDocumentPart),
            DocxBuilder.CreateRun(" im Text!"),
            DocxBuilder.CreateLineBreak(),
            DocxBuilder.CreateRun("Das ist 1 ..."),
            DocxBuilder.CreatePageBreak(),
            DocxBuilder.CreateRun("Das ist 2 ..."),
        };

        docx.AddParagraph(runs, "Normal");

        // Assert
        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void AddParagraph_MultipleSections_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection(false);
        docx.SetBasicPageProperties(21, 29.4, 5, 2, 2, 2);

        docx.AddParagraph("Section1", "Normal");

        // Act  
        var section = docx.AddSection();


        docx.SetBasicPageProperties(21, 29.4, 8, 2, 2, 2);

        var runs = new List<OpenXmlElement>
        {
            DocxBuilder.CreateRun("Das ist "),
            DocxBuilder.CreateRunBold("ein "),
            DocxBuilder.CreateRunItalic("Test für einen Hyperlink "),
            DocxBuilder.CreateHyperlink("http://www.bodoconsult.de", "Bodoconsult", docx.MainDocumentPart),
            DocxBuilder.CreateRun(" im Text!"),
            DocxBuilder.CreateLineBreak(),
            DocxBuilder.CreateRun("Das ist 1 ..."),
            DocxBuilder.CreatePageBreak(),
            DocxBuilder.CreateRun("Das ist 2 ..."),
        };

        docx.AddParagraph(runs, "Normal");

        // Assert
        Assert.That(File.Exists(path));

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }


    [Test]
    public void AddFooterToCurrentSection_MultipleSectionsWithPageNumbering_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection(false);
        docx.SetBasicPageProperties(21, 29.4, 5, 2, 2, 2);
        docx.AddHeaderToCurrentSection("Header section 1", 10);
        docx.AddFooterToCurrentSection($"Footer section 1\t{ITypography.PageFieldIndicator}", 10);

        docx.AddParagraph("Section1", "Normal");

        // Act  
        var section = docx.AddSection(true, true);
        docx.SetBasicPageProperties(21, 29.4, 8, 2, 2, 2);
        docx.AddHeaderToCurrentSection("Header section 2", 10);
        docx.AddFooterToCurrentSection("Footer section 2\t@Page", 10);

        var runs = new List<OpenXmlElement>
        {
            DocxBuilder.CreateRun("Das ist "),
            DocxBuilder.CreateRunBold("ein "),
            DocxBuilder.CreateRunItalic("Test für einen Hyperlink "),
            DocxBuilder.CreateHyperlink("http://www.bodoconsult.de", "Bodoconsult", docx.MainDocumentPart),
            DocxBuilder.CreateRun(" im Text!"),
            DocxBuilder.CreateLineBreak(),
            DocxBuilder.CreateRun("Das ist 1 ..."),
            DocxBuilder.CreatePageBreak(),
            DocxBuilder.CreateRun("Das ist 2 ..."),
        };

        docx.AddParagraph(runs, "Normal");

        // Assert
        Assert.That(File.Exists(path));

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void AddHeaderToCurrentSection_MultipleSections_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection(false);
        docx.AddHeaderToCurrentSection("Inhaltsverzeichnis", 10);
        docx.SetBasicPageProperties(21, 29.4, 5, 2, 2, 2);

        docx.AddParagraph("Section1", "Normal");

        // Act  
        var section = docx.AddSection();
        docx.AddHeaderToCurrentSection("Hauptteil", 10);

        docx.SetBasicPageProperties(21, 29.4, 8, 2, 2, 2);

        var runs = new List<OpenXmlElement>
        {
            DocxBuilder.CreateRun("Das ist "),
            DocxBuilder.CreateRunBold("ein "),
            DocxBuilder.CreateRunItalic("Test für einen Hyperlink "),
            DocxBuilder.CreateHyperlink("http://www.bodoconsult.de", "Bodoconsult", docx.MainDocumentPart),
            DocxBuilder.CreateRun(" im Text!"),
            DocxBuilder.CreateLineBreak(),
            DocxBuilder.CreateRun("Das ist 1 ..."),
            DocxBuilder.CreatePageBreak(),
            DocxBuilder.CreateRun("Das ist 2 ..."),
        };

        docx.AddParagraph(runs, "Normal");

        // Assert
        Assert.That(File.Exists(path));

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void AddFooterToCurrentSection_MultipleSections_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection(false);
        docx.AddFooterToCurrentSection("Inhaltsverzeichnis", 10);
        docx.SetBasicPageProperties(21, 29.4, 5, 2, 2, 2);

        docx.AddParagraph("Section1", "Normal");

        // Act  
        var section = docx.AddSection();
        docx.AddFooterToCurrentSection("Hauptteil", 10);

        docx.SetBasicPageProperties(21, 29.4, 8, 2, 2, 2);

        var runs = new List<OpenXmlElement>
        {
            DocxBuilder.CreateRun("Das ist "),
            DocxBuilder.CreateRunBold("ein "),
            DocxBuilder.CreateRunItalic("Test für einen Hyperlink "),
            DocxBuilder.CreateHyperlink("http://www.bodoconsult.de", "Bodoconsult", docx.MainDocumentPart),
            DocxBuilder.CreateRun(" im Text!"),
            DocxBuilder.CreateLineBreak(),
            DocxBuilder.CreateRun("Das ist 1 ..."),
            DocxBuilder.CreatePageBreak(),
            DocxBuilder.CreateRun("Das ist 2 ..."),
        };

        docx.AddParagraph(runs, "Normal");

        // Assert
        Assert.That(File.Exists(path));

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void AddParagraph_MultipleSections2Columns_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection(false);
        docx.SetBasicPageProperties(21, 29.4, 2, 2, 2, 2);

        docx.AddParagraph("Section1", "Normal");

        // Act  
        docx.Add2ColumnsSection(0.5);
        docx.SetBasicPageProperties(21, 29.4, 8, 2, 2, 2);

        var runs = new List<OpenXmlElement>
        {
            DocxBuilder.CreateRun("Das ist "),
            DocxBuilder.CreateRunBold("ein "),
            DocxBuilder.CreateRunItalic("Test für einen Hyperlink "),
            DocxBuilder.CreateHyperlink("http://www.bodoconsult.de", "Bodoconsult", docx.MainDocumentPart),
            DocxBuilder.CreateRun(" im Text!"),
            DocxBuilder.CreateLineBreak(),
            DocxBuilder.CreateRun("Das ist 1 ..."),
            DocxBuilder.CreateColumnBreak(),
            DocxBuilder.CreateRun("Das ist 2 ..."),
            DocxBuilder.CreatePageBreak(),
            DocxBuilder.CreateRun("Das ist 3 ..."),

        };

        docx.AddParagraph(runs, "Normal");

        // Assert
        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void AddParagraph_SimpleTextHeading1_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // Heading 1
        var styleRunPropertiesH1 = new StyleRunProperties();
        var color1 = new Color { Val = "2F5496" };
        // Specify a 16 point size. 16x2 because it’s half-point size
        var fontSize1 = new FontSize
        {
            Val = new StringValue("32")
        };
        styleRunPropertiesH1.Append(color1);
        styleRunPropertiesH1.Append(fontSize1);
        // Check above at the begining of the word creation to check where mainPart come from
        

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection();

        // Act  
        docx.AddNewStyle( "heading1", "heading 1", styleRunPropertiesH1, 2);
        docx.AddParagraph("Heading 1", "heading1");

        // Assert
        docx.AddParagraph("Blubb", "Normal");

        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }


    [Test]
    public void AddParagraph_SimpleTextDemoStyleHeading1_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // Heading 1
        var style = new DemoStyle
        {
            TypoFontColor = TypoColors.Cyan,
            FontName = "Arial Black",
            FontSize = 20,
            Bold = true,
            Italic = true,
            TypoMargins =
            {
                Bottom = 2.5,
                Left = 1.5
            },
            TextAlignment = TypoTextAlignment.Center,
            TypoBorderThickness =
            {
                Bottom = 0.1,
                Left = 0.1,
                Right = 0.1,
                Top = 0.1,
            },
            TypoPaddings =
            {
                Bottom = 0.1,
                Left = 0.1,
                Right = 0.1,
                Top = 0.1,
            }
        };

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection();

        // Act  
        docx.AddNewStyle("heading1", "heading 1", style, 2);
        docx.AddParagraph("Heading 1", "heading1");

        // Assert
        docx.AddParagraph("Blubb", "Normal");

        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void AddParagraph_Image_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var imagePath = Path.Combine(TestHelper.TestDataPath, "image.png");

        // Heading 1
        var styleRunPropertiesH1 = new StyleRunProperties();
        var color1 = new Color { Val = "2F5496" };
        // Specify a 16 point size. 16x2 because it’s half-point size
        var fontSize1 = new FontSize
        {
            Val = new StringValue("32")
        };
        styleRunPropertiesH1.Append(color1);
        styleRunPropertiesH1.Append(fontSize1);
        // Check above at the begining of the word creation to check where mainPart come from


        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection();

        // Act  
        docx.AddNewStyle("heading1", "heading 1", styleRunPropertiesH1, 2);
        docx.AddParagraph("Heading 1", "heading1");
        docx.AddParagraph("Blubb", "Normal");

        // Assert
        docx.AddImage(imagePath, "Normal", 600, 400);

        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void SetBasicPageProperties_SimpleTextHeading1_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // Heading 1
        var styleRunPropertiesH1 = new StyleRunProperties();
        var color1 = new Color { Val = "2F5496" };
        // Specify a 16 point size. 16x2 because it’s half-point size
        var fontSize1 = new FontSize
        {
            Val = new StringValue("32")
        };
        styleRunPropertiesH1.Append(color1);
        styleRunPropertiesH1.Append(fontSize1);
        // Check above at the begining of the word creation to check where mainPart come from


        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection();
        
        // Act 
        docx.SetBasicPageProperties(21, 29.4, 5, 2, 2, 2);
        docx.AddNewStyle("heading1", "heading 1", styleRunPropertiesH1, 2);
        docx.AddParagraph("Heading 1", "heading1");

        // Assert
        docx.AddParagraph("Blubb", "Normal");

        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void AddMetadata_ValidSetupFilePath_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // Heading 1
        var styleRunPropertiesH1 = new StyleRunProperties();
        var color1 = new Color { Val = "2F5496" };
        // Specify a 16 point size. 16x2 because it’s half-point size
        var fontSize1 = new FontSize
        {
            Val = new StringValue("32")
        };
        styleRunPropertiesH1.Append(color1);
        styleRunPropertiesH1.Append(fontSize1);

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection();
        docx.SetBasicPageProperties(21, 29.4, 5, 2, 2, 2);
        docx.AddNewStyle("heading1", "heading 1", styleRunPropertiesH1, 2);
        docx.AddParagraph("Heading 1", "heading1");

        // Act  
        docx.AddMetadata("RL", "BCG", "Blubb TitlePage");

        // Assert
        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }

    [Test]
    public void AddList_ValidSetupFilePath_DocxCreated()
    {
        // Arrange 
        var path = Path.Combine(FileHelper.TempPath, "test.docx");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // Heading 1
        var styleRunPropertiesH1 = new StyleRunProperties();
        var color1 = new Color { Val = "2F5496" };
        // Specify a 16 point size. 16x2 because it’s half-point size
        var fontSize1 = new FontSize
        {
            Val = new StringValue("32")
        };
        styleRunPropertiesH1.Append(color1);
        styleRunPropertiesH1.Append(fontSize1);

        var docx = new DocxBuilder();
        docx.CreateDocument(path);
        docx.AddSection();
        docx.SetBasicPageProperties(21, 29.4, 5, 2, 2, 2);
        docx.AddNewStyle("heading1", "heading 1", styleRunPropertiesH1, 2);
        docx.AddParagraph("Heading 1", "heading1");

        // Act  
        var listItems = new List<List<OpenXmlElement>>();

        for (var i = 0; i < 10; i++)
        {
            var runs = new List<OpenXmlElement> { DocxBuilder.CreateRun($"Test item {i}") };

            listItems.Add(runs);
        }

        docx.AddList(listItems, "Normal", ListStyleTypeEnum.Circle);

        // Assert
        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.Docx, Is.Not.Null);
        Assert.That(docx.MainDocumentPart, Is.Not.Null);
        Assert.That(docx.Body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }
}