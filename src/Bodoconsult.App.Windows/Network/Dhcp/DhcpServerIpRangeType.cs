﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Windows.Network.Dhcp;

public enum DhcpServerIpRangeType
{
    Reserved = 2,
    Excluded = 3,
    ScopeDhcpOnly = 5,
    ScopeDhcpAndBootp = 6,
    ScopeBootpOnly = 7,
}