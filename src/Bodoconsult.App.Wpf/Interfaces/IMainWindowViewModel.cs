// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Interfaces;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Bodoconsult.App.Wpf.Interfaces;

/// <summary>
/// Interface for view models for the main app window
/// </summary>
public interface IMainWindowViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// Inner width of the main window
    /// </summary>
    double Width { get; set; }

    /// <summary>
    /// Inner height of the main window
    /// </summary>
    double Height { get; set; }

    /// <summary>
    /// Inner height of the main window
    /// </summary>
    double HeaderHeight { get; }

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

    string MsgServerIsListeningOnPort { get; set; }

    string MsgServerProcessId { get; set; }

    /// <summary>
    /// Message to exit the app
    /// </summary>
    string MsgExit { get; set; }

    /// <summary>
    /// Clear text name of the app to show in windows and message boxes
    /// </summary>
    string AppName { get; set; }

    /// <summary>
    /// Current app version
    /// </summary>
    string AppVersion { get; set; }

    /// <summary>
    /// Clear text name of the app with version to show in windows and message boxes
    /// </summary>
    string FullAppName { get; set; }

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
    /// Load the logo
    /// </summary>
    /// <param name="assembly">Assembly to load the logo from</param>
    /// <param name="ressourcePath">Ressource path</param>
    void LoadLogo(Assembly assembly, string ressourcePath);

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
    public BitmapImage Logo { get; }

    /// <summary>
    /// Background color of the header line
    /// </summary>
    Color HeaderBackColor { get; set; }

    /// <summary>
    /// Create the main window of the application
    /// </summary>
    /// <returns></returns>
    Window CreateWindow();
}