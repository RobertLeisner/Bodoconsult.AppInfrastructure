// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using NUnit.Framework;
using System.Diagnostics;

namespace Bodoconsult.Text.Test.Documents;

[TestFixture]
public class DocumentReflectionHelperTests
{

    [Test]
    public void GetPropertiesForAttributes_ParagraphStyle_PropsLoadedCorrectly()
    {
        // Arrange 
        var type = typeof(ParagraphStyle);

        // Act  
        var props = DocumentReflectionHelper.GetPropertiesForAttributes(type);

        // Assert
        Assert.That(props.Length, Is.Not.EqualTo(0));

        foreach (var prop in props)
        {
            Debug.Print(prop.Name);
        }
    }

    [Test]
    public void GetPropertiesForBlocks_ParagraphStyle_PropsLoadedCorrectly()
    {
        // Arrange 
        var type = typeof(ParagraphStyle);

        // Act  
        var props = DocumentReflectionHelper.GetPropertiesForBlocks(type);

        // Assert
        Assert.That(props.Length, Is.Not.EqualTo(0));

        foreach (var prop in props)
        {
            Debug.Print(prop.Name);
        }
    }

}