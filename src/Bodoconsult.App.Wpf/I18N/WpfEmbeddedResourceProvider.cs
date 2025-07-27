// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Models;
using Bodoconsult.I18N.Helpers;
using Bodoconsult.I18N.ResourceProviders;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Baml2006;

namespace Bodoconsult.App.Wpf.I18N;

public class WpfEmbeddedResourceProvider : BaseResourceProvider
{
    private readonly string _resourceFolder;

    private readonly Assembly _assembly;


    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="assembly">Assembly to load the locales from</param>
    /// <param name="resourceFolder">Folder relative to app path the locales are stored in. Locales file must be named Culture.XX.xaml with XX being the language identifier</param>
    public WpfEmbeddedResourceProvider(Assembly assembly, string resourceFolder)
    {
        _assembly = assembly;
        _resourceFolder = resourceFolder;

        if (_resourceFolder.StartsWith("/"))
        {
            _resourceFolder = _resourceFolder[1..];
        }

        if (_resourceFolder.EndsWith("/"))
        {
            _resourceFolder = _resourceFolder[..^1];
        }

    }

    /// <summary>
    /// Register all available resource items
    /// </summary>
    public override void RegisterResourceItems()
    {

        var assName = _assembly.GetName().Name;

        var lResourceContainerName = $"{assName}.g";
        var lResourceManager = new ResourceManager(lResourceContainerName, _assembly);

        var lResourceSet = lResourceManager.GetResourceSet(Thread.CurrentThread.CurrentCulture, true, true);

        if (lResourceSet == null)
        {
            return;
        }

        foreach (DictionaryEntry lEesource in lResourceSet)
        {
            if (lEesource.ToString() == null)
            {
                continue;
            }

            var key = lEesource.Key.ToString().Split(',')[0]
                .ToLowerInvariant()
                .Replace($"{_resourceFolder}/", "", StringComparison.InvariantCultureIgnoreCase).Replace(".baml", "");

            if (!key.StartsWith("culture."))
            {
                continue;
            }

            var path = $"pack://application:,,,/{assName};component/{_resourceFolder}/{key}.xaml";
            var kvp = new KeyValuePair<string, string>(key.Replace("culture.", ""), path);

            ResourceItems.Add(kvp);
        }
    }

    /// <summary>
    /// Load key value pairs for string translations in a translation dictionary.
    /// If a key is already contained in the translation dictionary it should not be added again.
    /// </summary>
    /// <param name="language">Requested language</param>
    /// <param name="translations">Central translation dictionary to store the key value pairs in.
    /// </param>
    public override void LoadResourceItem(string language, IDictionary<string, string> translations)
    {
        // Check if language exists
        var success = ResourceItems.TryGetValue(language, out var path);

        if (!success)
        {
            return;
        }

        var rd = new SharedResourceDictionary
        {
            Source = new Uri(path, UriKind.RelativeOrAbsolute)
        };

        foreach (var key in rd.Keys)
        {
            if (key == null)
            {
                continue;
            }
            var value = rd[key];
            if (value == null)
            {
                continue;
            }

            var kvp = new KeyValuePair<string, string>(key.ToString(), value.ToString());
            translations.Add(kvp);
        }
    }
}