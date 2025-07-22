// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Collections.Generic;
using Bodoconsult.I18N.LocalesProviders;
using Bodoconsult.I18N.Test.Helpers;
using Bodoconsult.I18N.Test.Samples.Util;
using NUnit.Framework;

namespace Bodoconsult.I18N.Test.BasicsTests;

[TestFixture]
internal class TranslationsTests : BaseTests
{

    [TestCase("en", "one", "one")]
    [TestCase("en", "two", "two")]
    [TestCase("en", "three", "three")]
    [TestCase("en", "Animals", "List of animals")]
    [TestCase("en", "Animals.Dog", "Dog")]
    [TestCase("en", "Animals.Cat", "Cat")]
    [TestCase("en", "Animals.Rat", "Rat")]
    [TestCase("en", "Fruit.Orange", "great orange")]
    [TestCase("en", "Fruit.Apple", "big apple")]
    // --
    [TestCase("es", "one", "uno")]
    [TestCase("es", "two", "dos")]
    [TestCase("es", "three", "tres")]
    [TestCase("es", "Animals", "Lista de animales")]
    [TestCase("es", "Animals.Dog", "Perro")]
    [TestCase("es", "Animals.Cat", "Gato")]
    [TestCase("es", "Animals.Rat", "Rata")]
    [TestCase("es", "Fruit.Orange", "gran naranja")]
    [TestCase("es", "Fruit.Apple", "manzana grande")]
    public void KeyTranslate_ShouldBe_Translated(string locale, string key, string translation)
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = locale;

        Assert.That(key.Translate(), Is.EqualTo(translation));
    }


    [TestCase("en", "one", "one")]
    [TestCase("en", "two", "two")]
    [TestCase("en", "three", "three")]
    [TestCase("en", "Animals", "List of animals")]
    [TestCase("en", "Animals.Dog", "Dog")]
    [TestCase("en", "Animals.Cat", "Cat")]
    [TestCase("en", "Animals.Rat", "Rat")]
    [TestCase("en", "Fruit.Orange", "great orange")]
    [TestCase("en", "Fruit.Apple", "big apple")]
    // --
    [TestCase("es", "one", "uno")]
    [TestCase("es", "two", "dos")]
    [TestCase("es", "three", "tres")]
    [TestCase("es", "Animals", "Lista de animales")]
    [TestCase("es", "Animals.Dog", "Perro")]
    [TestCase("es", "Animals.Cat", "Gato")]
    [TestCase("es", "Animals.Rat", "Rata")]
    [TestCase("es", "Fruit.Orange", "gran naranja")]
    [TestCase("es", "Fruit.Apple", "manzana grande")]
    public void KeyTranslateOrNull_ShouldBe_Translated(string locale, string key, string translation)
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = locale;

        Assert.That(key.TranslateOrNull(), Is.EqualTo(translation));
    }

    [TestCase("en", "one", "one")]
    [TestCase("en", "two", "two")]
    [TestCase("en", "three", "three")]
    [TestCase("en", "Animals", "List of animals")]
    [TestCase("en", "Animals.Dog", "Dog")]
    [TestCase("en", "Animals.Cat", "Cat")]
    [TestCase("en", "Animals.Rat", "Rat")]
    [TestCase("en", "Fruit.Orange", "great orange")]
    [TestCase("en", "Fruit.Apple", "big apple")]
    // --
    [TestCase("es", "one", "uno")]
    [TestCase("es", "two", "dos")]
    [TestCase("es", "three", "tres")]
    [TestCase("es", "Animals", "Lista de animales")]
    [TestCase("es", "Animals.Dog", "Perro")]
    [TestCase("es", "Animals.Cat", "Gato")]
    [TestCase("es", "Animals.Rat", "Rata")]
    [TestCase("es", "Fruit.Orange", "gran naranja")]
    [TestCase("es", "Fruit.Apple", "manzana grande")]
    public void I18NTranslate_ShouldBe_Translated(string locale, string key, string translation)
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = locale;

        Assert.That(I18N.Current.Translate(key), Is.EqualTo(translation));
        Assert.That(I18N.Current[key], Is.EqualTo(translation));
    }

    [TestCase("en", "one", "one")]
    [TestCase("en", "two", "two")]
    [TestCase("en", "three", "three")]
    [TestCase("en", "Animals", "List of animals")]
    [TestCase("en", "Animals.Dog", "Dog")]
    [TestCase("en", "Animals.Cat", "Cat")]
    [TestCase("en", "Animals.Rat", "Rat")]
    [TestCase("en", "Fruit.Orange", "great orange")]
    [TestCase("en", "Fruit.Apple", "big apple")]
    // --
    [TestCase("es", "one", "uno")]
    [TestCase("es", "two", "dos")]
    [TestCase("es", "three", "tres")]
    [TestCase("es", "Animals", "Lista de animales")]
    [TestCase("es", "Animals.Dog", "Perro")]
    [TestCase("es", "Animals.Cat", "Gato")]
    [TestCase("es", "Animals.Rat", "Rata")]
    [TestCase("es", "Fruit.Orange", "gran naranja")]
    [TestCase("es", "Fruit.Apple", "manzana grande")]
    public void I18NIndexer_ShouldBe_Translated(string locale, string key, string translation)
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = locale;

        Assert.That(I18N.Current[key], Is.EqualTo(translation));
    }

    [TestCase("en", "Mailbox.Notification", "Hello Marta, you've got 56 emails")]
    [TestCase("es", "Mailbox.Notification", "Hola Marta, tienes 56 emails")]
    public void Translate_Should_FormatString(string locale, string key, string translation)
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = locale;

        Assert.That(I18N.Current.Translate(key, "Marta", 56), Is.EqualTo(translation));
        Assert.That(key.Translate("Marta", 56), Is.EqualTo(translation));
    }

    [TestCase("en", "Line One", "Line Two", "Line Three")]
    [TestCase("es", "Línea Uno", "Línea dos", "Línea Tres")]
    public void Translation_ShouldConsider_LineBreakCharacters(string locale, string line1, string line2, string line3)
    {
        const string key = "TextWithLineBreakCharacters";

        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = locale;

        var textWithLineBreaks = I18N.Current.Translate(key);
        var textWithLineBreaksOrNull = I18N.Current.TranslateOrNull(key);
        var expected = $"{line1}{Environment.NewLine}{line2}{Environment.NewLine}{line3}";

        Assert.That(textWithLineBreaks, Is.EqualTo(expected));
        Assert.That(textWithLineBreaksOrNull, Is.EqualTo(expected));
    }

    [TestCase("en", "Good", "Snake")]
    [TestCase("es", "Serpiente", "Buena")]
    public void EnumTranslation_ShouldConsider_LineBreakCharacters(string locale, string line1, string line2)
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = locale;
        var animals = I18N.Current.TranslateEnumToDictionary<Animals>();

        Assert.That(animals[Animals.Snake], Is.EqualTo($"{line1}{Environment.NewLine}{line2}"));
    }

    [TestCase("en", "Line One", "Line Two", "Line Three")]
    [TestCase("es", "Línea Uno", "Línea Dos", "Línea Tres")]
    public void Multiline_IsSupported_OnLocales(string locale, string line1, string line2, string line3)
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = locale;
        var multilineValue = I18N.Current.Translate("Multiline");
        var expected = $"{line1}{Environment.NewLine}{line2}{Environment.NewLine}{line3}";

        Assert.That(multilineValue, Is.EqualTo(expected));
    }

    [Test]
    public void Enum_CanBeTranslated_ToStringList()
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = "es";
        var list = I18N.Current.TranslateEnumToList<Animals>();

        Assert.That(list.Count, Is.EqualTo(4));
        Assert.That(list[0], Is.EqualTo("Perro"));
        Assert.That(list[1], Is.EqualTo("Gato"));
        Assert.That(list[2], Is.EqualTo("Rata"));
    }

    [Test]
    public void Enum_CanBeTranslated_ToDictionary()
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = "en";
        var animals = I18N.Current.TranslateEnumToDictionary<Animals>();

        Assert.That( animals[Animals.Dog], Is.EqualTo("Dog"));
        Assert.That( animals[Animals.Cat], Is.EqualTo("Cat"));
        Assert.That( animals[Animals.Rat], Is.EqualTo( "Rat"));

        I18N.Current.Locale = "es";
        animals = I18N.Current.TranslateEnumToDictionary<Animals>();

        Assert.That( animals[Animals.Dog], Is.EqualTo("Perro"));
        Assert.That(animals[Animals.Cat], Is.EqualTo("Gato"));
        Assert.That(animals[Animals.Rat], Is.EqualTo("Rata"));
    }

    [Test]
    public void Enum_CanBeTranslated_ToTupleList()
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.Reset();
        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = "en";
        var animalsTupleList = I18N.Current.TranslateEnumToTupleList<Animals>();

        Assert.That(animalsTupleList.Count, Is.EqualTo(4));
        Assert.That( animalsTupleList[0].Item2, Is.EqualTo("Dog"));
        Assert.That( Animals.Dog, Is.EqualTo(animalsTupleList[0].Item1));
        Assert.That( animalsTupleList[2].Item2, Is.EqualTo("Rat"));
        Assert.That( Animals.Rat, Is.EqualTo(animalsTupleList[2].Item1));
    }

    [Test]
    public void NotFoundSymbol_CanBe_Changed()
    {
        //var provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
        //    "Bodoconsult.I18N.Test.Samples.Locales");

        //I18N.Current.AddProvider(provider);

        I18N.Current.Reset();
        I18N.Current.SetNotFoundSymbol("$$");
        var nonExistent = I18N.Current.Translate("nonExistentKey");

        Assert.That(nonExistent, Is.EqualTo("$$nonExistentKey$$"));
    }

    [Test]
    public void TranslateOrNull_ShouldReturn_Null_WhenKeyIsNotFound()
    {
        Assert.That(I18N.Current.TranslateOrNull("nonExistentKey"), Is.Null);
        Assert.That(I18N.Current.TranslateOrNull("nonExistentKey", "one", "two"), Is.Null);
        Assert.That("nonExistentKey".TranslateOrNull(), Is.Null);
    }

    [Test]
    public void SetThrowWhenKeyNotFound_WillThrow_WhenKeyNotFound()
    {
        I18N.Current.SetThrowWhenKeyNotFound(true);

        Assert.Throws<KeyNotFoundException>(() => I18N.Current.Translate("fake"));
        Assert.Throws<KeyNotFoundException>(() => "fake".Translate());
    }

    [Test]
    public void NotFoundSymbol_ShouldNever_BeNullOrEmpty()
    {
        I18N.Current.SetNotFoundSymbol("##");
        I18N.Current.SetNotFoundSymbol(null);

        Assert.That( "missing".Translate(), Is.EqualTo("##missing##"));

        I18N.Current.SetNotFoundSymbol(string.Empty);

        Assert.That( "missing".Translate(), Is.EqualTo("##missing##"));
    }

}