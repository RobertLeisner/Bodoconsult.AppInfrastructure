﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.I18N;
using Bodoconsult.App.Wpf.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.App.Wpf.Test.I18NProvider
{
    [TestFixture]
    internal class WpfFileLocalesProviderTests
    {

        private const string German =
            "pack://application:,,,/Bodoconsult.App.Wpf.Test;component/Resources/Culture.de.xaml";

        private const string English =
            "pack://application:,,,/Bodoconsult.App.Wpf.Test;component/Resources/Culture.en.xaml";

        [Test]
        public void RegisterResourceItems_ExistingLocales_LocalesLoaded()
        {
            // Arrange 
            var provider = new WpfFileLocalesProvider(TestHelper.CurrentAssembly, "Locales");

            // Act  
            provider.RegisterLocalesItems();

            // Assert
            Assert.That(provider.LocaleItems, Is.Not.Null);
            Assert.That(provider.LocaleItems.Count, Is.Not.EqualTo(0));
        }

        [Test]
        public void LoadResourceItem_CultureEn_TranslationsLoaded()
        {
            // Arrange 
            var provider = new WpfFileLocalesProvider(TestHelper.CurrentAssembly, "Locales");
            provider.RegisterLocalesItems();

            // Act  
            var translations = provider.LoadLocaleItem("en");

            // Assert
            Assert.That(translations.Count, Is.Not.EqualTo(0));

        }

        [Test]
        public void LoadResourceItem_CultureDe_TranslationsLoaded()
        {
            // Arrange 
            var provider = new WpfFileLocalesProvider(TestHelper.CurrentAssembly, "Locales");
            provider.RegisterLocalesItems();

            // Act  
            var translations = provider.LoadLocaleItem("de");

            // Assert
            Assert.That(translations.Count, Is.Not.EqualTo(0));

        }

        //[Test]
        //public void LoadResourceItem_CultureDe_TranslationsLoaded()
        //{
        //    // Arrange 
        //    var I18N = Bodoconsult.I18N.I18N.Current;


        //    var provider = new WpfFileLocalesProvider(English);

        //    I18N.AddProvider(provider)


        //    // Act  


        //    // Assert
        //    Assert.That(translations.Count, Is.Not.EqualTo(0));

        //}

    }
}
