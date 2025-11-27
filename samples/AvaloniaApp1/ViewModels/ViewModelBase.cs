// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.I18N;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApp1.ViewModels;

public abstract class ViewModelBase : ObservableObject
{
    /// <summary>
    /// Use the indexer to translate keys. If you need string formatting, use <code>Translate()</code> instead
    /// </summary>
    public string this[string key]
        => I18N.Current.Translate(key);

}