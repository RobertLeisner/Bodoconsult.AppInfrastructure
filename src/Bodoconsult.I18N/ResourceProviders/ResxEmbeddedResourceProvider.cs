// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.I18N.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace Bodoconsult.I18N.ResourceProviders;

/// <summary>
/// Reading I18N resources from resx files
/// </summary>
public class ResxEmbeddedResourceProvider : BaseResourceProvider
{

    // var resourceManager = new ResourceManager("FULLY.QUALIFIED.NAMESPACE.NO.EXTENSION", Assembly.GetExecutingAssembly());
    // var translatedString = resourceManager.GetString("NAME_OF_THE_STRING_IN_RESX_FILE");


    private readonly Assembly _assembly;

    private readonly string _resourcePath;

    private readonly Dictionary<string, ResourceSet> _cultures = new();

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="assembly">Assembly to load the resources from</param>
    /// <param name="resourcePath">Resource path in the assembly</param>
    public ResxEmbeddedResourceProvider(Assembly assembly, string resourcePath)
    {
        _assembly = assembly;
        _resourcePath = resourcePath;
    }

    /// <summary>
    /// Register all available resource items
    /// </summary>
    public override void RegisterResourceItems()
    {

        var rm = new ResourceManager(_resourcePath, _assembly);

        var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
        foreach (var culture in cultures)
        {
            var ietf = culture.IetfLanguageTag.ToUpperInvariant();

            if (culture.LCID == 127)
            {
                ietf = "EN-US";
            }

            try
            {
                var rs = rm.GetResourceSet(culture, true, false);

                if (rs == null)
                {
                    continue;
                }

                Debug.Print($"{ietf}{rs.GetString("Test.Message1")}");

                if (_cultures.TryAdd(ietf, rs))
                {
                    var kvp = new KeyValuePair<string, string>(ietf.ToUpperInvariant(), ietf);

                    ResourceItems.Add(kvp);
                }
            }
            catch
            {
                // Do nothing
            }
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
        var success = _cultures.TryGetValue(language.ToUpperInvariant(), out var result);

        if (!success)
        {
            success = _cultures.TryGetValue("EN-US", out result);

            if (!success)
            {
                // ToDo: 4digits
            }
        }

        if (result == null)
        {
            return;
        }

        foreach (DictionaryEntry entry in result)
        {
            var key = entry.Key.ToString() ?? "";
            var translation = result.GetString(entry.Key.ToString() ?? "");

            var p = new KeyValuePair<string, string>(key, translation);

            translations.Add(p);
        }

        //var content = FileHelper.GetTextResource(_assembly, result);

        //var lines = content.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

        //foreach (var line in lines)
        //{
        //    var s = line.Split('=');

        //    var p = new KeyValuePair<string, string>(s[0].Trim().ToUpperInvariant(), s[1].Trim());

        //    translations.Add(p);
        //}
    }
}