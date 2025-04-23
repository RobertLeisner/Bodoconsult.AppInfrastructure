﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerDnsSettings
{
    bool DisableDynamicPtrRecordUpdates { get; }
    bool DiscardRecordsWhenLeasesDeleted { get; }
    bool DynamicDnsUpdatedAlways { get; }
    bool DynamicDnsUpdatedOnlyWhenRequested { get; }
    bool DynamicDnsUpdatesEnabled { get; }
    bool UpdateRecordsForDownLevelClients { get; }
}