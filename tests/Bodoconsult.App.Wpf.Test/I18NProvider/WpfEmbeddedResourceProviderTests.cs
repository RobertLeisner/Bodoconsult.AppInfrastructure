// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Generic;
using Bodoconsult.App.Wpf.I18N;
using Bodoconsult.App.Wpf.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.App.Wpf.Test.I18NProvider;

[TestFixture]
internal class WpfEmbeddedResourceProviderTests
{

    private const string Path = "Locales";

    [Test]
    public void RegisterResourceItems_ExistingResources_ResourceItemsLoaded()
    {
        // Arrange 
        var ass = TestHelper.CurrentAssembly;

        var provider = new WpfEmbeddedResourceProvider(ass, Path);

        // Act  
        provider.RegisterResourceItems();

        // Assert
        Assert.That(provider.ResourceItems, Is.Not.Null);
        Assert.That(provider.ResourceItems.Count, Is.Not.EqualTo(0));
    }

    [Test]
    public void RegisterResourceItems_ExistingResources_TranslationsLoaded()
    {
        // Arrange 
        IDictionary<string, string> translations = new Dictionary<string, string>();

        var ass = TestHelper.CurrentAssembly;

        var provider = new WpfEmbeddedResourceProvider(ass, Path);
        provider.RegisterResourceItems();

        // Act  
        
        provider.LoadResourceItem("de", translations);

        // Assert
        Assert.That(translations.Count, Is.Not.EqualTo(0));
    }

    [Test]
    public void RegisterResourceItems_ExistingResourcesTrailingSlashes_TranslationsLoaded()
    {
        // Arrange 
        IDictionary<string, string> translations = new Dictionary<string, string>();

        var ass = TestHelper.CurrentAssembly;

        var provider = new WpfEmbeddedResourceProvider(ass, Path);
        provider.RegisterResourceItems();

        // Act  
        provider.LoadResourceItem("de", translations);

        // Assert
        Assert.That(translations.Count, Is.Not.EqualTo(0));
    }

}