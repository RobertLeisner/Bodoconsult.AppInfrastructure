﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DATE_TIME structure defines a 64-bit integer value that contains a date/time, expressed as the number of ticks (100-nanosecond increments) since 12:00 midnight, January 1, 1 C.E. in the Gregorian calendar. 
/// </summary>
[StructLayout(LayoutKind.Explicit)]
internal readonly struct DateTime
{
    [FieldOffset(0)]
    public readonly long dwDateTime;

    private DateTime(long fileTimeUtc)
    {
        dwDateTime = fileTimeUtc;
    }

    private global::System.DateTime ToDateTime()
    {
        if (dwDateTime == 0)
            return global::System.DateTime.SpecifyKind(global::System.DateTime.MinValue, DateTimeKind.Utc);
        else if (dwDateTime == long.MaxValue)
            return global::System.DateTime.SpecifyKind(global::System.DateTime.MaxValue, DateTimeKind.Utc);
        else
            return global::System.DateTime.FromFileTimeUtc(dwDateTime);
    }

    public static DateTime FromDateTime(global::System.DateTime dateTime)
    {
        if (dateTime == global::System.DateTime.MinValue)
            return new DateTime(0);
        else if (dateTime == global::System.DateTime.MaxValue)
            return new DateTime(long.MaxValue);
        else
            return new DateTime(dateTime.ToFileTimeUtc());
    }

    public static implicit operator global::System.DateTime(DateTime dateTime)
        => dateTime.ToDateTime();

    public static implicit operator DateTime(global::System.DateTime dateTime)
        => FromDateTime(dateTime);
}