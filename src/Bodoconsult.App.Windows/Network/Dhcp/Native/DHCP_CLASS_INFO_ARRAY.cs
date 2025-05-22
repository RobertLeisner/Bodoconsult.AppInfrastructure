﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DHCP_CLASS_INFO_ARRAY structure defines an array of elements that contain DHCP class information.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpClassInfoArray : IDisposable
{
    /// <summary>
    /// Specifies the number of elements in Classes.
    /// </summary>
    public readonly int NumElements;
    /// <summary>
    /// Pointer to an array of <see cref="DhcpClassInfo"/> structures that contain DHCP class information.
    /// </summary>
    private readonly IntPtr ClassesPointer;

    /// <summary>
    /// Pointer to an array of <see cref="DhcpClassInfo"/> structures that contain DHCP class information.
    /// </summary>
    public IEnumerable<DhcpClassInfo> Classes
    {
        get
        {
            if (NumElements == 0 || ClassesPointer == IntPtr.Zero)
                yield break;

            var iter = ClassesPointer;
            var size = Marshal.SizeOf(typeof(DhcpClassInfo));
            for (var i = 0; i < NumElements; i++)
            {
                yield return iter.MarshalToStructure<DhcpClassInfo>();
                iter += size;
            }
        }
    }

    public void Dispose()
    {
        foreach (var @class in Classes)
            @class.Dispose();
            
        Api.FreePointer(ClassesPointer);
    }
}