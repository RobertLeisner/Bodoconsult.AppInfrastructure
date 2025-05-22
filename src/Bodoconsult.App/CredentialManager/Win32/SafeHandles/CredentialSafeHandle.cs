// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System.Runtime.InteropServices;
using Bodoconsult.App.CredentialManager.Win32.Types;

namespace Bodoconsult.App.CredentialManager.Win32.SafeHandles;

using static UnsafeNativeApi;

internal unsafe class CredentialSafeHandle : SafeHandle
{
    /// <inheritdoc />
    public override bool IsInvalid => handle == IntPtr.Zero;

    public CredentialSafeHandle()
        : this (true)
    {
    }

    /// <inheritdoc />
    public CredentialSafeHandle (bool ownsHandle)
        : base (IntPtr.Zero, ownsHandle)
    {
    }

    public CredentialwRaw* AsCredentialW()
    {
        if (handle == IntPtr.Zero)
        {
            throw new InvalidOperationException ("The handle is null.");
        }

        return (CredentialwRaw*) handle;
    }

    /// <inheritdoc />
    protected override bool ReleaseHandle()
    {
        CredFree ((CredentialwRaw*) handle);
        return true;
    }
}