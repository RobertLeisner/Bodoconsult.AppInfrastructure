// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.CredentialManager.Win32.Types;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct Credentialw
{
    public CredentialFlags Flags;
    public CredentialType Type;
    [MarshalAs (UnmanagedType.LPWStr)] public string TargetName;
    [MarshalAs (UnmanagedType.LPWStr)] public string Comment;
    public global::System.Runtime.InteropServices.ComTypes.FILETIME LastWritten;
    public int BlobSize;
    public SecureBlob Blob;
    public CredentialPersist Persist;
    public int AttributeCount;
    public IntPtr Attributes;
    [MarshalAs (UnmanagedType.LPWStr)] public string TargetAlias;
    [MarshalAs (UnmanagedType.LPWStr)] public string UserName;
}