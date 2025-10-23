// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Text.Test.Documents;

[TestFixture]
internal class ElementContentParserTests
{
    private const string Section1 = "Blubb";
    private const string Section2 = "Blabb";
    private const string Section3 = "Blobb";

    [Test]
    public void Parse_SimpleString_Finds1Inline()
    {
        // Arrange 
        const string content = Section1;
        var block = new Paragraph();

        // Act  
        ElementContentParser.Parse(content, block);

        // Assert
        Assert.That(block.ChildInlines.Count, Is.EqualTo(1));

    }

    [Test]
    public void Parse_StringWithGreater_Finds1Inline()
    {
        // Arrange 
        const string content = "Blu>bb";
        var block = new Paragraph();

        // Act  
        ElementContentParser.Parse(content, block);

        // Assert
        Assert.That(block.ChildInlines.Count, Is.EqualTo(1));

    }

    [Test]
    public void Parse_StringWithLower_Finds1Inline()
    {
        // Arrange 
        const string content = "Blu<bb";
        var block = new Paragraph();

        // Act  
        ElementContentParser.Parse(content, block);

        // Assert
        Assert.That(block.ChildInlines.Count, Is.EqualTo(1));

    }

    [Test]
    public void Parse_StringWithLowerAndGreater_Finds1Inline()
    {
        // Arrange 
        const string content = "Blu>bb<aaa";
        var block = new Paragraph();

        // Act  
        ElementContentParser.Parse(content, block);

        // Assert
        Assert.That(block.ChildInlines.Count, Is.EqualTo(1));

    }

    [Test]
    public void Parse_StringSpanBold_Finds2Inline()
    {
        // Arrange 
        const string content = $"{Section1}<b>{Section2}</b>";
        var block = new Paragraph();

        // Act  
        ElementContentParser.Parse(content, block);

        // Assert
        Assert.That(block.ChildInlines.Count, Is.EqualTo(2));

    }

    [Test]
    public void Parse_StringSpanBoldOpen_Finds2Inline()
    {
        // Arrange 
        const string content = $"{Section1}<b>{Section2}";
        var block = new Paragraph();

        // Act  
        ElementContentParser.Parse(content, block);

        // Assert
        Assert.That(block.ChildInlines.Count, Is.EqualTo(2));

    }

    [Test]
    public void Parse_StringSpanBoldSpan_Finds3Inline()
    {
        // Arrange 
        const string content = $"{Section1}<b>{Section2}</b>{Section3}";
        var block = new Paragraph();


        // Act  
        ElementContentParser.Parse(content, block);

        // Assert
        Assert.That(block.ChildInlines.Count, Is.EqualTo(3));

    }

}