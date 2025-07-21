// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Collections.Generic;
using Bodoconsult.I18N.Helpers;
using NUnit.Framework;

namespace Bodoconsult.I18N.Test.BasicsTests;

internal class LocaleHelperTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [TestCase("de", "de")]
    [TestCase("en", "en")]
    [TestCase("pt", "pt")]
    [TestCase("fr-FR", "fr-FR")]
    [TestCase("fr", "fr-FR")]
    [TestCase("xx", null)]
    [TestCase("xx-XX", null)]
    public void TestCheckLocaleDictionary(string requestedLocale, string expectedResult)
    {
        // Arrange
        var resources = new Dictionary<string, string>
        {
            {"de", "de"}, {"en", "en"}, {"pt", "pt"}, {"fr-FR", "fr-FR"}
        };


        // Act
        var result = LocaleHelper.CheckLocale(resources, requestedLocale);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));

    }


    [TestCase("de", "de")]
    [TestCase("en", "en")]
    [TestCase("pt", "pt")]
    [TestCase("fr-FR", "fr-FR")]
    [TestCase("fr", "fr-FR")]
    [TestCase("xx", null)]
    [TestCase("xx-XX", null)]
    public void TestCheckLocaleList(string requestedLocale, string expectedResult)
    {
        // Arrange
        var resources = new List<string> {"de", "en", "fr-FR", "pt"};

        // Act
        var result = LocaleHelper.CheckLocale(resources, requestedLocale);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));

    }
}