﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bodoconsult.I18N.Helpers;

namespace Bodoconsult.I18N.ResourceProviders
{

    /// <summary>
    /// Loads localization resources from embedded resource in a assemblies folder.
    /// This folder should contain only I18N formatted resources.
    /// I18N formatted means UTF8 encode text files with the name schema {lanuage code}.txt. Samples: en.txt, de.txt, es.txt, de-DE.txt, en-Us.txt, ...
    /// </summary>
    /// 
    public class I18NEmbeddedResourceProvider: BaseResourceProvider
    {

        private readonly Assembly _assembly;

        private readonly string _resourceFolder;



        public I18NEmbeddedResourceProvider(Assembly assembly, string resourceFolder)
        {
            _assembly = assembly;
            _resourceFolder = resourceFolder;

            if (!_resourceFolder.EndsWith(".")) _resourceFolder += ".";
        }


        /// <summary>
        /// Register all available resource items
        /// </summary>
        public override void RegisterResourceItems()
        {


            var len = _resourceFolder.Length;

            var localeResources = _assembly.GetManifestResourceNames().Where(x => x.StartsWith(_resourceFolder, StringComparison.InvariantCultureIgnoreCase));

            foreach (var locales in localeResources)
            {
                var key = locales.Substring(len, locales.Length - len - 4).ToUpperInvariant();

                var kvp = new KeyValuePair<string, string>(key, locales);

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

            string result;

            // Check if language exists
            var success = ResourceItems.TryGetValue(language.ToUpperInvariant(), out result);

            if (!success)
            {
                // ToDo: 4digits
            }

            var content = FileHelper.GetTextResource(_assembly, result);

            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var s = line.Split('=');

                var p = new KeyValuePair<string, string>(s[0].Trim().ToUpperInvariant(), s[1].Trim());

                translations.Add(p);
            }

        }

    }
}
