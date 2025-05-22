// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

namespace Bodoconsult.App.CredentialManager.Win32.Types;

[Flags]
internal enum CredentialFlags
{
    None = 0x0,
    PromptNow = 0x2,
    UsernameTarget = 0x4
}