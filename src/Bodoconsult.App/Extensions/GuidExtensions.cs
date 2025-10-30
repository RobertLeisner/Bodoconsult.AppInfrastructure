// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Extensions;

/// <summary>
/// Extension methods for <see cref="Guid"/> instances
/// </summary>
public static class GuidExtensions
{
    /// <summary>
    /// Convert Guid to string and remove all chars except numbers
    /// </summary>
    /// <param name="input">Input Guid instance</param>
    /// <returns>Guid as string with only number</returns>
    public static string ToPlainString(this Guid input)
    {
        return input.ToString().Replace("-", string.Empty);
    }
}