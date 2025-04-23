// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Helpers;

public static class DateTimeHelper
{

    // works great most of the time
    public static DateTime ConvertToDateTime(System.Runtime.InteropServices.ComTypes.FILETIME time)
    {
        long highBits = time.dwHighDateTime;
        highBits = highBits << 32;

        return DateTime.FromFileTimeUtc(highBits + (long)(uint)time.dwLowDateTime);
    }
}