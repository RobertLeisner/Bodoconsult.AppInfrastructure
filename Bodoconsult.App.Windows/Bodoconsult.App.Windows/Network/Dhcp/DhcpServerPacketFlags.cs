// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;

namespace Bodoconsult.App.Windows.Network.Dhcp;

[Flags]
public enum DhcpServerPacketFlags : ushort
{
    Broadcast = 0x8000
}