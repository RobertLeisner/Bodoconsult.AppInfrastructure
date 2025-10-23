// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using Bodoconsult.Text.Renderer.PlainText;
using Bodoconsult.Text.Test.TestData;
using NUnit.Framework;
using System.IO;
using Bodoconsult.App.Helpers;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Renderer.Html;
using Bodoconsult.Text.Renderer.Rtf;

namespace Bodoconsult.Text.Test.Documents;

[TestFixture]
internal class DocumentBuilderTests
{

    [Test]
    public void Ctor_ValidSetup_PropsSetCorrectly()
    {
        // Arrange 
        IDocumentFactory factory = new TestReportFactory();
        IDocumentRendererFactory rendererFactory = new PlainTextDocumentRendererFactory();

        // Act  
        var report = new DocumentBuilder(factory, rendererFactory);

        // Assert
        Assert.That(report.DocumentFactory, Is.Not.Null);
        Assert.That(report.DocumentRendererFactory, Is.Not.Null);
    }

    [Test]
    public void CreateDocument_ValidSetup_PropsSetCorrectly()
    {
        // Arrange 
        IDocumentFactory factory = new TestReportFactory();
        IDocumentRendererFactory rendererFactory = new PlainTextDocumentRendererFactory();

        var report = new DocumentBuilder(factory, rendererFactory);

        // Act  
        report.CreateDocument();

        // Assert
        Assert.That(report.Document, Is.Not.Null);
    }

    [Test]
    public void CalculateDocument_ValidSetup_PropsSetCorrectly()
    {
        // Arrange 
        IDocumentFactory factory = new TestReportFactory();
        IDocumentRendererFactory rendererFactory = new PlainTextDocumentRendererFactory();

        var report = new DocumentBuilder(factory, rendererFactory);
        report.CreateDocument();

        // Act  
        report.CalculateDocument();

        // Assert
        Assert.That(report.Document, Is.Not.Null);
    }

    [Test]
    public void RenderDocument_ValidSetup_PropsSetCorrectly()
    {
        // Arrange 
        IDocumentFactory factory = new TestReportFactory();
        IDocumentRendererFactory rendererFactory = new PlainTextDocumentRendererFactory();

        var report = new DocumentBuilder(factory, rendererFactory);
        report.CreateDocument();
        report.CalculateDocument();

        // Act  
        report.RenderDocument();

        // Assert
        Assert.That(report.Document, Is.Not.Null);
    }

    [Test]
    public void SaveAsFile_ValidSetup_FileCreated()
    {
        // Arrange 
        var filePath = Path.Combine(Path.GetTempPath(), "test.txt");

        IDocumentFactory factory = new TestReportFactory();
        IDocumentRendererFactory rendererFactory = new PlainTextDocumentRendererFactory();

        var report = new DocumentBuilder(factory, rendererFactory);
        report.CreateDocument();
        report.CalculateDocument();
        report.RenderDocument();

        // Act  
        Assert.DoesNotThrow(() =>
        {
            report.SaveAsFile(filePath);
        });

        // Assert
        Assert.That(File.Exists(filePath), Is.Not.Null);

        FileSystemHelper.RunInDebugMode(filePath);
    }


    [Test]
    public void SaveAsFile_ValidSetupRealWorldRtf_FileCreated()
    {
        // Arrange 
        var filePath = Path.Combine(Path.GetTempPath(), "test.rtf");

        // Factory for the document content
        IDocumentFactory factory = new TestReportFactory();

        // Renderer factory
        IDocumentRendererFactory rendererFactory = new RtfDocumentRendererFactory();

        // Set up the document builder
        var report = new DocumentBuilder(factory, rendererFactory)
        {
            DocumentMetaData =
            {
                Title = "Securities portfolio management",
                Description = "Basics of sercurity portfolio management",
                Keywords = "Securities, portfolio, management, risk, asset, allocation",
                Company = "Bodoconsult GmbH",
                CompanyWebsite = "http://www.bodoconsult.de",
                Authors = "Robert Leisner",
                IsTocRequired = true,
                IsFiguresTableRequired = true,
                IsEquationsTableRequired = true
            }
        };

        // Load your customized styleset if needed (StylesetHelper.CreateDefaultStyleset() is the default styleset loaded automatically)
        var styleSet = StylesetHelper.CreateDefaultStyleset();
        report.Styleset = styleSet;

        // Now create the document
        report.CreateDocument();

        // Now let TOC, TOF and TOE be calculated if necessary
        report.CalculateDocument();

        // Now render the document
        report.RenderDocument();

        // Act  
        Assert.DoesNotThrow(() =>
        {
            // Save the rendered file
            report.SaveAsFile(filePath);
        });

        // Assert
        Assert.That(File.Exists(filePath), Is.Not.Null);

        FileSystemHelper.RunInDebugMode(filePath);
    }

    [Test]
    public void SaveAsFile_ValidSetupRealWorldHtml_FileCreated()
    {
        // Arrange 
        var filePath = Path.Combine(Path.GetTempPath(), "test.htm");

        // Factory for the document content
        IDocumentFactory factory = new TestReportFactory();

        // Renderer factory
        IDocumentRendererFactory rendererFactory = new HtmlDocumentRendererFactory();

        // Set up the document builder
        var report = new DocumentBuilder(factory, rendererFactory)
        {
            DocumentMetaData =
            {
                Title = "Securities portfolio management",
                Description = "Basics of sercurity portfolio management",
                Keywords = "Securities, portfolio, management, risk, asset, allocation",
                Company = "Bodoconsult GmbH",
                CompanyWebsite = "http://www.bodoconsult.de",
                Authors = "Robert Leisner",
                IsTocRequired = true,
                IsFiguresTableRequired = true,
                IsEquationsTableRequired = true
            }
        };

        // Load your customized styleset if needed (StylesetHelper.CreateDefaultStyleset() is the default styleset loaded automatically)
        var styleSet = StylesetHelper.CreateDefaultStyleset();
        report.Styleset = styleSet;

        // Now create the document
        report.CreateDocument();

        // Now let TOC, TOF and TOE be calculated if necessary
        report.CalculateDocument();

        // Now render the document
        report.RenderDocument();

        // Act  
        Assert.DoesNotThrow(() =>
        {
            // Save the rendered file
            report.SaveAsFile(filePath);
        });

        // Assert
        Assert.That(File.Exists(filePath), Is.Not.Null);

        FileSystemHelper.RunInDebugMode(filePath);

        //var sb = new StringBuilder();
        //report.Document.ToLdmlString(sb, string.Empty);
        //Debug.Print(sb.ToString());
    }
}