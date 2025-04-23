﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;
using Bodoconsult.App.Windows.Network.Dhcp.Native;

namespace Bodoconsult.App.Windows.Network.Dhcp;

public class DhcpServerConfiguration : IDhcpServerConfiguration
{
    public IDhcpServer Server { get; }

    /// <summary>
    /// Specifies a set of bit flags that contain the RPC protocols supported by the DHCP server.
    /// </summary>
    public DhcpServerApiProtocol ApiProtocolSupport { get; }

    /// <summary>
    /// Unicode string that specifies the file name of the client lease JET database.
    /// </summary>
    public string DatabaseName { get; }

    /// <summary>
    /// Unicode string that specifies the absolute path to DatabaseName.
    /// </summary>
    public string DatabasePath { get; }

    /// <summary>
    /// Unicode string that specifies the absolute path and file name of the backup client lease JET database.
    /// </summary>
    public string BackupPath { get; }

    /// <summary>
    /// Specifies the interval between backups of the client lease database.
    /// </summary>
    public TimeSpan BackupInterval { get; }

    /// <summary>
    /// Specifies a bit flag that indicates whether or not database actions should be logged.
    /// </summary>
    public bool DatabaseLoggingEnabled { get; }

    /// <summary>
    /// Specifies the interval between cleanup operations performed on the client lease database.
    /// </summary>
    public TimeSpan DatabaseCleanupInterval { get; }

    private DhcpServerConfiguration(DhcpServer server, DhcpServerApiProtocol apiProtocolSupport, string databaseName, string databasePath, string backupPath, TimeSpan backupInterval, bool databaseLoggingEnabled, TimeSpan databaseCleanupInterval)
    {
        Server = server;
        ApiProtocolSupport = apiProtocolSupport;
        DatabaseName = databaseName;
        DatabasePath = databasePath;
        BackupPath = backupPath;
        BackupInterval = backupInterval;
        DatabaseLoggingEnabled = databaseLoggingEnabled;
        DatabaseCleanupInterval = databaseCleanupInterval;
    }

    internal static DhcpServerConfiguration GetConfiguration(DhcpServer server)
    {
        var result = Api.DhcpServerGetConfig(serverIpAddress: server.Address,
            configInfo: out var configInfoPtr);

        if (result != DhcpErrors.Success)
            throw new DhcpServerException(nameof(Api.DhcpServerGetConfig), result);

        try
        {
            var configInfo = configInfoPtr.MarshalToStructure<DhcpServerConfigInfo>();
            return FromNative(server, in configInfo);
        }
        finally
        {
            Api.FreePointer(configInfoPtr);
        }
    }

    private static DhcpServerConfiguration FromNative(DhcpServer server, in DhcpServerConfigInfo native)
    {
        return new DhcpServerConfiguration(server,
            apiProtocolSupport: (DhcpServerApiProtocol)native.APIProtocolSupport,
            databaseName: native.DatabaseName,
            databasePath: native.DatabasePath,
            backupPath: native.BackupPath,
            backupInterval: TimeSpan.FromMinutes(native.BackupInterval),
            databaseLoggingEnabled: (native.DatabaseLoggingFlag & 0x1) == 0x1,
            databaseCleanupInterval: TimeSpan.FromMinutes(native.DatabaseCleanupInterval));
    }

    public override string ToString() => $"DHCP Configuration: {Server.Name} ({Server.Address})";
}