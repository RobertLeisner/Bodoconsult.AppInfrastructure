// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.I18N;

/// <summary>
/// Mock class for <see cref="II18N"/>
/// </summary>
public class I18NMock : II18N
{
    #region Singleton factory

    // Thread-safe implementation of singleton pattern
    private static Lazy<I18NMock> _instance;

    /// <summary>
    /// Get a singleton instance of I18N
    /// </summary>
    /// <returns></returns>
    public static I18NMock Current
    {
        get
        {
            try
            {
                _instance ??= new Lazy<I18NMock>(() => new I18NMock());
                return _instance.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    #endregion

    /// <summary>
    /// Default ctor not accessible form outside the class
    /// </summary>
    private I18NMock()
    { }

    private void NotifyPropertyChanged(string info) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose() { }

    public string this[string key] => throw new NotImplementedException();

    /// <summary>
    /// Current locale language as <see cref="PortableLanguage"/> instance
    /// </summary>
    public PortableLanguage Language { get; set; }

    /// <summary>
    /// Current locale
    /// </summary>
    public string Locale { get; set; }

    /// <summary>
    /// Available languages found by the providers. 
    /// </summary>
    public List<PortableLanguage> Languages { get; set; }

    /// <summary>
    /// Set the not-found-symbol
    /// </summary>
    /// <param name="symbol">Symbol to set as not-found-symbol</param>
    /// <returns></returns>
    public II18N SetNotFoundSymbol(string symbol) => throw new NotImplementedException();

    public II18N SetLogger(Action<string> output) => throw new NotImplementedException();

    public II18N SetThrowWhenKeyNotFound(bool enabled) => throw new NotImplementedException();

    public II18N SetFallbackLocale(string locale) => throw new NotImplementedException();

    /// <summary>
    /// Reset all providers
    /// </summary>
    /// <returns>Current I18N instance for FluentAPI</returns>
    public II18N Reset()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///  Add a provider as data source for translations
    /// </summary>
    /// <param name="provider">Provider for translation data</param>
    /// <returns>Current I18N instance for FluentAPI</returns>
    public II18N AddProvider(ILocalesProvider provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// All loaded providers
    /// </summary>
    public IList<ILocalesProvider> Providers { get; } = new List<ILocalesProvider>();

    /// <summary>
    /// Get the default locale
    /// </summary>
    /// <returns>Default local as string</returns>
    public string GetDefaultLocale() => throw new NotImplementedException();

    /// <summary>
    /// Translate the given key. If key is not existing an empty string is returned
    /// </summary>
    /// <param name="key">Key to translate</param>
    /// <param name="args">Optinal args</param>
    /// <returns>Translated key as string</returns>
    public string Translate(string key, params object[] args) => "mocked translation";

    /// <summary>
    /// Translate the given key. If key is not existing null is returned
    /// </summary>
    /// <param name="key">Key to translate</param>
    /// <param name="args">Optinal args</param>
    /// <returns>Translated key as string or null</returns>
    public string TranslateOrNull(string key, params object[] args) => throw new NotImplementedException();

    public Dictionary<TEnum, string> TranslateEnumToDictionary<TEnum>() => throw new NotImplementedException();

    public List<string> TranslateEnumToList<TEnum>() => throw new NotImplementedException();

    public List<Tuple<TEnum, string>> TranslateEnumToTupleList<TEnum>() => throw new NotImplementedException();

    /// <summary>
    /// Initialize the system with the thread language
    /// </summary>
    public void Init()
    {
        // Do nothing
    }

    public void Unload() => throw new NotImplementedException();
}