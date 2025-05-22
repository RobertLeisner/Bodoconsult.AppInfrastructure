// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Extensions;

/// <summary>
/// System.Runtime.InteropServices.ComTypes.FILETIME extensions
/// </summary>
public static class FiletimeExtensions
{
    public static DateTime ToDateTime(this System.Runtime.InteropServices.ComTypes.FILETIME time)
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