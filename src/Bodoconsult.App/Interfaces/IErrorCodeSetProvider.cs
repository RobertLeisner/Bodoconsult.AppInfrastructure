// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.Interfaces;

/// <summary>
/// Interface for creating error code set provider to arrange existing error codes
/// </summary>
public interface IErrorCodeSetProvider
{
    /// <summary>
    /// Error code sets contained in the provider
    /// </summary>
    IList<ErrorCodeSet> ErrorCodeSets { get; }

    /// <summary>
    /// Add a list of <see cref="ErrorCodeSet"/> items to the provider
    /// </summary>
    /// <param name="data">A \r\n and semicolon separated string with error code sets</param>
    void Add(string data);

    /// <summary>
    /// Add a single error code set to the provider
    /// </summary>
    /// <param name="codeSet">Error code set to add</param>
    void Add(ErrorCodeSet codeSet);

    /// <summary>
    /// Get the translation data from the current provider
    /// </summary>
    /// <returns>List with translation entities</returns>
    IList<ErrorCodeSetTranslation> GetTranslations();

    /// <summary>
    /// Get the translation data from this provider as CSV string
    /// </summary>
    /// <returns></returns>
    string GetTranslationsAsCsv();

}