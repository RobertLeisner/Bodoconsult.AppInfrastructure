﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bodoconsult.I18N.LocalesProviders;

/// <summary>
/// Loads localization resources from files in an assemblies folder.
/// This folder should contain only I18N formatted resources.
/// I18N formatted means UTF8 encode text files with the name schema {lanuage code}.txt. Samples: en.txt, de.txt, es.txt, de-DE.txt, en-Us.txt, ...
/// </summary>
/// 
public class I18NFileLocalesProvider : BaseResourceProvider
{

    //private readonly Assembly _assembly;

    private readonly string _resourceFolder;


    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="assembly">Assembly to load the locales files from</param>
    /// <param name="resourceFolder">Relative path to assembly of the folder with the locales files </param>
    public I18NFileLocalesProvider(Assembly assembly, string resourceFolder)
    {
        //_assembly = assembly;
        var dir = new FileInfo(assembly.Location).DirectoryName;

        if (string.IsNullOrEmpty(dir)) return;

        _resourceFolder = Path.Combine(dir, resourceFolder);
    }


    /// <summary>
    /// Register all available resource items
    /// </summary>
    public override void RegisterLocalesItems()
    {

        if (string.IsNullOrEmpty(_resourceFolder)) return;

        var dir = new DirectoryInfo(_resourceFolder);

        foreach (var locale in dir.GetFiles().Where(x => x.Name.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase)))
        {
            var key = locale.Name.Replace(locale.Extension, "");

            var kvp = new KeyValuePair<string, string>(key, locale.FullName);

            LocaleItems.Add(kvp);
        }
    }

    public override IDictionary<string, string> LoadLocaleItem(string language)
    {
        var translations = new Dictionary<string, string>();

        // Check if language exists
        var success = LocaleItems.TryGetValue(language, out var result);

        if (!success) return translations;

        var content = File.ReadAllText(result);

        var lines = content.Split('\r', '\n');

        string key = null;
        string value = null;

        foreach (var line in lines)
        {
            var isEmpty = string.IsNullOrWhiteSpace(line);
            var isComment = !isEmpty && line.Trim().StartsWith("#");
            var isKeyValuePair = !isEmpty && !isComment && line.Contains("=");

            if ((isEmpty || isComment || isKeyValuePair) && key != null && value != null)
            {
                translations.Add(key, value);

                key = null;
                value = null;
            }

            if (isEmpty || isComment)
                continue;

            if (isKeyValuePair)
            {
                var kvp = line.Split(new[] { '=' }, 2);

                key = kvp[0].Trim();
                value = kvp[1].Trim().UnescapeLineBreaks();
            }
            else if (key != null && value != null)
            {
                value = value + Environment.NewLine + line.Trim().UnescapeLineBreaks();
            }
            //if (line.StartsWith("#")) continue;

            //var s = line.Split('=');

            //var p = new KeyValuePair<string, string>(s[0].Trim(), s[1].Trim().UnescapeLineBreaks());


        }

        if (key != null && value != null)
            translations.Add(key, value);

        return translations;
    }

    public override string ToString()
    {
        return $"{GetType().Name}({_resourceFolder})";
    }

}