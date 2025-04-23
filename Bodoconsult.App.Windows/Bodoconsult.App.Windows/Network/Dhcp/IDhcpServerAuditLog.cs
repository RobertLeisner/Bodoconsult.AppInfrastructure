// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.Windows.Network.Dhcp;

public interface IDhcpServerAuditLog
{
    string AuditLogDirectory { get; }
    int DiskCheckInterval { get; }
    int MaxLogFilesSize { get; }
    int MinSpaceOnDisk { get; }
    IDhcpServer Server { get; }
}