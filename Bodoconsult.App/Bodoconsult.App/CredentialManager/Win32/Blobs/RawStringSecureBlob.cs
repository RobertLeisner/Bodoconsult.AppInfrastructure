// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System.Runtime.InteropServices;
using System.Security;

namespace Bodoconsult.App.CredentialManager.Win32.Blobs;

internal class RawStringSecureBlob : SecureBlob
{
    public RawStringSecureBlob (SecureString password)
    {
        handle = Marshal.SecureStringToGlobalAllocUnicode (password);
    }

    /// <inheritdoc />
    public override unsafe int Size => Win32Utility.GetUniStringLengthWithoutTerminator (handle);

    /// <inheritdoc />
    protected override bool ReleaseHandle()
    {
        Marshal.ZeroFreeGlobalAllocUnicode (handle);
        handle = IntPtr.Zero;

        return true;
    }
}