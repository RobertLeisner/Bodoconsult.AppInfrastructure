// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Generic;
using System.Linq;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.I18N.ResourceProviders;
using Bodoconsult.I18N.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.I18N.Test;

public class ResxEmbeddedResourceProviderTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void RegisterResourceItems_ValidLocales_ResourceItems()
    {

        // Arrange
        const string key = "de-DE";
        const string resourceFolder = "Bodoconsult.I18N.Test.Resources.Language";
        //const string value = "Is not null";

        IResourceProvider provider = new ResxEmbeddedResourceProvider(TestHelper.CurrentAssembly,
            resourceFolder);

        Assert.That(!provider.ResourceItems.Any());

        // Act
        provider.RegisterResourceItems();

        // Assert
        Assert.That(provider.ResourceItems.Any());

        var success = provider.ResourceItems.TryGetValue(key.ToUpperInvariant(), out var result);

        Assert.That(success);
        //Assert.That(value, result);

    }


    [Test]
    public void LoadResourceItem_De_ValuesLoaded()
    {
        // Arrange
        IDictionary<string, string> translations = new Dictionary<string, string>();
        const string key = "de-DE";
        const string resourceFolder = "Bodoconsult.I18N.Test.Resources.Language";
        //const string value = "Is not null";

        IResourceProvider provider = new ResxEmbeddedResourceProvider(TestHelper.CurrentAssembly,
            resourceFolder);

        Assert.That(!provider.ResourceItems.Any());

        provider.RegisterResourceItems();

        Assert.That(provider.ResourceItems.Any());

        var success = provider.ResourceItems.TryGetValue(key.ToUpperInvariant(), out var result);

        Assert.That(success);

        // Act
        provider.LoadResourceItem(key, translations);

        // Assert
        Assert.That(translations.Any());

        success = translations.TryGetValue("Test.Message1", out var value);

        Assert.That(success);
        Assert.That(value, Is.EqualTo("Blubb"));
    }

    [Test]
    public void LoadResourceItem_En_ValuesLoaded()
    {
        // Arrange
        IDictionary<string, string> translations = new Dictionary<string, string>();
        const string key = "en-US";
        const string resourceFolder = "Bodoconsult.I18N.Test.Resources.Language";
        //const string value = "Is not null";

        IResourceProvider provider = new ResxEmbeddedResourceProvider(TestHelper.CurrentAssembly,
            resourceFolder);

        Assert.That(!provider.ResourceItems.Any());

        provider.RegisterResourceItems();

        Assert.That(provider.ResourceItems.Any());

        var success = provider.ResourceItems.TryGetValue(key.ToUpperInvariant(), out var result);

        Assert.That(success);

        // Act
        provider.LoadResourceItem(key, translations);

        // Assert
        Assert.That(translations.Any());

        success = translations.TryGetValue("Test.Message1", out var value);

        Assert.That(success);
        Assert.That(value, Is.EqualTo("Message 1 as string"));
    }
}