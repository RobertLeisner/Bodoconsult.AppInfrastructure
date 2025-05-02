﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using System.Diagnostics;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.AppStarter;

/// <summary>
/// Implementation of <see cref="IAppStarterUi"/> for console app
/// </summary>
public class ConsoleAppStarterUi : BaseAppStarterUi
{

    private CancellationTokenSource _cancellationTokenSource;

    /// <summary>
    /// Message shown during console is waiting
    /// </summary>
    public string MsgConsoleWait { get; set; }

    /// <summary>
    /// Message "how to shitdon server app"
    /// </summary>
    public string MsgHowToShutdownServer { get; set; }

    /// <summary>
    /// Default ctor
    /// </summary>
    public ConsoleAppStarterUi(IAppBuilder appStarterProcessHandler): base(appStarterProcessHandler)
    {
        // App is a WinForms app, therefore the console is normally hidden.
        // We access the hidden console here and make it visible 
        AllocConsole();

        ConsoleHandle = GetConsoleWindow();
        ShowWindow(ConsoleHandle, ShowWindowShow);
    }


    /// <summary>
    /// Wait while the application runs
    /// </summary>
    public override void Wait()
    {
        try
        {
            var msg = MsgConsoleWait;

            AppBuilder.AppGlobals.Logger.LogInformation(msg);
            Debug.Print(msg);
            Debug.Print(MsgHowToShutdownServer);

            _cancellationTokenSource = new CancellationTokenSource();

            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                AsyncHelper.Delay(1000);
            }
        }
        catch (Exception e)
        {
            HandleException(e);
        }
    }


    /// <summary>
    /// Show a message and then terminate the app
    /// </summary>
    /// <param name="message">Message to show before app termination</param>
    /// <param name="appTitle">App title to set</param>
    public override void TerminateAppWithMessage(string message, string appTitle)
    {
        _cancellationTokenSource.Cancel();

        Debug.Print(message);
        Console.WriteLine(message);
        AsyncHelper.Delay(5000);

    }

    /// <summary>
    /// Central handling for exceptions
    /// </summary>
    /// <param name="e"></param>
    public override void HandleException(Exception e)
    {
        if (e == null)
        {
            return;
        }

        try
        {
            var msg = UiMessages.HandleException(e);

            // ToDo: correct handling of line breaks
            Debug.Print(msg);
        }
        catch (Exception exception)
        {
            Debug.Print(exception.Message);
        }

        AsyncHelper.Delay(5000);
        Environment.Exit(0);
    }
}