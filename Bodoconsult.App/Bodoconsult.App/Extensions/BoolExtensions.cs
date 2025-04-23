// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.Extensions;

/// <summary>
/// Extension methods for bool class
/// </summary>
public static class BoolExtensions
{

    /// <summary>
    /// Bool value as SQL string
    /// </summary>
    /// <param name="value">Bool value to format as SQL</param>
    /// <returns>Value as SQL string formatted</returns>
    public static string AsSqlString(this bool value)
    {
        return value ? "1" : "0";
    }
}