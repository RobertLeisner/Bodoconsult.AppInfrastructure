﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Windows.Network.Dhcp;

public enum DhcpServerFailoverServerType
{
    /// <summary>
    /// The server is a primary server in the failover relationship.
    /// </summary>
    PrimaryServer,
    /// <summary>
    /// The server is a secondary server in the failover relationship.
    /// </summary>
    SecondaryServer
}