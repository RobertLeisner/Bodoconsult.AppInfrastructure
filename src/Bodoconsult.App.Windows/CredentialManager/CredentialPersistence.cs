// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

namespace Bodoconsult.App.Windows.CredentialManager;

/// <summary>
/// Determines how long the credentials are persisted.
/// </summary>
public enum CredentialPersistence
{
    /// <summary>
    /// Persistence per session
    /// </summary>
    Session,
    /// <summary>
    /// Persistence on local machine
    /// </summary>
    LocalMachine,
    /// <summary>
    /// Persistence for an enterprise
    /// </summary>
    Enterprise
}