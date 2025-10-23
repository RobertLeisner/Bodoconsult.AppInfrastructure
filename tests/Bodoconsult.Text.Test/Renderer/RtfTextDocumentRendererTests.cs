// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Renderer.Rtf;
using Bodoconsult.Text.Test.Helpers;
using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using Bodoconsult.App.Helpers;

namespace Bodoconsult.Text.Test.Renderer;

[TestFixture]
public class RtfTextDocumentRendererTests
{

    [Test]
    public void Ctor_ValidDocument_PropsSetCorrectly()
    {
        // Arrange 
        var document = TestDataHelper.CreateDocument();
        var factory = new RtfTextRendererElementFactory();

        // Act  
        var renderer = new RtfTextDocumentRenderer(document, factory);

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

        var factory = new RtfTextRendererElementFactory();

        var renderer = new RtfTextDocumentRenderer(document, factory);

        // Act  
        renderer.RenderIt();

        // Assert
        Assert.That(renderer.Content.Length, Is.Not.EqualTo(0));

        Debug.Print(renderer.Content.ToString());

        if (!Debugger.IsAttached)
        {
            return;
        }

        var filePath = Path.Combine(Path.GetTempPath(), "test.rtf");

        renderer.SaveAsFile(filePath);

        FileSystemHelper.RunInDebugMode(filePath);
    }

}