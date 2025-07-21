// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.ComponentModel;
using System.Diagnostics.Tracing;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.WinForms.AppStarter.Forms;

namespace Bodoconsult.App.WinForms.Interfaces;

public interface IMainWindowViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// Current app builder
    /// </summary>
    IAppBuilder AppBuilder { get; }

    /// <summary>
    /// Message shown during console is waiting
    /// </summary>
    string MsgConsoleWait { get; set; }

    /// <summary>
    /// Message "how to shutdown server app"
    /// </summary>
    string MsgHowToShutdownServer { get; set; }

    /// <summary>
    /// Message to exit the app
    /// </summary>
    string MsgExit { get; set; }

    /// <summary>
    /// Current app version
    /// </summary>
    string AppVersion { get; set; }

    /// <summary>
    /// Current application context
    /// </summary>
    TaskTrayApplicationContext ApplicationContext { get; set; }

    /// <summary>
    /// Log data as string to show on UI
    /// </summary>
    string LogData { get; }

    /// <summary>
    /// Event level
    /// </summary>
    EventLevel LogEventLevel { get; set; }


    /// <summary>
    /// Load the current <see cref="IAppBuilder"/> instance to use
    /// </summary>
    /// <param name="appBuilder">Current <see cref="IAppBuilder"/> instance to use</param>
    void LoadAppBuilder(IAppBuilder appBuilder);


    /// <summary>
    /// Shutdown for app
    /// </summary>
    void ShutDown();

    /// <summary>
    /// Check if there are new log entries
    /// </summary>
    void CheckLogs();

    /// <summary>
    /// The logo to use for the user interface
    /// </summary>
    public Bitmap Logo { get; }

    /// <summary>
    /// Background color of the header line
    /// </summary>
    Color HeaderBackColor { get; set; }

    /// <summary>
    /// Create the main form of the application
    /// </summary>
    /// <returns></returns>
    Form CreateForm();
}