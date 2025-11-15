// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
///  Console management service
/// </summary>
public interface IConsoleService
{
    /// <summary>
    /// Value for "window hide"
    /// </summary>
    public int ShowWindowHide { get; }

    /// <summary>
    /// Value for "show window"
    /// </summary>
    public int ShowWindowShow { get; }

    /// <summary>
    /// Handle of the console window
    /// </summary>
    IntPtr ConsoleHandle { get; set; }

    /// <summary>
    /// Set a certain window as forground window
    /// </summary>
    /// <param name="hWnd">Window handle</param>
    /// <returns>True if the window was set as foreground window else false</returns>
    bool CsSetForegroundWindow(IntPtr hWnd);

    /// <summary>
    /// Allocate console window
    /// </summary>
    /// <returns>True if the console indows was allocated else false</returns>
    bool CsAllocConsole();

    /// <summary>
    /// Get the handle of the console window
    /// </summary>
    /// <returns>Handle of the console window or null</returns>
    IntPtr CsGetConsoleWindow();

    /// <summary>
    /// Show a window
    /// </summary>
    /// <param name="hWnd">Window handle</param>
    /// <param name="nCmdShow">Requested show command</param>
    /// <returns>True if the windows was shown else false</returns>
    bool CsShowWindow(IntPtr hWnd, int nCmdShow);

    /// <summary>
    /// Free the console window
    /// </summary>
    /// <returns>True if the console window as freed</returns>
    bool CsFreeConsole();
}