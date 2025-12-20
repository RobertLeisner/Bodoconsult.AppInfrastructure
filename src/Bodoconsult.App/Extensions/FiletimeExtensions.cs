// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Runtime.InteropServices.ComTypes;

namespace Bodoconsult.App.Extensions;

/// <summary>
/// System.Runtime.InteropServices.ComTypes.FILETIME extensions
/// </summary>
public static class FiletimeExtensions
{
    /// <summary>
    /// Convert a <see cref="System.Runtime.InteropServices.ComTypes.FILETIME"/> to <see cref="DateTime"/>
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this FILETIME time)
    {
        var high = (ulong)time.dwHighDateTime;
        var low = (uint)time.dwLowDateTime;
        var fileTime = (long)((high << 32) + low);
        try
        {
            return DateTime.FromFileTimeUtc(fileTime);
        }
        catch
        {
            return DateTime.FromFileTimeUtc(0xFFFFFFFF);
        }
    }
}