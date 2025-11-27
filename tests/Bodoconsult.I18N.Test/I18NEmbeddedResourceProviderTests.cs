// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Collections.Generic;
using System.Linq;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.I18N.ResourceProviders;
using Bodoconsult.I18N.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.I18N.Test;

public class I18NEmbeddedResourceProviderTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void RegisterResourceItems_ValidLocales_ResourceItems()
    {

        // Arrange
        const string key = "de";
        const string resourceFolder = "Bodoconsult.I18N.Test.Locales";
        //const string value = "Is not null";

        IResourceProvider provider = new I18NEmbeddedResourceProvider(TestHelper.CurrentAssembly,
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

        IDictionary<string, string> translations  = new Dictionary<string, string>();
        const string key = "de";
        const string resourceFolder = "Bodoconsult.I18N.Test.Locales";
        //const string value = "Is not null";

        IResourceProvider provider = new I18NEmbeddedResourceProvider(TestHelper.CurrentAssembly,
            resourceFolder);

        Assert.That(!provider.ResourceItems.Any());

        provider.RegisterResourceItems();

        Assert.That(provider.ResourceItems.Any());

        var success = provider.ResourceItems.TryGetValue(key.ToUpperInvariant(), out var result);

        Assert.That(success);

        // Act
        provider.LoadResourceItem("de", translations);

        // Assert
        Assert.That(translations.Any());

    }
}