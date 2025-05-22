// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Collections.Generic;

namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerScopeReservationCollection : IEnumerable<IDhcpServerScopeReservation>
{
    IDhcpServerScope Scope { get; }
    IDhcpServer Server { get; }

    IDhcpServerScopeReservation AddReservation(IDhcpServerClient client);
    IDhcpServerScopeReservation AddReservation(DhcpServerIpAddress address, DhcpServerHardwareAddress hardwareAddress);
    IDhcpServerScopeReservation AddReservation(DhcpServerIpAddress address, DhcpServerHardwareAddress hardwareAddress, DhcpServerClientTypes allowedClientTypes);
}