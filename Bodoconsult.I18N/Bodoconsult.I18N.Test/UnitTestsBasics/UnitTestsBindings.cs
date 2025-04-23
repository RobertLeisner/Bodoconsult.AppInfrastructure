using Bodoconsult.I18N.LocalesProviders;
using NUnit.Framework;

namespace Bodoconsult.I18N.Test.UnitTestsBasics;

[TestFixture]
public class UnitTestsBindings : BaseTest
{
    [Test]
    public void Indexer_Is_Bindable()
    {

        var provider = new I18NEmbeddedResourceLocalesProvider(GetType().Assembly,
            "Bodoconsult.I18N.Test.Samples.Locales");


        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = "es";
        var translation = I18N.Current.Translate("one");

        I18N.Current.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName.Equals("Item[]"))
                translation = I18N.Current.Translate("one");
        };

        I18N.Current.Locale = "en";

        Assert.That(translation, Is.EqualTo("one"));

        I18N.Current.Locale = "es";

        Assert.That(translation, Is.EqualTo("uno"));
    }

    [Test]
    public void LanguageProperty_Is_Bindable()
    {

        var provider = new I18NEmbeddedResourceLocalesProvider(GetType().Assembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = "es";
        var language = I18N.Current.Language;

        I18N.Current.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName.Equals("Language"))
                language = ((II18N)sender).Language;
        };

        I18N.Current.Locale = "en";

        Assert.That(language.Locale, Is.EqualTo("en"));

        I18N.Current.Locale = "es";

        Assert.That(language.Locale, Is.EqualTo("es"));
    }

    [Test]
    public void LocaleProperty_Is_Bindable()
    {

        var provider = new I18NEmbeddedResourceLocalesProvider(GetType().Assembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.AddProvider(provider);

        I18N.Current.Locale = "es";
        var locale = I18N.Current.Locale;

        I18N.Current.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName.Equals("Locale"))
                locale = ((II18N)sender).Locale;
        };

        I18N.Current.Locale = "en";

        Assert.That(locale, Is.EqualTo("en"));

        I18N.Current.Locale = "es";

        Assert.That(locale, Is.EqualTo("es"));
    }
}