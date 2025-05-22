// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerScopeReservation
{
    DhcpServerIpAddress Address { get; }
    DhcpServerClientTypes AllowedClientTypes { get; }
    IDhcpServerClient Client { get; }
    DhcpServerHardwareAddress HardwareAddress { get; }
    IDhcpServerScopeReservationOptionValueCollection Options { get; }
    IDhcpServerScope Scope { get; }
    IDhcpServer Server { get; }

    void Delete();
}