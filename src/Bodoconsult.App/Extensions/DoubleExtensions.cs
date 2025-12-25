// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Globalization;
using Bodoconsult.App.Abstractions.Helpers;

namespace Bodoconsult.App.Extensions;

/// <summary>
/// Extension methods for double class
/// </summary>
public static class DoubleExtensions
{
    /// <summary>
    /// Double value as SQL string
    /// </summary>
    /// <param name="value">Bool value to format as SQL</param>
    /// <param name="formatString">Format string. Default 0</param>
    /// <returns>Value as SQL string formatted</returns>
    public static string AsSqlString(this double value, string formatString = "0")
    {
        return value.ToString(formatString, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Convert cm to pt
    /// </summary>
    /// <param name="cm">cm</param>
    /// <returns>Point pt</returns>
    public static string FromCmToPoint(this double cm)
    {
        var raw = MeasurementHelper.GetPtFromCm(cm);
        var value = Math.Ceiling(raw);
        return value.ToString("0");
    }
}