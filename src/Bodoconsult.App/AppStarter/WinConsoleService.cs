// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Bodoconsult.App.Abstractions.Interfaces;

namespace Bodoconsult.App.AppStarter;

/// <summary>
/// Implementation of <see cref="IConsoleService"/> for Windows OS
/// </summary>
[SupportedOSPlatform("windows")]
public class WinConsoleService: IConsoleService
{
    /// <summary>
    /// Handle of the console window
    /// </summary>
    public IntPtr ConsoleHandle { get; set; }

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AllocConsole();

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool FreeConsole();

    /// <summary>
    /// Value for "window hide"
    /// </summary>
    public int ShowWindowHide => 0;

    /// <summary>
    /// Value for "show window"
    /// </summary>
    public int ShowWindowShow => 5;

    /// <summary>
    /// Set a certain window as forground window
    /// </summary>
    /// <param name="hWnd">Window handle</param>
    /// <returns>True if the window was set as foreground window else false</returns>
    public bool CsSetForegroundWindow(IntPtr hWnd)
    {
        return SetForegroundWindow(hWnd);
    }

    /// <summary>
    /// Allocate console window
    /// </summary>
    /// <returns>True if the console indows was allocated else false</returns>
    public bool CsAllocConsole()
    {
        return AllocConsole();
    }

    /// <summary>
    /// Get the handle of the console window
    /// </summary>
    /// <returns>Handle of the console window or null</returns>
    public IntPtr CsGetConsoleWindow()
    {
        return GetConsoleWindow();
    }

    /// <summary>
    /// Show a window
    /// </summary>
    /// <param name="hWnd">Window handle</param>
    /// <param name="nCmdShow">Requested show command</param>
    /// <returns>True if the windows was shown else false</returns>
    public bool CsShowWindow(IntPtr hWnd, int nCmdShow)
    {
        return ShowWindow(hWnd, nCmdShow);
    }

    /// <summary>
    /// Free the console window
    /// </summary>
    /// <returns>True if the console window as freed</returns>
    public bool CsFreeConsole()
    {
        return FreeConsole();
    }
}