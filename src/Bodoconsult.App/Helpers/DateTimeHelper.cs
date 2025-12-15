// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Helpers;

/// <summary>
/// Helper class for <see cref="DateTime"/>
/// </summary>
public static class DateTimeHelper
{

    // works great most of the time

    /// <summary>
    /// Convert a <see cref="System.Runtime.InteropServices.ComTypes.FILETIME "/> to a <see cref="DateTime"/>
    /// </summary>
    /// <param name="time">File time</param>
    /// <returns>Date</returns>
    public static DateTime ConvertToDateTime(System.Runtime.InteropServices.ComTypes.FILETIME time)
    {
        long highBits = time.dwHighDateTime;
        highBits = highBits << 32;

        return DateTime.FromFileTimeUtc(highBits + (long)(uint)time.dwLowDateTime);
    }
}