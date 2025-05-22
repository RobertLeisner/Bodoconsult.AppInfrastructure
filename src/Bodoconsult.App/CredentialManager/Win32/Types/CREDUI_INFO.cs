// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System.Runtime.InteropServices;

namespace Bodoconsult.App.CredentialManager.Win32.Types;

[StructLayout (LayoutKind.Sequential)]
internal struct CreduiInfo
{
    public int Size;
    public IntPtr ParentHandle;
    [MarshalAs (UnmanagedType.LPWStr)] public string MessageText;
    [MarshalAs (UnmanagedType.LPWStr)] public string CaptionText;
    private IntPtr Bitmap; // Ignored
}