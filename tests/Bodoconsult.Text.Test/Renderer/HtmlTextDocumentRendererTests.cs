// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using System.IO;
using Bodoconsult.App.Helpers;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Renderer.Html;
using Bodoconsult.Text.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Text.Test.Renderer;

[TestFixture]
public class HtmlTextDocumentRendererTests
{

    [Test]
    public void Ctor_ValidDocument_PropsSetCorrectly()
    {
        // Arrange 
        var document = TestDataHelper.CreateDocument();
        var factory = new HtmlTextRendererElementFactory();

        // Act  
        var renderer = new HtmlTextDocumentRenderer(document, factory);

        // Assert
        Assert.That(renderer.Document, Is.Not.Null);
        Assert.That(renderer.Styleset, Is.Not.Null);
        Assert.That(renderer.PageStyleBase, Is.Not.Null);
        Assert.That(renderer.Content, Is.Not.Null);
        Assert.That(renderer.Content.Length, Is.EqualTo(0));
    }

    [Test]
    public void RenderIt_ValidDocument_PropsSetCorrectly()
    {
        // Arrange 
        var document = TestDataHelper.CreateDocument();

        var calc = new LdmlCalculator(document);
        calc.UpdateAllTables();
        calc.EnumerateAllItems();
        calc.PrepareAllItems();
        calc.PrepareAllSections();

        var factory = new HtmlTextRendererElementFactory();

        var renderer = new HtmlTextDocumentRenderer(document, factory);

        // Act  
        renderer.RenderIt();

        // Assert
        Assert.That(renderer.Content.Length, Is.Not.EqualTo(0));

        Debug.Print(renderer.Content.ToString());

        if (!Debugger.IsAttached)
        {
            return;
        }

        var filePath = Path.Combine(Path.GetTempPath(), "test.htm");

        renderer.SaveAsFile(filePath);

        FileSystemHelper.RunInDebugMode(filePath);
    }

}