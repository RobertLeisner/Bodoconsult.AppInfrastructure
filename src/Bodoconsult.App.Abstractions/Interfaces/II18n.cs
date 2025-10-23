// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.ComponentModel;

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Interface for I18N
/// </summary>
public interface II18N : INotifyPropertyChanged, IDisposable
{
    /// <summary>
    /// Tag prefix used to declare content als as resource key
    /// </summary>
    public const string I18nTag = "I18N:";

    /// <summary>
    /// Indexer to translate string. Intended for usage with MVVM / WPF / Xamarin
    /// </summary>
    /// <param name="key">String key to translate</param>
    /// <returns>Translated string</returns>
    string this[string key] { get; }
        
    /// <summary>
    /// Current locale language as <see cref="PortableLanguage"/> instance
    /// </summary>
    PortableLanguage Language { get; set; }
        
    /// <summary>
    /// Current locale
    /// </summary>
    string Locale { get; set; }
        
    /// <summary>
    /// Available languages found by the providers. 
    /// </summary>
    List<PortableLanguage> Languages { get; }

    /// <summary>
    /// Set the not-found-symbol
    /// </summary>
    /// <param name="symbol">Symbol to set as not-found-symbol</param>
    /// <returns></returns>
    II18N SetNotFoundSymbol(string symbol);
    II18N SetLogger(Action<string> output);
    II18N SetThrowWhenKeyNotFound(bool enabled);
    II18N SetFallbackLocale(string locale);

    /// <summary>
    /// Reset all providers
    /// </summary>
    /// <returns>Current I18N instance for FluentAPI</returns>
    II18N Reset();

    /// <summary>
    ///  Add a provider as data source for translations
    /// </summary>
    /// <param name="provider">Provider for translation data</param>
    /// <returns>Current I18N instance for FluentAPI</returns>
    II18N AddProvider(ILocalesProvider provider);

    /// <summary>
    /// All loaded providers
    /// </summary>
    IList<ILocalesProvider> Providers { get; }

    /// <summary>
    /// Get the default locale
    /// </summary>
    /// <returns>Default local as string</returns>
    string GetDefaultLocale();

    /// <summary>
    /// Translate the given key. If key is not existing an empty string is returned
    /// </summary>
    /// <param name="key">Key to translate</param>
    /// <returns>Translated key as string</returns>
    string Translate(string key);

    /// <summary>
    /// Translate the given key. If key is not existing an empty string is returned
    /// </summary>
    /// <param name="key">Key to translate</param>
    /// <param name="args">Optional args</param>
    /// <returns>Translated key as string</returns>
    string Translate(string key, params object[] args);

    /// <summary>
    /// Translate the given key. If key is not existing null is returned
    /// </summary>
    /// <param name="key">Key to translate</param>
    /// <param name="args">Optinal args</param>
    /// <returns>Translated key as string or null</returns>
    string TranslateOrNull(string key, params object[] args);

    Dictionary<TEnum, string> TranslateEnumToDictionary<TEnum>();
    List<string> TranslateEnumToList<TEnum>();
    List<Tuple<TEnum, string>> TranslateEnumToTupleList<TEnum>();
        
    /// <summary>
    /// Initialize the system with the thread language
    /// </summary>
    void Init();
}