# What does the library

Bodoconsult.Core.I18N library is a simple localization library based on I18N-Portable <https://github.com/xleon/I18N-Portable> by Diego Ponce de León (xleon).

To use I18N-Portable directly was not possible for us. We required a localization library supporting resources from multiple assemblies and sources. I18N-Portable did not support this. 
But the general idea of I18N-Portable is cool. Therefore we decided to develop an own I18N-Portable derivative with similar published interfaces but working a bit different behind the scenes.

Our implementation was intended for using it with console apps, WinForms apps or WPF apps under .NetCore 3.1 . All other uses case may work but are not tested.

* Simple to use: "key".Translate().
* Simple initialization setup.
* Readable and lean locale files (UTF8 .txt with key/value pairs).
* Support for custom file formats via ILocalesProvider interface (json, xml, etc)
* Light weight
* No dependencies.
* Well tested


# How to use the library

The source code contain NUnit test classes, the following source code is extracted from. The samples below show the most helpful use cases for the library.

## Setup locales

- In your NetCore project, create a directory called "Locales".
- Create a `{languageCode}.txt` file for each language you want to support. `languageCode` can be a two letter ISO code or a culture name like "en-US". See [full list here](https://msdn.microsoft.com/en-us/library/ee825488%28v=cs.20%29.aspx).
- Set "Build Action" to "Embedded Resource" on the properties of each file

**Locale content sample**

    # key = value (the key will be the same across locales)
    one = uno
    two = dos
    three = tres 
    four = cuatro
    five = cinco
      
    # Enums are supported
    Animals.Dog = Perro
    Animals.Cat = Gato
    Animals.Rat = Rata
    Animals.Tiger = Tigre
    Animals.Monkey = Mono
     
    # Support for string.Format()
    stars.count = Tienes {0} estrellas
     
    TextWithLineBreakCharacters = Line One\nLine Two\r\nLine Three
     
    Multiline = Line One
        Line Two
        Line Three

### Fluent initialization

```csharp
			I18N.Current
				.SetNotFoundSymbol("$") // Optional: when a key is not found, it will appear as $key$ (defaults to "$")
				.SetFallbackLocale("en") // Optional but recommended: locale to load in case the system locale is not supported
				.SetThrowWhenKeyNotFound(true) // Optional: Throw an exception when keys are not found (recommended only for debugging)
				.SetLogger(text => Debug.WriteLine(text)) // action to output traces
```

### Usage

The following code does not use Fluent to show the single steps necessary. It may be shortene by using Fluent. 

```csharp

            // **** Load all resources from one or more sources ****
            // Add provider 1
            ILocalesProvider provider = new I18NEmbeddedResourceLocalesProvider(GetType().Assembly,
                "Bodoconsult.Core.I18N.Test.Samples.Locales");

            I18N.Current.AddProvider(provider);

            // Add provider 2
            provider = new I18NEmbeddedResourceLocalesProvider(GetType().Assembly,
                "Bodoconsult.Core.I18N.Test.Locales");

            I18N.Current.AddProvider(provider);

            Assert.IsTrue(I18N.Current.Languages.Any());

            // **** Initialize all ****
            // Set a fallback locale for the case current thread language is not available in the resources
            I18N.Current.SetFallbackLocale("en");

            // Load the default language from thread culture
            I18N.Current.Init();


            // **** Use it ****
            // change to spanish (not necessary if thread language is ok)
            I18N.Current.Locale = "es";

            var translation = I18N.Current.Translate("one");
            Assert.AreEqual("uno", translation);

            translation = "Contains".Translate();
            Assert.AreEqual("Contains", translation);


            // Change to english
            I18N.Current.Locale = "en";

            translation = I18N.Current.Translate("one");
            Assert.AreEqual("one", translation);

            translation = "Contains".Translate();
            Assert.AreEqual("Contains", translation);

```

### Data binding

`I18N` implements `INotifyPropertyChanged` and it has an indexer to translate keys. For instance, you could translate a key like:

    string three = I18N.Current["three"]; 

With that said, the easiest way to bind your views to `I18N` translations is to use the built-in indexer 
by creating a proxy object in your ViewModel:

```csharp
public abstract class BaseViewModel
{
    public II18N Strings => I18N.Current;
}
```

**Xaml sample**
```xaml
<Button Content="{Binding Strings[key]}" />
```
**Xamarin.Forms sample**
```xaml
<Button Text="{Binding Strings[key]}" />`
```    


# About us

Bodoconsult (<http://www.bodoconsult.de>) is a Munich based software development company from Germany.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

