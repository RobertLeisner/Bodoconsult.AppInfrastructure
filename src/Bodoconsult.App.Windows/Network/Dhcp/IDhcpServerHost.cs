// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerHost
{
    DhcpServerIpAddress Address { get; }
    string NetBiosName { get; }
    string ServerName { get; }
}