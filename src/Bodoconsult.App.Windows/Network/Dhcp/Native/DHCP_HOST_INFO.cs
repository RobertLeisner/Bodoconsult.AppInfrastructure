// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DHCP_HOST_INFO structure defines information on a DHCP server (host).
/// </summary>
/// <remarks>
/// When this structure is populated by the DHCP Server, the HostName and NetBiosName members may be set to NULL.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpHostInfo : IDisposable
{
    /// <summary>
    /// DHCP_IP_ADDRESS value that contains the IP address of the DHCP server.
    /// </summary>
    public readonly DhcpIpAddress IpAddress;
    /// <summary>
    /// Unicode string that contains the NetBIOS name of the DHCP server.
    /// </summary>
    private readonly IntPtr NetBiosNamePointer;
    /// <summary>
    /// Unicode string that contains the network name of the DHCP server.
    /// </summary>
    private readonly IntPtr ServerNamePointer;

    /// <summary>
    /// Unicode string that contains the NetBIOS name of the DHCP server.
    /// </summary>
    public string NetBiosName => Marshal.PtrToStringUni(NetBiosNamePointer);

    /// <summary>
    /// Unicode string that contains the network name of the DHCP server.
    /// </summary>
    public string ServerName => Marshal.PtrToStringUni(ServerNamePointer);

    public void Dispose()
    {
        Api.FreePointer(NetBiosNamePointer);

        // Freeing ServerName causes heap corruption ?!?!?
        // Api.FreePointer(ServerNamePointer);
    }
}

/// <summary>
/// The DHCP_HOST_INFO structure defines information on a DHCP server (host).
/// </summary>
/// <remarks>
/// When this structure is populated by the DHCP Server, the HostName and NetBiosName members may be set to NULL.
/// </remarks>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal readonly struct DhcpHostInfoManaged
{
    /// <summary>
    /// DHCP_IP_ADDRESS value that contains the IP address of the DHCP server.
    /// </summary>
    public readonly DhcpIpAddress IpAddress;
    /// <summary>
    /// Unicode string that contains the NetBIOS name of the DHCP server.
    /// </summary>
    private readonly string NetBiosName;
    /// <summary>
    /// Unicode string that contains the network name of the DHCP server.
    /// </summary>
    private readonly string ServerName;

    public DhcpHostInfoManaged(DhcpIpAddress ipAddress, string netBiosName, string serverName)
    {
        IpAddress = ipAddress;
        NetBiosName = netBiosName;
        ServerName = serverName;
    }
}