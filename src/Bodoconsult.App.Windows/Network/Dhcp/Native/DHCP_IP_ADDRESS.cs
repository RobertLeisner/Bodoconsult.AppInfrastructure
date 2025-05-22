// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal readonly struct DhcpIpAddress
{
    private readonly uint ipAddress;

    public DhcpIpAddress(uint ipAddress)
    {
        this.ipAddress = ipAddress;
    }

    public static DhcpIpAddress FromString(string ipAddress) => new(BitHelper.StringToIpAddress(ipAddress));
    public override string ToString() => BitHelper.IpAddressToString(ipAddress);

    public DhcpServerIpAddress AsHostToIpAddress() => new(BitHelper.HostToNetworkOrder(ipAddress));
    public DhcpServerIpAddress AsNetworkToIpAddress() => new(ipAddress);

    public static explicit operator DhcpIpAddress(int ipAddress) => new((uint)ipAddress);
    public static explicit operator int(DhcpIpAddress ipAddress) => (int)ipAddress.ipAddress;

    public static DhcpIpAddress operator &(DhcpIpAddress address, DhcpIpMask mask)
        => (DhcpIpAddress)((int)address & (int)mask);
}
