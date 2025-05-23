﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DHCP_ALL_OPTION_VALUES structure defines the set of all option values defined on a DHCP server, organized according to class/vendor pairing.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpAllOptionValues : IDisposable
{
    /// <summary>
    /// Reserved. This value should be set to 0.
    /// </summary>
    public readonly int Flags;
    /// <summary>
    /// Specifies the number of elements in Options.
    /// </summary>
    public readonly int NumElements;
    /// <summary>
    /// Pointer to a list of structures that contain the option values for specific class/vendor pairs.
    /// </summary>
    private readonly IntPtr OptionsPointer;

    /// <summary>
    /// A list of <see cref="DhcpAllOptionValueItem"/> structures containing the option values for specific class/vendor pairs.
    /// </summary>
    public IEnumerable<DhcpAllOptionValueItem> Options
    {
        get
        {
            if (NumElements == 0 || OptionsPointer == IntPtr.Zero)
                yield break;

            var iter = OptionsPointer;
            var size = Marshal.SizeOf(typeof(DhcpAllOptionValueItem));
            for (var i = 0; i < NumElements; i++)
            {
                yield return iter.MarshalToStructure<DhcpAllOptionValueItem>();
                iter += size;
            }
        }
    }

    public void Dispose()
    {
        foreach (var option in Options)
            option.Dispose();

        Api.FreePointer(OptionsPointer);
    }
}