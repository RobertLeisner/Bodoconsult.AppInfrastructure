// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using Bodoconsult.I18N.LocalesProviders;
using Bodoconsult.I18N.Test.Samples.Util;
using NUnit.Framework;

namespace Bodoconsult.I18N.Test.UnitTestsBasics;

[TestFixture]
public class UnitTestsExtensions : BaseTest
{
    [Test]
    public void LineBreaks_ShouldBe_Unescaped()
    {
        const string sample = "Hello\\r\\nfrom\\nthe other side";
        var unescaped = sample.UnescapeLineBreaks();
        var expected = $"Hello{Environment.NewLine}from{Environment.NewLine}the other side";

        Assert.That(unescaped, Is.EqualTo(expected));
    }

    [Test]
    public void FirstLetter_ShouldBe_Capitalized()
    {
        Assert.That( "english".CapitalizeFirstCharacter(), Is.EqualTo("English"));
        Assert.That("e".CapitalizeFirstCharacter(), Is.EqualTo("E"));
        Assert.That(" ".CapitalizeFirstCharacter(), Is.EqualTo(" "));

        string nullString = null;
        Assert.That(nullString.CapitalizeFirstCharacter(), Is.Null);
    }

    [Test]
    public void EveryEnum_CanBeTranslated_WithExtension()
    {

        var provider = new I18NEmbeddedResourceLocalesProvider(GetType().Assembly,
            "Bodoconsult.I18N.Test.Samples.Locales");


        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = "en";

        var apple = Fruit.Apple.Translate();
        var orange = Fruit.Orange.Translate();
        var banana = Fruit.Banana.Translate();

        Assert.That(apple, Is.EqualTo("big apple"));
        Assert.That( orange, Is.EqualTo("great orange"));
        Assert.That( banana, Is.EqualTo("nice banana"));
    }

    [Test]
    public void NonLocalizedEnums_CanBeTranslated()
    {
        Assert.That( TestEnum.TestEnumValue1.Translate(), Is.EqualTo("?TestEnum.TestEnumValue1?"));
    }
}