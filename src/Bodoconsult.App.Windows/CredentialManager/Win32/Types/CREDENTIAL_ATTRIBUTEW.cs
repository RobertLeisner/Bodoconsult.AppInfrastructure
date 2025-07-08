// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.CredentialManager.Win32.Types;

[StructLayout (LayoutKind.Sequential)]
internal struct CredentialAttributew
{
    public IntPtr Keyword;
    public int Flags; // Unused
    public int ValueSize;
    public IntPtr Value;
}