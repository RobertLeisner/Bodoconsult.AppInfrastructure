// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DHCP_OPTION_SCOPE_INFO structure defines information about the options provided for a certain DHCP scope.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpOptionScopeInfoManagedGlobal
{
    private readonly IntPtr scopeType;

    /// <summary>
    /// <see cref="DhcpOptionScopeType"/> enumeration value that defines the scope type of the associated DHCP options, and indicates which of the following fields in the union will be populated.
    /// </summary>
    public DhcpOptionScopeType ScopeType => (DhcpOptionScopeType)scopeType;

    public readonly IntPtr GlobalScopeInfo;

    public DhcpOptionScopeInfoManagedGlobal(IntPtr globalScopeInfo)
    {
        scopeType = (IntPtr)DhcpOptionScopeType.DhcpGlobalOptions;
        GlobalScopeInfo = globalScopeInfo;
    }
}

/// <summary>
/// The DHCP_OPTION_SCOPE_INFO structure defines information about the options provided for a certain DHCP scope.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpOptionScopeInfoManagedSubnet
{
    private readonly IntPtr scopeType;

    /// <summary>
    /// <see cref="DhcpOptionScopeType"/> enumeration value that defines the scope type of the associated DHCP options, and indicates which of the following fields in the union will be populated.
    /// </summary>
    public DhcpOptionScopeType ScopeType => (DhcpOptionScopeType)scopeType;

    /// <summary>
    /// DHCP_IP_ADDRESS value that contains the subnet ID as a DWORD.
    /// </summary>
    public readonly DhcpIpAddress SubnetScopeInfo;

    public DhcpOptionScopeInfoManagedSubnet(DhcpIpAddress subnetScopeInfo)
    {
        scopeType = (IntPtr)DhcpOptionScopeType.DhcpSubnetOptions;
        SubnetScopeInfo = subnetScopeInfo;
    }
}

/// <summary>
/// The DHCP_OPTION_SCOPE_INFO structure defines information about the options provided for a certain DHCP scope.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpOptionScopeInfoManagedReserved
{
    private readonly IntPtr scopeType;

    /// <summary>
    /// <see cref="DhcpOptionScopeType"/> enumeration value that defines the scope type of the associated DHCP options, and indicates which of the following fields in the union will be populated.
    /// </summary>
    public DhcpOptionScopeType ScopeType => (DhcpOptionScopeType)scopeType;

    /// <summary>
    /// DHCP_IP_ADDRESS value that contains an IP address used to identify the reservation.
    /// </summary>
    public readonly DhcpIpAddress ReservedIpAddress;

    /// <summary>
    /// DHCP_IP_ADDRESS value that specifies the subnet ID of the subnet containing the reservation.
    /// </summary>
    public readonly DhcpIpAddress ReservedIpSubnetAddress;

    public DhcpOptionScopeInfoManagedReserved(DhcpIpAddress reservedIpSubnetAddress, DhcpIpAddress reservedIpAddress)
    {
        scopeType = (IntPtr)DhcpOptionScopeType.DhcpReservedOptions;
        ReservedIpAddress = reservedIpAddress;
        ReservedIpSubnetAddress = reservedIpSubnetAddress;
    }
}

/// <summary>
/// The DHCP_OPTION_SCOPE_INFO structure defines information about the options provided for a certain DHCP scope.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpOptionScopeInfoManagedMScope
{
    private readonly IntPtr scopeType;

    /// <summary>
    /// <see cref="DhcpOptionScopeType"/> enumeration value that defines the scope type of the associated DHCP options, and indicates which of the following fields in the union will be populated.
    /// </summary>
    public DhcpOptionScopeType ScopeType => (DhcpOptionScopeType)scopeType;

    /// <summary>
    /// Pointer to a Unicode string that contains the multicast scope name (usually represented as the IP address of the multicast router).
    /// </summary>
    [MarshalAs(UnmanagedType.LPWStr)]
    public readonly string MScopeInfo;

    public DhcpOptionScopeInfoManagedMScope(string mScopeInfo)
    {
        scopeType = (IntPtr)DhcpOptionScopeType.DhcpMScopeOptions;
        MScopeInfo = mScopeInfo;
    }
}