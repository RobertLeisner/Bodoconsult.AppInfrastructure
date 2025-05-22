// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DHCP_SEARCH_INFO structure defines the DHCP client record data used to search against for particular server operations.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpSearchInfoManagedIpAddress
{
    private readonly IntPtr searchType;

    /// <summary>
    /// DHCP_SEARCH_INFO_TYPE enumeration value that specifies the data included in the subsequent member of this structure.
    /// </summary>
    public DhcpSearchInfoType SearchType => (DhcpSearchInfoType)searchType;

    /// <summary>
    /// DHCP_IP_ADDRESS value that specifies a client IP address. This field is populated if SearchType is set to DhcpClientIpAddress.
    /// </summary>
    public readonly DhcpIpAddress ClientIpAddress;

    public DhcpSearchInfoManagedIpAddress(DhcpIpAddress clientIpAddress)
    {
        searchType = (IntPtr)DhcpSearchInfoType.DhcpClientIpAddress;
        ClientIpAddress = clientIpAddress;
    }
}

/// <summary>
/// The DHCP_SEARCH_INFO structure defines the DHCP client record data used to search against for particular server operations.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpSearchInfoManagedHardwareAddress
{
    private readonly IntPtr searchType;

    /// <summary>
    /// DHCP_SEARCH_INFO_TYPE enumeration value that specifies the data included in the subsequent member of this structure.
    /// </summary>
    public DhcpSearchInfoType SearchType => (DhcpSearchInfoType)searchType;

    /// <summary>
    /// DHCP_CLIENT_UID structure that contains a hardware MAC address. This field is populated if SearchType is set to DhcpClientHardwareAddress.
    /// </summary>
    public readonly DhcpClientUid ClientHardwareAddress;

    public DhcpSearchInfoManagedHardwareAddress(DhcpClientUid clientHardwareAddress)
    {
        searchType = (IntPtr)DhcpSearchInfoType.DhcpClientHardwareAddress;
        ClientHardwareAddress = clientHardwareAddress;
    }
}

/// <summary>
/// The DHCP_SEARCH_INFO structure defines the DHCP client record data used to search against for particular server operations.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpSearchInfoManagedName
{
    private readonly IntPtr searchType;

    /// <summary>
    /// DHCP_SEARCH_INFO_TYPE enumeration value that specifies the data included in the subsequent member of this structure.
    /// </summary>
    public DhcpSearchInfoType SearchType => (DhcpSearchInfoType)searchType;

    /// <summary>
    /// Unicode string that specifies the network name of the DHCP client. This field is populated if SearchType is set to DhcpClientName.
    /// </summary>
    public readonly IntPtr ClientName;

    public DhcpSearchInfoManagedName(IntPtr clientName)
    {
        searchType = (IntPtr)DhcpSearchInfoType.DhcpClientName;
        ClientName = clientName;
    }
}