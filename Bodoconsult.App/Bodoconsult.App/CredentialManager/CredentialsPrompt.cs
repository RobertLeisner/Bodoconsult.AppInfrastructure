// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

// Copyright (c) 2020 Widauer Patrick. All rights reserved.

using System.ComponentModel;
using Bodoconsult.App.CredentialManager.Win32.SafeHandles;
using Bodoconsult.App.CredentialManager.Win32.Types;

namespace Bodoconsult.App.CredentialManager;

using static Win32.UnsafeNativeApi;

public class CredentialsPrompt
{
    private const int CCancelledErrorCode = 1223;

    public static CredentialsPromptResult Show (string text, string caption)
    {
        return Show (text, caption, IntPtr.Zero);
    }

    public static CredentialsPromptResult Show (string text, string caption, IntPtr parentHandle)
    {
        return ShowInternal (text, caption, parentHandle, false, false);
    }

    public static CredentialsPromptResult ShowWithSaveButton (string text, string caption)
    {
        return ShowWithSaveButton (text, caption, false, IntPtr.Zero);
    }

    public static CredentialsPromptResult ShowWithSaveButton (string text, string caption, bool saveDefault)
    {
        return ShowWithSaveButton (text, caption, saveDefault, IntPtr.Zero);
    }

    public static CredentialsPromptResult ShowWithSaveButton (string text, string caption, bool saveDefault, IntPtr parentHandle)
    {
        return ShowInternal (text, caption, parentHandle, true, saveDefault);
    }

    private static CredentialsPromptResult ShowInternal (string text, string caption, IntPtr parentHandle, bool showSave, bool saveDefault)
    {
        CreduiInfo credUiInfo = default;
        credUiInfo.Size = 5 * IntPtr.Size;
        credUiInfo.ParentHandle = parentHandle;
        credUiInfo.MessageText = text;
        credUiInfo.CaptionText = caption;

        uint inAuth = 0;

        CredentialCoTaskSafeHandle outputBuffer = null;
        try
        {
            var windowType = CreduiWindow.Generic;
            if (showSave)
                windowType |= CreduiWindow.Checkbox;

            var save = saveDefault;
            var errorCode = CredUIPromptForWindowsCredentialsW (
                ref credUiInfo,
                0,
                ref inAuth,
                null,
                0,
                out outputBuffer,
                out var outputBufferSize,
                ref save,
                windowType);

            if (errorCode == CCancelledErrorCode)
                return CredentialsPromptResult.CancelledResult;

            if (errorCode != 0)
                throw new Win32Exception (errorCode);

            outputBuffer.GetPromptDetails (
                outputBufferSize,
                out var domain,
                out var username,
                out var password);

            return new CredentialsPromptResult (
                false,
                domain,
                username,
                password,
                save);
        }
        finally
        {
            outputBuffer?.Dispose();
        }
    }
}