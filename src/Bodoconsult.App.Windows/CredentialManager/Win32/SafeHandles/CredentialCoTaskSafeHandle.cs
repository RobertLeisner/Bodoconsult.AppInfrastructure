// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using Bodoconsult.App.Windows.CredentialManager.Win32.Types;

namespace Bodoconsult.App.Windows.CredentialManager.Win32.SafeHandles;

using static UnsafeNativeApi;

/// <summary>
/// 
/// </summary>
public class CredentialCoTaskSafeHandle : SafeHandle
{
    /// <inheritdoc />
    public override bool IsInvalid => handle == IntPtr.Zero;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CredentialCoTaskSafeHandle()
        : this (true)
    { }

    /// <summary>
    /// Ctor for setting handle ownership
    /// </summary>
    /// <param name="ownsHandle">Owns handle</param>
    public CredentialCoTaskSafeHandle (bool ownsHandle)
        : base (IntPtr.Zero, ownsHandle)
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public byte[] ToArray (uint count)
    {
        if (IsInvalid)
        {
            throw new InvalidOperationException ("Handle is null.");
        }

        if (count == 0)
        {
            return [];
        }

        var result = new byte[count];
        Marshal.Copy (handle, result, 0, result.Length);

        return result;
    }

    /// <summary>
    /// Get the prompt results
    /// </summary>
    /// <param name="size">Size</param>
    /// <param name="domain">Domain name</param>
    /// <param name="username">Username</param>
    /// <param name="password">Password</param>
    /// <exception cref="Win32Exception">If unpacking credential buffer fails</exception>
    public unsafe void GetPromptDetails (uint size, out string domain, out string username, out SecureString password)
    {
        var domainPtr = IntPtr.Zero;
        var usernamePtr = IntPtr.Zero;
        var passwordPtr = IntPtr.Zero;
        var passwordCapacity = byte.MaxValue;
        try
        {
            int domainLength = byte.MaxValue;
            domainPtr = Marshal.AllocHGlobal (domainLength);

            int usernameLength = byte.MaxValue;
            usernamePtr = Marshal.AllocHGlobal (usernameLength);

            int passwordLength = passwordCapacity;
            passwordPtr = Marshal.AllocHGlobal (passwordLength);

            if (!CredUnPackAuthenticationBufferW (
                    CredPack.ProtectedCredentials,
                    this,
                    size,
                    usernamePtr,
                    ref usernameLength,
                    domainPtr,
                    ref domainLength,
                    passwordPtr,
                    ref passwordLength))
            {
                throw new Win32Exception();
            }

            domain = Marshal.PtrToStringUni (domainPtr, domainLength > 0 ? domainLength - 1 : 0);
            username = Marshal.PtrToStringUni (usernamePtr, usernameLength > 0 ? usernameLength - 1 : 0);
            password = new SecureString ((char*) passwordPtr, passwordLength > 0 ? passwordLength - 1 : 0);
        }
        finally
        {
            Marshal.FreeHGlobal (domainPtr);
            Marshal.FreeHGlobal (usernamePtr);

            var ptr = (byte*) passwordPtr;
            for (var i = 0; i < passwordCapacity; i++)
                ptr[i] = 0;

            Marshal.FreeHGlobal (passwordPtr);
        }
    }


    /// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
    /// <returns>
    /// <see langword="true" /> if the handle is released successfully; otherwise, in the event of a catastrophic failure, <see langword="false" />. In this case, it generates a releaseHandleFailed Managed Debugging Assistant.</returns>
    protected override bool ReleaseHandle()
    {
        Marshal.ZeroFreeCoTaskMemUnicode (handle);
        return true;
    }
}