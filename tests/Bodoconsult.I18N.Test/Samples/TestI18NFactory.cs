// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.I18N.DependencyInjection;
using Bodoconsult.I18N.LocalesProviders;
using Bodoconsult.I18N.Test.Helpers;

namespace Bodoconsult.I18N.Test.Samples;

/// <summary>
/// Factory to create a fully configured I18N factory
/// </summary>
public class TestI18NFactory: BaseI18NFactory
{
    /// <summary>
    /// Creating a configured II18N instance
    /// </summary>
    /// <returns>An II18N instance</returns>
    public override II18N CreateInstance()
    {
        // Set the fallback language
        I18NInstance.SetFallbackLocale("en");

        // Load a provider
        ILocalesProvider provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Samples.Locales");

        I18N.Current.AddProvider(provider);

        // Add provider 2
        provider = new I18NEmbeddedResourceLocalesProvider(TestHelper.CurrentAssembly,
            "Bodoconsult.I18N.Test.Locales");

        I18N.Current.AddProvider(provider);

        // Load more providers if necessary
        // ...

        // Init instance with lanugae from running thread
        I18NInstance.Init();

        // Return the instance
        return I18NInstance;
    }
}