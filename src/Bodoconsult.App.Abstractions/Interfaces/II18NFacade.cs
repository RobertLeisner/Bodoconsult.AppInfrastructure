// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Abstractions.Interfaces
{
    /// <summary>
    /// Facade for I18N language handling for UI strings
    /// </summary>
    public interface II18NFacade
    {
        /// <summary>
        /// Request the translated value of a key string for the current language
        /// </summary>
        /// <param name="key">Key to search</param>
        /// <returns>Translated value of the requested key</returns>
        string Translate(string key);
    }
}
