// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace Bodoconsult.App.Windows.CredentialManager.Win32;

internal abstract class SecureBlob : SafeHandle
{
    /// <inheritdoc />
    public override bool IsInvalid => handle == IntPtr.Zero;

    /// <inheritdoc />
    protected SecureBlob()
        : base (IntPtr.Zero, true)
    {
    }

    public abstract int Size { get; }

    /// <inheritdoc />
    protected abstract override bool ReleaseHandle();
}