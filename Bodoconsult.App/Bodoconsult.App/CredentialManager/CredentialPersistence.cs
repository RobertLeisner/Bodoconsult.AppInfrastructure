// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

namespace Bodoconsult.App.CredentialManager;

/// <summary>
/// Determines how long the credentials are persisted.
/// </summary>
public enum CredentialPersistence
{
    Session,
    LocalMachine,
    Enterprise
}