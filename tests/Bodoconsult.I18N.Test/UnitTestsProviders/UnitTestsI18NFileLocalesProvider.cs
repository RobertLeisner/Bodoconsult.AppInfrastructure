// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Linq;
using Bodoconsult.I18N.Interfaces;
using Bodoconsult.I18N.LocalesProviders;
using NUnit.Framework;

namespace Bodoconsult.I18N.Test.UnitTestsProviders;

public class UnitTestsI18NFileLocalesProvider
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void TestRegisterResourceItems()
    {

        // Arrange
        const string key = "de";
        const string resourceFolder = "LocalesFiles";
        //const string value = "Is not null";

        ILocalesProvider provider = new I18NFileLocalesProvider(GetType().Assembly,
            resourceFolder);

        Assert.That(!provider.LocaleItems.Any());

        // Act
        provider.RegisterLocalesItems();

        // Assert
        Assert.That(provider.LocaleItems.Any());

        var success = provider.LocaleItems.TryGetValue(key, out var result);

        Assert.That(success);
        //Assert.That(value, result);

    }


    [TestCase("de", "enth�lt")]
    [TestCase("pt", "contem")]
    [TestCase("fr-FR", "Franz�sisch")]
    [TestCase("en", "Contains")]
    public void TestLoadResourceItem(string language, string expectedResult)
    {

        // Arrange
        const string resourceFolder = "LocalesFiles";
        const string translationKey = "Contains";

        ILocalesProvider provider = new I18NFileLocalesProvider(GetType().Assembly,
            resourceFolder);

        Assert.That(!provider.LocaleItems.Any());

        provider.RegisterLocalesItems();

        Assert.That(provider.LocaleItems.Any());

        var success = provider.LocaleItems.TryGetValue(language, out var result);

        Assert.That(success);

        // Act
        var translations = provider.LoadLocaleItem(language);

        // Assert
        Assert.That(translations.Any());

        success = translations.TryGetValue(translationKey, out result);
        Assert.That(success);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}