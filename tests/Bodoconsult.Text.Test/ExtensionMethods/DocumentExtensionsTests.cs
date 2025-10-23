// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using NUnit.Framework;
using Bodoconsult.Text.Extensions;

namespace Bodoconsult.Text.Test.ExtensionMethods;

[TestFixture]
internal class DocumentExtensionsTests
{

    [Test]
    public void AddBaseSections_BaseSectionsRequired_SectionsAdded()
    {
        // Arrange 
        var doc = new Document
        {
            Name = "MyReport",
        };


        // Styleset (add after meta data)
        var styleset = StylesetHelper.CreateTestStyleset();
        doc.AddBlock(styleset);

        // Metadata (add before style set)
        var meta = new DocumentMetaData
        {
            Title = "Title of the document",
            Description = "Blubb blabb bleeb",
            Keywords = "Blubb, blabb, bleeb",
            Company = "Bodoconsult GmbH",
            CompanyWebsite = "http://www.bodoconsult.de",
            Authors = "Robert Leisner",
            IsTocRequired = true,
            IsFiguresTableRequired = true,
            IsEquationsTableRequired = true
        };

        doc.AddBlock(meta);

        // Act  
        doc.AddBaseSections();

        // Assert
        Assert.That(doc.ChildBlocks.Count, Is.EqualTo(5));
        Assert.That(doc.TocSection, Is.Not.Null);
        Assert.That(doc.TofSection, Is.Not.Null);
        Assert.That(doc.ToeSection, Is.Not.Null);
    }

    [Test]
    public void AddBaseSections_BaseSectionsNotRequired_SectionsNotAdded()
    {
        // Arrange 
        var doc = new Document
        {
            Name = "MyReport",
        };


        // Styleset (add after meta data)
        var styleset = StylesetHelper.CreateTestStyleset();
        doc.AddBlock(styleset);

        // Metadata (add before style set)
        var meta = new DocumentMetaData
        {
            Title = "Title of the document",
            Description = "Blubb blabb bleeb",
            Keywords = "Blubb, blabb, bleeb",
            Company = "Bodoconsult GmbH",
            CompanyWebsite = "http://www.bodoconsult.de",
            Authors = "Robert Leisner",
            IsTocRequired = false,
            IsFiguresTableRequired = false,
            IsEquationsTableRequired = false
        };

        doc.AddBlock(meta);

        // Act  
        doc.AddBaseSections();

        // Assert
        Assert.That(doc.ChildBlocks.Count, Is.EqualTo(2));
        Assert.That(doc.TocSection, Is.Null);
        Assert.That(doc.TofSection, Is.Null);
        Assert.That(doc.ToeSection, Is.Null);
    }

}