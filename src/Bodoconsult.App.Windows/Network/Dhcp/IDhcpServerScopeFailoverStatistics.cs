﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerScopeFailoverStatistics
{
    int AddressesFree { get; }
    int AddressesInUse { get; }
    int AddressesTotal { get; }
    int LocalAddressesFree { get; }
    int LocalAddressesInUse { get; }
    int PartnerAddressesFree { get; }
    int PartnerAddressesInUse { get; }
    IDhcpServerScope Scope { get; }
    IDhcpServer Server { get; }
}