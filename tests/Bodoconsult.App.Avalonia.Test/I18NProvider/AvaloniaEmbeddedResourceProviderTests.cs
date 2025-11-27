//// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

//using Bodoconsult.App.Avalonia.I18N;
//using Bodoconsult.App.Avalonia.Test.Helpers;

//namespace Bodoconsult.App.Avalonia.Test.I18NProvider;

//[TestFixture]
//internal class AvaloniaEmbeddedResourceProviderTests
//{

//    [Test]
//    public void RegisterResourceItems_ExistingResources_ResourceItemsLoaded()
//    {
//        // Arrange 
//        var ass = TestHelper.CurrentAssembly;
//        var path = "Resources";

//        var provider = new AvaloniaEmbeddedResourceProvider(ass, path);

//        // Act  
//        provider.RegisterResourceItems();

//        // Assert
//        Assert.That(provider.ResourceItems, Is.Not.Null);
//        Assert.That(provider.ResourceItems.Count, Is.Not.EqualTo(0));
//    }

//    [Test]
//    public void RegisterResourceItems_ExistingResources_TranslationsLoaded()
//    {
//        // Arrange 
//        IDictionary<string, string> translations = new Dictionary<string, string>();

//        var ass = TestHelper.CurrentAssembly;
//        var path = "Resources";

//        var provider = new AvaloniaEmbeddedResourceProvider(ass, path);
//        provider.RegisterResourceItems();

//        // Act  
        
//        provider.LoadResourceItem("de", translations);

//        // Assert
//        Assert.That(translations.Count, Is.Not.EqualTo(0));
//    }

//    [Test]
//    public void RegisterResourceItems_ExistingResourcesTrailingSlashes_TranslationsLoaded()
//    {
//        // Arrange 
//        IDictionary<string, string> translations = new Dictionary<string, string>();

//        var ass = TestHelper.CurrentAssembly;
//        var path = "/Resources/";

//        var provider = new AvaloniaEmbeddedResourceProvider(ass, path);
//        provider.RegisterResourceItems();

//        // Act  

//        provider.LoadResourceItem("de", translations);

//        // Assert
//        Assert.That(translations.Count, Is.Not.EqualTo(0));
//    }

//}