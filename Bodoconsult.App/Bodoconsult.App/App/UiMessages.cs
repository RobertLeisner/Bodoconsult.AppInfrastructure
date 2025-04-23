// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Exceptions;

namespace Bodoconsult.App;

/// <summary>
/// Messages for WinForms UI and console
/// </summary>
public static class UiMessages
{
    public static string MsgAppIsReady => "App is started and ready for processing workload!";

    public static string MsgHowToShutdownServer => "Press CTRL+C (STRG+C) to stop the app...";

    public static string Exit => "Do you want to stop the app?";

    public static string ExitForced => "Do you really want to stop the app?";

    public static string ExitHeader => "Stop the app";

    public static string MsgLicenseNotFoundTerminateTime => "License not found. Application will terminate in 5s";


    public static string MsgLicenseNotFoundNowTerminate => "License not found. Application will terminate!";

    /// <summary>
    /// Handles an exception an returns a string to use in UI
    /// </summary>
    /// <param name="e">Raised exception</param>
    /// <returns>String with information for the raised exception</returns>
    public static string HandleException(Exception e)
    {
        // RL: Check for licence exception here too: it may be the inner exception
        var ex = ContainsLicenseMissingException(e);
        if (ex != null)
        {
            return $"{MsgLicenseNotFoundTerminateTime}:{ex.Message}";
        }

        var msg =  "An error occurs when trying to start application server";

        return $"{msg} {e.InnerException ?? e}: {e.StackTrace}";
    }

    /// <summary>
    /// Check all inner exceptions for <see cref="LicenseMissingException"/>
    /// </summary>
    /// <param name="e">Current exception</param>
    /// <returns>A <see cref="LicenseMissingException"/> contained in the exception</returns>
    public static LicenseMissingException ContainsLicenseMissingException(Exception e)
    {
        while (true)
        {
            if (e == null)
            {
                return null;
            }

            if (e is LicenseMissingException ex)
            {
                return ex;
            }

            e = e.InnerException;
        }
    }
}