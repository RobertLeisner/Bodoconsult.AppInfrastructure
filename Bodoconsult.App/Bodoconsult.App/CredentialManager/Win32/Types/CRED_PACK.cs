// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

namespace Bodoconsult.App.CredentialManager.Win32.Types;

[Flags]
internal enum CredPack
{
    ProtectedCredentials = 0x1,
    WowBuffer = 0x2,
    GenericCredentials = 0x4,
    IdProviderCredentials = 0x8
}