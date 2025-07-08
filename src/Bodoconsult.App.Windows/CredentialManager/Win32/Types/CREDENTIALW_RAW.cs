// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.CredentialManager.Win32.Types;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal readonly struct CredentialwRaw
{
    public readonly CredentialFlags Flags;
    public readonly CredentialType Type;
    public readonly IntPtr TargetName;
    public readonly IntPtr Comment;
    public readonly global::System.Runtime.InteropServices.ComTypes.FILETIME LastWritten;
    public readonly int BlobSize;
    public readonly IntPtr Blob;
    public readonly CredentialPersist Persist;
    public readonly int AttributeCount;
    public readonly IntPtr Attributes;
    public readonly IntPtr TargetAlias;
    public readonly IntPtr UserName;
}