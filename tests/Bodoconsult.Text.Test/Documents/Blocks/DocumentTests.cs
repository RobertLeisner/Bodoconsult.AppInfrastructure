// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System;
using System.Diagnostics;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Text.Test.Documents.Blocks;

[TestFixture]
internal class DocumentTests
{

    [Test]
    public void AddBlock_Section_SectionAdded()
    {
        // Arrange 
        var doc = new Document();

        var section = new Section();

        // Act  
        Assert.DoesNotThrow(() => { doc.AddBlock(section); });

        // Assert
        Assert.That(doc.ChildBlocks.Count, Is.EqualTo(1));

    }

    [Test]
    public void AddBlock_Paragraph_ThrowsArgumentException()
    {
        // Arrange 
        var doc = new Document();

        var paragraph = new Paragraph();

        // Act  
        Assert.Throws<ArgumentException>(() => { doc.AddBlock(paragraph); });

        // Assert
        Assert.That(doc.ChildBlocks.Count, Is.EqualTo(0));

    }

    [Test]
    public void ToLdmlString_ValidDoument_LdmlCreated()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();

        var sb = new StringBuilder();

        // Act  
        doc.ToLdmlString(sb, string.Empty);

        // Assert
        Assert.That(sb.Length, Is.Not.EqualTo(0));

        Debug.Print(sb.ToString());

    }

    [Test]
    public void ToLdmlString_ValidDocumentNoIndentation_LdmlCreated()
    {
        // Arrange 
        var doc = TestDataHelper.CreateDocument();
        doc.Indentation = string.Empty;

        var sb = new StringBuilder();

        // Act  
        doc.ToLdmlString(sb, string.Empty);

        // Assert
        Assert.That(sb.Length, Is.Not.EqualTo(0));

        Debug.Print(sb.ToString());

    }

}