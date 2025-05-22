// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;

namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerBindingElement
{
    DhcpServerIpAddress AdapterPrimaryIpAddress { get; }
    DhcpServerIpMask AdapterSubnetAddress { get; }
    bool CantModify { get; }
    string InterfaceDescription { get; }
    Guid InterfaceGuidId { get; }
    byte[] InterfaceId { get; }
    bool IsBound { get; }
    IDhcpServer Server { get; }
}