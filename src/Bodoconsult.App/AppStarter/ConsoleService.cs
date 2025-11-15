// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.AppStarter;

public class ConsoleService : IConsoleService
{
    /// <summary>
    /// Value for "window hide"
    /// </summary>
    public int ShowWindowHide => 0;

    /// <summary>
    /// Value for "show window"
    /// </summary>
    public int ShowWindowShow => 5;

    /// <summary>
    /// Handle of the console window
    /// </summary>
    public IntPtr ConsoleHandle { get; set; }

    /// <summary>
    /// Set a certain window as forground window
    /// </summary>
    /// <param name="hWnd">Window handle</param>
    /// <returns>True if the window was set as foreground window else false</returns>
    public bool CsSetForegroundWindow(IntPtr hWnd)
    {
        // Do nothing
        return true;
    }

    /// <summary>
    /// Allocate console window
    /// </summary>
    /// <returns>True if the console indows was allocated else false</returns>
    public bool CsAllocConsole()
    {
        // Do nothing
        return true;
    }

    /// <summary>
    /// Get the handle of the console window
    /// </summary>
    /// <returns>Handle of the console window or 0-pointer</returns>
    public IntPtr CsGetConsoleWindow()
    {
        // Do nothing
        return new IntPtr(0);
    }

    /// <summary>
    /// Show a window
    /// </summary>
    /// <param name="hWnd">Window handle</param>
    /// <param name="nCmdShow">Requested show command</param>
    /// <returns>True if the windows was shown else false</returns>
    public bool CsShowWindow(IntPtr hWnd, int nCmdShow)
    {
        // Do nothing
        return true;
    }

    /// <summary>
    /// Free the console window
    /// </summary>
    /// <returns>True if the console window as freed</returns>
    public bool CsFreeConsole()
    {
        // Do nothing
        return true;
    }
}