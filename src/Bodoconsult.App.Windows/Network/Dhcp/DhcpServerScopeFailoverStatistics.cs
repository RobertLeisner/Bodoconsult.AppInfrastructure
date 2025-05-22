﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Windows.Network.Dhcp.Native;

namespace Bodoconsult.App.Windows.Network.Dhcp;

public class DhcpServerScopeFailoverStatistics : IDhcpServerScopeFailoverStatistics
{
    public IDhcpServer Server { get; }

    public IDhcpServerScope Scope { get; }

    /// <summary>
    /// The total number of IPv4 addresses that can be leased out to DHCPv4 clients on an IPv4 subnet that is part of a failover relationship.
    /// </summary>
    public int AddressesTotal { get; }

    /// <summary>
    /// The total number of IPv4 addresses that are free and can be leased to DHCPv4 clients on an IPv4 subnet that is part of a failover relationship.
    /// </summary>
    public int AddressesFree { get; }

    /// <summary>
    /// The total number of IPv4 addresses leased to DHCPv4 clients on an IPv4 subnet that is part of a failover relationship.
    /// </summary>
    public int AddressesInUse { get; }

    /// <summary>
    /// The total number of IPv4 addresses that are free and can be leased to DHCPv4 clients on an IPv4 subnet that is part of a failover relationship on the partner server.
    /// </summary>
    public int PartnerAddressesFree { get; }

    /// <summary>
    /// The total number of IPv4 addresses that are free and can be leased to DHCPv4 clients on an IPv4 subnet that is part of a failover relationship on the local DHCP server.
    /// </summary>
    public int LocalAddressesFree { get; }

    /// <summary>
    /// The total number of IPv4 addresses leased to DHCPv4 clients on an IPv4 subnet that is part of a failover relationship on the partner server.
    /// </summary>
    public int PartnerAddressesInUse { get; }

    /// <summary>
    /// The total number of IPv4 addresses leased to DHCPv4 clients on an IPv4 subnet that is part of a failover relationship on the local DHCP server.
    /// </summary>
    public int LocalAddressesInUse { get; }

    private DhcpServerScopeFailoverStatistics(DhcpServer server, DhcpServerScope scope, int addressesTotal, int addressesFree, int addressesInUse, int partnerAddressesFree, int localAddressesFree, int partnerAddressInUse, int localAddressesInUse)
    {
        Server = server;
        Scope = scope;
        AddressesTotal = addressesTotal;
        AddressesFree = addressesFree;
        AddressesInUse = addressesInUse;
        PartnerAddressesFree = partnerAddressesFree;
        LocalAddressesFree = localAddressesFree;
        PartnerAddressesInUse = partnerAddressInUse;
        LocalAddressesInUse = localAddressesInUse;
    }

    internal static DhcpServerScopeFailoverStatistics GetScopeFailoverStatistics(DhcpServer server, DhcpServerScope scope)
    {
        var result = Api.DhcpV4FailoverGetScopeStatistics(serverIpAddress: server.Address,
            scopeId: scope.Address.ToNativeAsNetwork(),
            stats: out var statisticsPtr);

        if (result == DhcpErrors.FoScopeNotInRelationship)
            return null;

        if (result != DhcpErrors.Success)
            throw new DhcpServerException(nameof(Api.DhcpV4FailoverGetScopeStatistics), result);

        try
        {
            var statistics = statisticsPtr.MarshalToStructure<DhcpFailoverStatistics>();

            return FromNative(server, scope, in statistics);
        }
        finally
        {
            Api.FreePointer(statisticsPtr);
        }

    }

    private static DhcpServerScopeFailoverStatistics FromNative(DhcpServer server, DhcpServerScope scope, in DhcpFailoverStatistics native)
        => new(server, scope, native.NumAddr, native.AddrFree, native.AddrInUse, native.PartnerAddrFree, native.ThisAddrFree, native.PartnerAddrInUse, native.ThisAddrInUse);

}