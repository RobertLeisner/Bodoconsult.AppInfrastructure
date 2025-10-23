// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Text.Test.Documents.Styles;

[TestFixture]
internal class StyleSetTests
{
    [Test]
    public void Ctor_EmptyStyleset_PropsSetCorrectly()
    {
        // Arrange 

        // Act  
        var styleset = new Styleset();

        // Assert
        Assert.That(styleset.ChildBlocks.Count, Is.EqualTo(0));
        Assert.That(styleset.ChildInlines.Count, Is.EqualTo(0));
        Assert.That(styleset.StyleDictionary.Count, Is.EqualTo(0));
    }

    [Test]
    public void Ctor_LoadedStyleset_PropsSetCorrectly()
    {
        // Arrange 

        // Act  
        var styleset = StylesetHelper.CreateTestStyleset();

        // Assert
        Assert.That(styleset.ChildBlocks.Count, Is.Not.EqualTo(0));
        Assert.That(styleset.ChildInlines.Count, Is.EqualTo(0));
        Assert.That(styleset.StyleDictionary.Count, Is.Not.EqualTo(0));
    }

    [Test]
    public void FindStyle_LoadedStyleset_StyleFound()
    {
        // Arrange 
        var styleset = StylesetHelper.CreateTestStyleset();

        // Act  
        var style = styleset.FindStyle("DocumentStyle");

        // Assert
        Assert.That(style, Is.Not.Null);
    }
}