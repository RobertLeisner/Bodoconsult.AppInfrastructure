﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.AppStarter;
using Bodoconsult.App.Logging;
using Bodoconsult.App.Wpf.AppStarter.Forms.ViewModel;
using Bodoconsult.App.Wpf.Interfaces;
using System.Diagnostics.Tracing;
using System.Windows;

// ReSharper disable LocalizableElement

namespace Bodoconsult.App.Wpf.AppStarter;

/// <summary>
/// Implementation of <see cref="IAppStarterUi"/> for WinForms app
/// </summary>
public class WpfStarterUi : BaseAppStarterUi
{
    private readonly AppEventListener _listener;

    private IMainWindowViewModel _viewModel;

    public WpfStarterUi(IAppBuilder appBuilder) : base(appBuilder)
    {
        //var minimumLogLevel = Globals.GetLoggingConfiguration().MinimumLogLevel;

        //MinimumLogLevel = LogLevel.Debug;

        //var eventLevel = MapLogLevelToEventLevel(minimumLogLevel);

        var eventLevel = EventLevel.Warning;

        _listener = new AppEventListener(eventLevel);

    }

    /// <summary>
    /// Ctor for using a customized form as main form of the application. The <see cref="IMainWindowViewModel"/> implementation based on <see cref="MainWindowViewModel"/> has to override CreateForm() method
    /// </summary>
    public WpfStarterUi(IAppBuilder appBuilder, IMainWindowViewModel viewModel) : base(appBuilder)
    {
        //var minimumLogLevel = Globals.GetLoggingConfiguration().MinimumLogLevel;

        //MinimumLogLevel = LogLevel.Debug;

        //var eventLevel = MapLogLevelToEventLevel(minimumLogLevel);

        var eventLevel = EventLevel.Warning;

        _listener = new AppEventListener(eventLevel);

        _viewModel = viewModel;

    }

    ///// <summary>
    ///// Map the log level to EventSource event level
    ///// </summary>
    ///// <param name="logLevel">Log level</param>
    ///// <returns>Event level for EventSource</returns>
    //private static EventLevel MapLogLevelToEventLevel(LogLevel logLevel)
    //{
    //    switch (logLevel)
    //    {
    //        case LogLevel.Trace:
    //            return EventLevel.LogAlways;
    //        case LogLevel.Debug:
    //            return EventLevel.Verbose;
    //        case LogLevel.Information:
    //            return EventLevel.Informational;
    //        case LogLevel.Warning:
    //            return EventLevel.Warning;
    //        case LogLevel.Error:
    //            return EventLevel.Error;
    //        case LogLevel.Critical:
    //            return EventLevel.Critical;
    //        case LogLevel.None:
    //            return EventLevel.Error;
    //        default:
    //            throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
    //    }
    //}


    /// <summary>
    /// Wait while the application runs
    /// </summary>
    public override void Wait()
    {

        ConsoleHandle = GetConsoleWindow();
        ShowWindow(ConsoleHandle, ShowWindowHide);

        _viewModel ??= new MainWindowViewModel(_listener);
        _viewModel.LoadAppBuilder( AppBuilder);
        _viewModel.AppVersion = AppBuilder.AppGlobals.AppStartParameter.AppVersion;

        var window = _viewModel.CreateWindow();

        Application.Current.MainWindow = window ;

        window.Show();
    }

    public override void TerminateAppWithMessage(string message, string appTitle)
    {
        MessageBox.Show(message, appTitle);

        _viewModel.ShutDown();

        Environment.Exit(0);
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
            MessageBox.Show(msg, AppBuilder.AppGlobals.AppStartParameter.AppName);
        }
        catch (Exception exception)
        {
            MessageBox.Show($"{exception.Message} {exception.StackTrace}", AppBuilder.AppGlobals.AppStartParameter.AppName);
        }

        _viewModel?.ShutDown();
        Environment.Exit(0);
    }


    /// <summary>
    /// Current implementation of Dispose()
    /// </summary>
    /// <param name="disposing">Disposing required: true or false</param>
    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        try
        {
            _listener.Dispose();
        }
        catch //(Exception e)
        {
            // Do nothing
        }
    }
}