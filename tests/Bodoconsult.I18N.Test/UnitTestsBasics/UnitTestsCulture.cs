using System.Linq;
using Bodoconsult.I18N.LocalesProviders;
using NUnit.Framework;

namespace Bodoconsult.I18N.Test.UnitTestsBasics;

[TestFixture]
public class UnitTestsCulture : BaseTest
{
    [TestCase("es", "Español")]
    [TestCase("en", "English")]
    [TestCase("pt-BR", "Português (Brasil)")]
    [TestCase("es-MX", "Español (México)")]
    public void Languages_ShouldHave_CorrectDisplayName(string locale, string displayName)
    {
        var provider = new I18NEmbeddedResourceLocalesProvider(GetType().Assembly,
            "Bodoconsult.I18N.Test.Samples.Locales");


        I18N.Current.AddProvider(provider);

        var languages = I18N.Current.Languages;
        var language = languages.FirstOrDefault(x => x.Locale.Equals(locale));

        Assert.That( language?.DisplayName, Is.EqualTo(displayName));
    }

    //[TestCase("es-MX")]
    //[TestCase("pt-BR")]
    //public void LocalesWithWholeCultureNames_CanBeDefault(string cultureName)
    //{
    //    CulturHelper.SetCulture(cultureName);
    //    I18N.Current = new I18N().Init(GetType().Assembly);

    //    Assert.That(cultureName, I18N.Current.GetDefaultLocale());
    //}

    //[TestCase("es-MX", "Fruit.Banana", "banana")]
    //[TestCase("es-ES", "Fruit.Banana", "plátano")]
    //[TestCase("pt-BR", "hello", "oi")]
    //public void LocaleWithWholeCultureNames_GetLoaded_AsDefault(string cultureName, string key, string translation)
    //{
    //    CulturHelper.SetCulture(cultureName);
    //    I18N.Current = new I18N().Init(GetType().Assembly);

    //    Assert.That(translation, I18N.Current.Translate(key));
    //}
}