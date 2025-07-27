﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Models;
using Bodoconsult.I18N.LocalesProviders;
using System.IO;
using System.Reflection;

namespace Bodoconsult.App.Wpf.I18N
{

    /// <summary>
    /// I18NResourceProvider implementation for I18N resources loaded from WPF resource files. Locales file must be named Culture.XX.xaml with XX being the language identifier
    /// </summary>
    public class WpfFileLocalesProvider : BaseResourceProvider
    {
        private readonly string _resourceFolder;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="assembly">Assembly to load the locales from</param>
        /// <param name="resourceFolder">Folder relative to app path the locales are stored in. Locales file must be named Culture.XX.xaml with XX being the language identifier</param>
        public WpfFileLocalesProvider(Assembly assembly, string resourceFolder)
        {
            var dir = new FileInfo(assembly.Location).DirectoryName;

            if (string.IsNullOrEmpty(dir))
            {
                return;
            }

            _resourceFolder = Path.Combine(dir, resourceFolder);
        }

        /// <summary>
        /// Register all available resource items
        /// </summary>
        public override void RegisterLocalesItems()
        {
            if (string.IsNullOrEmpty(_resourceFolder))
            {
                return;
            }

            var dir = new DirectoryInfo(_resourceFolder);

            foreach (var locale in dir.GetFiles()
                         .Where(x => x.Name.EndsWith(".xaml", StringComparison.InvariantCultureIgnoreCase)))
            {
                var key = locale.Name.Replace(locale.Extension, "").Replace("Culture.", "");

                var kvp = new KeyValuePair<string, string>(key, locale.FullName);

                LocaleItems.Add(kvp);
            }
        }


        /// <summary>
        /// Load key value pairs for string translations in a translation dictionary.
        /// If a key is already contained in the translation dictionary it should not be added again.
        /// </summary>
        /// <param name="language">Requested language</param>
        /// <returns>Translation dictionary with key value pairs in.
        /// </returns>
        public override IDictionary<string, string> LoadLocaleItem(string language)
        {
            var translations = new Dictionary<string, string>();

            // Check if language exists
            var success = LocaleItems.TryGetValue(language, out var path);

            if (!success)
            {
                return translations;
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

                var key1 = key.ToString();
                if (string.IsNullOrEmpty(key1))
                {
                    continue;
                }

                var value = rd[key];

                if (value == null)
                {
                    continue;
                }

                translations.Add(key1, value.ToString());
            }

            return translations;
        }
    }
}
