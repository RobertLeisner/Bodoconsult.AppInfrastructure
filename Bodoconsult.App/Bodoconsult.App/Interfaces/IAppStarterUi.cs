// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

namespace Bodoconsult.App.Interfaces;

/// <summary>
/// Interface for UI based application starter classes
/// </summary>
public interface IAppStarterUi: IAppStarter
{

    /// <summary>
    /// Is already another instance started?
    /// </summary>
    bool IsAnotherInstance { get; }

    /// <summary>
    /// Wait while the application runs
    /// </summary>
    void Wait();

}