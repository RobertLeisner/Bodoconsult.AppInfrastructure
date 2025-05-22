// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Runtime.InteropServices;
using System.Security;

namespace Bodoconsult.App.Extensions;

/// <summary>
/// Extension methods for string class
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Replace [0xXXX] tags in a string with a hex char. [0x1\ will be replaced with \u
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string ReplaceHexTag(this string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return "";
        }

        if (!data.Contains("[0x"))
        {
            return data;
        }


        var i = data.IndexOf("[0x", StringComparison.OrdinalIgnoreCase);

        var j = data.IndexOf("]", i + 1, StringComparison.OrdinalIgnoreCase);

        while (i > -1)
        {
            var hex = $"0x{data.Substring(i + 3, j - i - 3).ToUpperInvariant()}";

            var hexInt = Convert.ToInt32(hex, 16);

            data = data.Substring(0, i)
                   + (char)hexInt + data.Substring(j + 1);


            i = data.IndexOf("[0x", i, StringComparison.OrdinalIgnoreCase);
            if (i < 0)
            {
                break;
            }

            j = data.IndexOf("]", i + 1, StringComparison.OrdinalIgnoreCase);

        }

        return data;
    }

    /// <summary>
    /// String value as SQL string
    /// </summary>
    /// <param name="value">String value to format as SQL</param>
    /// <returns>Value as SQL string formatted</returns>
    public static string AsSqlString(this string value)
    {
        return string.IsNullOrEmpty(value) ? "null" : $"'{value}'";
    }

    /// <summary>
    ///  Limit the length of a string to a certain value
    /// </summary>
    /// <param name="value">String</param>
    /// <param name="length">Allowed maximum length</param>
    /// <returns>Truncated string</returns>
    public static string LimitToLength(this string value, int length)
    {
        if (value == null)
        {
            return null;
        }

        value = value.TrimEnd();

        if (string.IsNullOrEmpty(value) || value.Length<= length)
        {
            return value;
        }

        return value[..length];
    }

    /// <summary>
    /// Get a string froma secure string
    /// </summary>
    /// <param name="value">Secure string</param>
    /// <returns>Clear text string</returns>
    public static string SecureStringToString(this SecureString value)
    {
        var ptr = Marshal.SecureStringToGlobalAllocUnicode(value);
        try
        {
            return Marshal.PtrToStringUni(ptr);
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(ptr);
        }
    }


}