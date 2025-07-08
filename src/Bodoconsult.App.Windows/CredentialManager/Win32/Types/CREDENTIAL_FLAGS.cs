// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System;

namespace Bodoconsult.App.Windows.CredentialManager.Win32.Types;

[Flags]
internal enum CredentialFlags
{
    None = 0x0,
    PromptNow = 0x2,
    UsernameTarget = 0x4
}