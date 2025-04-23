// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.General;

namespace Bodoconsult.App.Interfaces;

/// <summary>
/// Interface for general app features like database backup
/// </summary>
public interface IGeneralAppManagementService
{

    /// <summary>
    /// Create a dump file with all logs in ProgrammData\AppFolder
    /// </summary>
    void CreateLogDump();

    /// <summary>
    /// Create a normal mini dump of the app
    /// </summary>
    void CreateMiniDump();

    /// <summary>
    /// Create a mini dump of the app
    /// </summary>
    void CreateMiniDump(MiniDump.MiniDumpTypeEnum dumpType);
}