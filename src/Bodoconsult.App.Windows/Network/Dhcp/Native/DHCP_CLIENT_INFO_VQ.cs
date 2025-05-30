﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

/// <summary>
/// The DHCP_CLIENT_INFO_VQ structure defines information about the DHCPv4 client.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal readonly struct DhcpClientInfoVq : IDisposable
{
    /// <summary>
    /// DHCP_IP_ADDRESS type value that contains the DHCPv4 client's IPv4 address. 
    /// </summary>
    public readonly DhcpIpAddress ClientIpAddress;
    /// <summary>
    /// DHCP IP_MASK type value that contains the DHCPv4 client's IPv4 subnet mask address.
    /// </summary>
    public readonly DhcpIpMask SubnetMask;
    /// <summary>
    /// GUID value that contains the hardware address (MAC address) of the DHCPv4 client.
    /// </summary>
    public readonly DhcpBinaryData ClientHardwareAddress;
    /// <summary>
    /// Pointer to a null-terminated Unicode string that represents the DHCPv4 client's machine name.
    /// </summary>
    private readonly IntPtr ClientNamePointer;
    /// <summary>
    /// Pointer to a null-terminated Unicode string that represents the description given to the DHCPv4 client.
    /// </summary>
    private readonly IntPtr ClientCommentPointer;
    /// <summary>
    /// DATE_TIME structure that contains the lease expiry time for the DHCPv4 client. This is UTC time represented in the FILETIME format.
    /// </summary>
    public readonly DateTime ClientLeaseExpires;
    /// <summary>
    /// DHCP_HOST_INFO structure that contains information about the host machine (DHCPv4 server machine) that has provided a lease to the DHCPv4 client.
    /// </summary>
    public readonly DhcpHostInfo OwnerHost;
    /// <summary>
    /// Possible types of the DHCPv4 client.
    /// </summary>
    public readonly DhcpClientType ClientType;
    /// <summary>
    /// Possible states of the IPv4 address given to the DHCPv4 client.
    /// </summary>
    public readonly byte AddressState;
    /// <summary>
    /// QuarantineStatus enumeration that specifies possible health status values for the DHCPv4 client, as validated at the NAP server.
    /// </summary>
    public readonly QuarantineStatus Status;
    /// <summary>
    /// This is of type DATE_TIME, containing the end time of the probation if the DHCPv4 client is on probation. For this time period, the DHCPv4 client has full access to the network.
    /// </summary>
    public readonly DateTime ProbationEnds;
    /// <summary>
    /// If TRUE, the DHCPv4 client is quarantine-enabled; if FALSE, it is not.
    /// </summary>
    public readonly bool QuarantineCapable;

    /// <summary>
    /// Pointer to a null-terminated Unicode string that represents the DHCPv4 client's machine name.
    /// </summary>
    public string ClientName => Marshal.PtrToStringUni(ClientNamePointer);

    /// <summary>
    /// Pointer to a null-terminated Unicode string that represents the description given to the DHCPv4 client.
    /// </summary>
    public string ClientComment => Marshal.PtrToStringUni(ClientCommentPointer);

    public DhcpServerIpAddress SubnetAddress => (ClientIpAddress & SubnetMask).AsNetworkToIpAddress();

    public void Dispose()
    {
        ClientHardwareAddress.Dispose();
        Api.FreePointer(ClientNamePointer);
        Api.FreePointer(ClientCommentPointer);
        OwnerHost.Dispose();
    }
}

/// <summary>
/// The DHCP_CLIENT_INFO_VQ structure defines information about the DHCPv4 client.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal readonly struct DhcpClientInfoVqManaged : IDisposable
{
    /// <summary>
    /// DHCP_IP_ADDRESS type value that contains the DHCPv4 client's IPv4 address. 
    /// </summary>
    public readonly DhcpIpAddress ClientIpAddress;
    /// <summary>
    /// DHCP IP_MASK type value that contains the DHCPv4 client's IPv4 subnet mask address.
    /// </summary>
    public readonly DhcpIpMask SubnetMask;
    /// <summary>
    /// GUID value that contains the hardware address (MAC address) of the DHCPv4 client.
    /// </summary>
    public readonly DhcpBinaryDataManaged ClientHardwareAddress;
    /// <summary>
    /// Pointer to a null-terminated Unicode string that represents the DHCPv4 client's machine name.
    /// </summary>
    private readonly string ClientName;
    /// <summary>
    /// Pointer to a null-terminated Unicode string that represents the description given to the DHCPv4 client.
    /// </summary>
    private readonly string ClientComment;
    /// <summary>
    /// DATE_TIME structure that contains the lease expiry time for the DHCPv4 client. This is UTC time represented in the FILETIME format.
    /// </summary>
    public readonly DateTime ClientLeaseExpires;
    /// <summary>
    /// DHCP_HOST_INFO structure that contains information about the host machine (DHCPv4 server machine) that has provided a lease to the DHCPv4 client.
    /// </summary>
    public readonly DhcpHostInfoManaged OwnerHost;
    /// <summary>
    /// Possible types of the DHCPv4 client.
    /// </summary>
    public readonly DhcpClientType ClientType;
    /// <summary>
    /// Possible states of the IPv4 address given to the DHCPv4 client.
    /// </summary>
    public readonly byte AddressState;
    /// <summary>
    /// QuarantineStatus enumeration that specifies possible health status values for the DHCPv4 client, as validated at the NAP server.
    /// </summary>
    public readonly QuarantineStatus Status;
    /// <summary>
    /// This is of type DATE_TIME, containing the end time of the probation if the DHCPv4 client is on probation. For this time period, the DHCPv4 client has full access to the network.
    /// </summary>
    public readonly DateTime ProbationEnds;
    /// <summary>
    /// If TRUE, the DHCPv4 client is quarantine-enabled; if FALSE, it is not.
    /// </summary>
    public readonly bool QuarantineCapable;

    public DhcpClientInfoVqManaged(DhcpIpAddress clientIpAddress, DhcpIpMask subnetMask, DhcpBinaryDataManaged clientHardwareAddress, string clientName, string clientComment, DateTime clientLeaseExpires, DhcpHostInfoManaged ownerHost, DhcpClientType clientType, byte addressState, QuarantineStatus status, DateTime probationEnds, bool quarantineCapable)
    {
        ClientIpAddress = clientIpAddress;
        SubnetMask = subnetMask;
        ClientHardwareAddress = clientHardwareAddress;
        ClientName = clientName;
        ClientComment = clientComment;
        ClientLeaseExpires = clientLeaseExpires;
        OwnerHost = ownerHost;
        ClientType = clientType;
        AddressState = addressState;
        Status = status;
        ProbationEnds = probationEnds;
        QuarantineCapable = quarantineCapable;
    }

    public void Dispose()
    {
        ClientHardwareAddress.Dispose();
    }
}