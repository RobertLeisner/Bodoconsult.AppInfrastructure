// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.ErrorCodeHandling;

/// <summary>
/// Current implementation of a error code set provider
/// </summary>
public class ErrorCodeSetProvider: IErrorCodeSetProvider
{
    /// <summary>
    /// Exception code sets contained in the provider
    /// </summary>
    public IList<ErrorCodeSet> ErrorCodeSets { get; } = new List<ErrorCodeSet>();


    /// <summary>
    /// Add a list of <see cref="ErrorCodeSet"/> items to the provider
    /// </summary>
    /// <param name="data">A \r\n and semicolon separated string with error code sets</param>
    public void Add(string data)
    {
        var separator = new[] { "\r\n" };

        var rows = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

        foreach (var row in rows)
        {

            var itemData = row.Split(';');

            var codeSet = new ErrorCodeSet
            {
                Identifier = itemData[0],
                ErrorCode = Convert.ToInt32(itemData[1]),
                NextLevelErrorCode = Convert.ToInt32(itemData[2]),
                Message = itemData[3]
            };

            ErrorCodeSets.Add(codeSet);

        }
    }

    /// <summary>
    /// Add a single error code set to the provider
    /// </summary>
    /// <param name="codeSet">Error code set to add</param>
    public void Add(ErrorCodeSet codeSet)
    {
        ErrorCodeSets.Add(codeSet);
    }

    /// <summary>
    /// Get the translation data from the current provider
    /// </summary>
    /// <returns>List with translation entities</returns>
    public IList<ErrorCodeSetTranslation> GetTranslations()
    {
        return ErrorCodeSets.Select(codeSet => new ErrorCodeSetTranslation { Identifier = codeSet.Identifier, Message = codeSet.Message }).ToList();
    }

    /// <summary>
    /// Get the translation data from this provider as CSV string
    /// </summary>
    /// <returns></returns>
    public string GetTranslationsAsCsv()
    {
        throw new NotImplementedException();
    }
}