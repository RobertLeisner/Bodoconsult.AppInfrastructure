﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Windows.Network.Dhcp;

public enum DhcpServerFailoverMode
{
    /// <summary>
    /// The DHCPv4 server failover relationship is in Load Balancing mode.
    /// </summary>
    LoadBalance,
    /// <summary>
    /// The DHCPv4 server failover relationship is in Hot Standby mode.
    /// </summary>
    HotStandby
}