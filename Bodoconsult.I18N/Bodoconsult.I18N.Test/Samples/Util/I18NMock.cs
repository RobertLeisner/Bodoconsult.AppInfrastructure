// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using Bodoconsult.I18N.Interfaces;

namespace Bodoconsult.I18N.Test.Samples.Util;

public class I18NMock : II18N
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void Dispose() { }

    public string this[string key] => throw new NotImplementedException();

    public PortableLanguage Language { get; set; }
    public string Locale { get; set; }
    public List<PortableLanguage> Languages { get; }

    public II18N SetNotFoundSymbol(string symbol) => throw new NotImplementedException();

    public II18N SetLogger(Action<string> output) => throw new NotImplementedException();

    public II18N SetThrowWhenKeyNotFound(bool enabled) => throw new NotImplementedException();

    public II18N SetFallbackLocale(string locale) => throw new NotImplementedException();
    public I18N Reset()
    {
        throw new NotImplementedException();
    }

    public I18N AddProvider(ILocalesProvider provider)
    {
        throw new NotImplementedException();
    }

    public IList<ILocalesProvider> Providers { get; } = new List<ILocalesProvider>();

    public string GetDefaultLocale() => throw new NotImplementedException();

    public string Translate(string key, params object[] args) => "mocked translation";

    public string TranslateOrNull(string key, params object[] args) => throw new NotImplementedException();

    public Dictionary<TEnum, string> TranslateEnumToDictionary<TEnum>() => throw new NotImplementedException();

    public List<string> TranslateEnumToList<TEnum>() => throw new NotImplementedException();

    public List<Tuple<TEnum, string>> TranslateEnumToTupleList<TEnum>() => throw new NotImplementedException();
    public void Init()
    {
        throw new NotImplementedException();
    }

    public void Unload() => throw new NotImplementedException();
}