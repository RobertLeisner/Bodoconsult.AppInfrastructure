// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.Network.Dhcp.Native;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal readonly struct DhcpIpMask
{
    private readonly uint ipMask;

    public DhcpIpMask(uint ipMask)
    {
        this.ipMask = ipMask;
    }

    public override string ToString() => BitHelper.IpAddressToString(ipMask);

    public static explicit operator uint(DhcpIpMask ipMask) => ipMask.ipMask;
    public static explicit operator DhcpIpMask(uint ipMask) => new(ipMask);
    public static explicit operator int(DhcpIpMask ipMask) => (int)ipMask.ipMask;
    public static explicit operator DhcpIpMask(int ipMask) => new((uint)ipMask);

    public DhcpServerIpMask AsHostToIpMask() => new(BitHelper.HostToNetworkOrder(ipMask));

    public DhcpServerIpMask AsNetworkToIpMask() => new(ipMask);
}
