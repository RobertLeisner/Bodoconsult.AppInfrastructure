// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Info: https://ludovicperrichon.com/create-a-word-document-with-openxml-and-c/

using Bodoconsult.App.Helpers;
using Bodoconsult.Office.Tests.Helpers;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.Office.Tests.Models;

namespace Bodoconsult.Office.Tests;

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
        Assert.That(docx.docx, Is.Null);
        Assert.That(docx.mainDocumentPart, Is.Null);
        Assert.That(docx.body, Is.Null);

        docx.Dispose();
    }

    [Test]
    public void Create_ValidSetup_DocxCreated()
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
        Assert.That(docx.docx, Is.Not.Null);
        Assert.That(docx.mainDocumentPart, Is.Not.Null);
        Assert.That(docx.body, Is.Not.Null);

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

        // Act  
        docx.AddParagraph("Blubb", "Normal");

        // Assert
        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.docx, Is.Not.Null);
        Assert.That(docx.mainDocumentPart, Is.Not.Null);
        Assert.That(docx.body, Is.Not.Null);

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
        var color1 = new Color() { Val = "2F5496" };
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

        // Act  
        docx.AddNewStyle( "heading1", "heading 1", styleRunPropertiesH1, 2);
        docx.AddParagraph("Heading 1", "heading1");

        // Assert
        docx.AddParagraph("Blubb", "Normal");

        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.docx, Is.Not.Null);
        Assert.That(docx.mainDocumentPart, Is.Not.Null);
        Assert.That(docx.body, Is.Not.Null);

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
            FontColor = TypoColors.Cyan,
            FontName = "Arial Black",
            FontSize = 20
        };

        var docx = new DocxBuilder();
        docx.CreateDocument(path);

        // Act  
        docx.AddNewStyle("heading1", "heading 1", style, 2);
        docx.AddParagraph("Heading 1", "heading1");

        // Assert
        docx.AddParagraph("Blubb", "Normal");

        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.docx, Is.Not.Null);
        Assert.That(docx.mainDocumentPart, Is.Not.Null);
        Assert.That(docx.body, Is.Not.Null);

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
        var color1 = new Color() { Val = "2F5496" };
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

        // Act  
        docx.AddNewStyle("heading1", "heading 1", styleRunPropertiesH1, 2);
        docx.AddParagraph("Heading 1", "heading1");
        docx.AddParagraph("Blubb", "Normal");

        // Assert
        docx.AddImage(imagePath, "Normal", 600, 400);

        Assert.That(File.Exists(path));

        Assert.That(docx, Is.Not.Null);
        Assert.That(docx.docx, Is.Not.Null);
        Assert.That(docx.mainDocumentPart, Is.Not.Null);
        Assert.That(docx.body, Is.Not.Null);

        docx.Dispose();

        FileSystemHelper.RunInDebugMode(path);
    }
}