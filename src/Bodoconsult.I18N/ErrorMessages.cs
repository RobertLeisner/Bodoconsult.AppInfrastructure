// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.I18N;

/// <summary>
/// Error messages used by I18N
/// </summary>
public static class ErrorMessages
{
    /// <summary>
    /// Error message for locales provider cannot be null
    /// </summary>
    public const string ProviderNull = "Locales provider cannot be null";
    /// <summary>
    /// Error message for locale reader extension is needed
    /// </summary>
    public const string ReaderExtensionNeeded = "Locale reader extension is needed";
    /// <summary>
    /// Error message for locale reader extension should start with...
    /// </summary>
    public const string ReaderExtensionStartWithDot = "Locale reader extension should start with '.'";
    /// <summary>
    /// Error message for locale reader extension should contain at least one char
    /// </summary>
    public const string ReaderExtensionOneChar = "Locale reader extension should contain at least one char";
    /// <summary>
    /// Error message for locale reader extension should contain just one dot
    /// </summary>
    public const string ReaderExtensionJustOneDot = "Locale reader extension should contain just one dot";
    /// <summary>
    /// Error message for the same extension cannot be added at two different readers
    /// </summary>
    public const string ReaderExtensionTwice = "The same extension cannot be added at two different readers";
    /// <summary>
    /// Error message for the same reader cannot be added twice
    /// </summary>
    public const string ReaderTwice = "The same reader cannot be added twice";
    /// <summary>
    /// Error message for no locales found in specified the host assembly
    /// </summary>
    public const string NoLocalesFound = "No locales found in specified the host assembly";
    /// <summary>
    /// Error message for a reader failed to read the file stream
    /// </summary>
    public const string ReaderException = "A reader failed to read the file stream";
}