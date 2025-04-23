// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Collections.Generic;
using Bodoconsult.I18N.Interfaces;

namespace Bodoconsult.I18N.ResourceProviders
{
    /// <summary>
    /// Base resource provider class
    /// </summary>
    public class BaseResourceProvider : IResourceProvider
    {
        /// <summary>
        /// All available resource items
        /// </summary>
        public IDictionary<string, string> ResourceItems { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Register all available resource items
        /// </summary>
        public virtual void RegisterResourceItems()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load key value pairs for string translations in a translation dictionary.
        /// If a key is already contained in the translation dictionary it should not be added again.
        /// </summary>
        /// <param name="language">Requested language</param>
        /// <param name="translations">Central translation dictionary to store the key value pairs in.
        /// </param>
        public virtual void LoadResourceItem(string language, IDictionary<string, string> translations)
        {
            throw new NotImplementedException();
        }
    }
}