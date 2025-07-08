// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System;

namespace Bodoconsult.App.Windows.CredentialManager.Win32.Types;

[Flags]
internal enum CreduiWindow
{
    Generic = 0x1,
    Checkbox = 0x2,
    AuthPackageOnly = 0x10,
    InCredOnly = 0x20,
    EnumerateAdmins = 0x100,
    EnumerateCurrentUser = 0x200,
    SecurePrompt = 0x1000,
    PrePrompting = 0x2000
}