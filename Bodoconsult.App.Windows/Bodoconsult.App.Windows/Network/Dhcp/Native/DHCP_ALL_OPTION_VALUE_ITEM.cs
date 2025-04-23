﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DHCP_ALL_OPTIONS_VALUE_ITEM structure contain the option values for specific class/vendor pairs.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpAllOptionValueItem : IDisposable
{
    /// <summary>
    /// Unicode string that contains the name of the DHCP class for the option list.
    /// </summary>
    private readonly IntPtr ClassNamePointer;
    /// <summary>
    /// Unicode string that contains the name of the vendor for the option list.
    /// </summary>
    private readonly IntPtr VendorNamePointer;
    /// <summary>
    /// Specifies whether or not this set of options is vendor-specific. This value is TRUE if it is, and FALSE if it is not.
    /// </summary>
    public readonly bool IsVendor;
    /// <summary>
    /// DHCP_OPTION_VALUE_ARRAY structure that contains the option values for the specified vendor/class pair.
    /// </summary>
    private readonly IntPtr OptionsArrayPointer;

    /// <summary>
    /// Unicode string that contains the name of the DHCP class for the option list.
    /// </summary>
    public string ClassName => Marshal.PtrToStringUni(ClassNamePointer);
    /// <summary>
    /// Unicode string that contains the name of the vendor for the option list.
    /// </summary>
    public string VendorName => Marshal.PtrToStringUni(VendorNamePointer);
    /// <summary>
    /// DHCP_OPTION_VALUE_ARRAY structure that contains the option values for the specified vendor/class pair.
    /// </summary>
    public DhcpOptionValueArray OptionsArray
    {
        get
        {
            if (OptionsArrayPointer == IntPtr.Zero)
                return default;
            else
                return OptionsArrayPointer.MarshalToStructure<DhcpOptionValueArray>();
        }
    }

    public void Dispose()
    {
        Api.FreePointer(ClassNamePointer);
        Api.FreePointer(VendorNamePointer);

        if (OptionsArrayPointer != IntPtr.Zero)
        {
            OptionsArray.Dispose();
            Api.FreePointer(OptionsArrayPointer);
        }
    }
}