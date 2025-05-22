// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DHCPDS_SERVERS structure defines a list of DHCP servers in the context of directory services.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpdsServers
{
    /// <summary>
    /// Reserved. This value should be 0.
    /// </summary>
    public readonly uint Flags;
    /// <summary>
    /// Specifies the number of elements in Servers.
    /// </summary>
    public readonly uint NumElements;
    /// <summary>
    /// Pointer to an array of <see cref="DhcpdsServer"/> structures that contain information on individual DHCP servers.
    /// </summary>
    private readonly IntPtr ServersPointer;

    /// <summary>
    /// Pointer to an array of <see cref="DhcpdsServer"/> structures that contain information on individual DHCP servers.
    /// </summary>
    public IEnumerable<DhcpdsServer> Servers
    {
        get
        {
            var instanceIter = ServersPointer;
            var instanceSize = Marshal.SizeOf(typeof(DhcpdsServer));
            for (var i = 0; i < NumElements; i++)
            {
                yield return instanceIter.MarshalToStructure<DhcpdsServer>();
                instanceIter += instanceSize;
            }
        }
    }
}