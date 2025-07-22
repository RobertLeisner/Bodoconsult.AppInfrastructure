// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Logging;
using Bodoconsult.App.Wpf.Interfaces;

namespace Bodoconsult.App.Wpf.AppStarter.Forms.ViewModel;

/// <summary>
/// ViewModel for MainWindow window
/// </summary>
public class MainWindowViewModel : IMainWindowViewModel
{

    private const int MaxNumberOfLogEntries = 100;

    private readonly AppEventListener _listener;

    private readonly List<string> _logData = new();

    private EventLevel _logEventLevel;
    private double _width = 100;
    private double _height = 100;
    private IAppBuilder _appBuilder;
    private string _msgConsoleWait;
    private string _msgHowToShutdownServer;
    private string _msgExit = "Exit the app?";
    private BitmapImage _logo;
    private Color _headerBackColor = Colors.Coral;
    private string _msgServerIsListeningOnPort;
    private string _msgServerProcessId;

    /// <summary>
    /// Inner width of the main window
    /// </summary>
    public double Width
    {
        get => _width;
        set
        {
            _width = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Inner height of the main window
    /// </summary>
    public double Height
    {
        get => _height;
        set
        {
            _height = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HeaderHeight));
        }
    }

    /// <summary>
    /// Inner height of the main window
    /// </summary>
    public double HeaderHeight => _height * 0.20;


    /// <summary>
    /// Current app start process handler
    /// </summary>
    public IAppBuilder AppBuilder
    {
        get => _appBuilder;
        private set
        {
            _appBuilder = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="listener">Current EventSource listener: neede to bring logging entries to UI</param>
    public MainWindowViewModel(AppEventListener listener)
    {
        _listener = listener;
    }


    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Message shown during console is waiting
    /// </summary>
    public string MsgConsoleWait
    {
        get => _msgConsoleWait;
        set
        {
            _msgConsoleWait = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Message "how to shitdon server app"
    /// </summary>
    public string MsgHowToShutdownServer
    {
        get => _msgHowToShutdownServer;
        set
        {
            _msgHowToShutdownServer = value;
            OnPropertyChanged();
        }
    }

    public string MsgServerIsListeningOnPort
    {
        get => _msgServerIsListeningOnPort;
        set
        {
            if (value == _msgServerIsListeningOnPort)
            {
                return;
            }
            _msgServerIsListeningOnPort = value;
            OnPropertyChanged();
        }
    }

    public string MsgServerProcessId
    {
        get => _msgServerProcessId;
        set
        {
            if (value == _msgServerProcessId)
            {
                return;
            }
            _msgServerProcessId = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Message to exit the app
    /// </summary>
    public string MsgExit
    {
        get => _msgExit;
        set
        {
            _msgExit = value;
            OnPropertyChanged();
        }
    }


    /// <summary>
    /// Clear text name of the app to show in windows and message boxes
    /// </summary>
    public string AppName
    {
        get => AppBuilder.AppGlobals.AppStartParameter.AppName;
        set
        {
            if (value == AppBuilder.AppGlobals.AppStartParameter.AppName)
            {
                return;
            }
            //_appVersion = value;
            OnPropertyChanged();
        }
    }


    /// <summary>
    /// Clear text name of the app with version to show in windows and message boxes
    /// </summary>
    public string FullAppName
    {
        get =>
            $"{AppBuilder.AppGlobals.AppStartParameter.AppName} {AppBuilder.AppGlobals.AppStartParameter.AppVersion}";
        set
        {
            //if (value == AppBuilder.AppGlobals.AppStartParameter.AppName)
            //{
            //    return;
            //}
            ////_appVersion = value;
            //OnPropertyChanged();
        }
    }


    /// <summary>
    /// Current app version
    /// </summary>
    public string AppVersion
    {
        get => AppBuilder.AppGlobals.AppStartParameter.AppVersion;
        set
        {
            if (value == AppBuilder.AppGlobals.AppStartParameter.AppVersion)
            {
                return;
            }
            //_appVersion = value;
            OnPropertyChanged();
        }
    }

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    /// <summary>
    /// Load the current <see cref="IAppBuilder"/> instance to use
    /// </summary>
    /// <param name="appBuilder">Current <see cref="IAppBuilder"/> instance to use</param>
    public void LoadAppBuilder(IAppBuilder appBuilder)
    {
        AppBuilder = appBuilder;

        MsgServerIsListeningOnPort = AppBuilder.AppGlobals.AppStartParameter.Port == 0 ? "" : $"{UiMessages.MsgServerIsListeningOnPort} {AppBuilder.AppGlobals.AppStartParameter.Port}";
        MsgHowToShutdownServer = UiMessages.MsgHowToShutdownServer;
        MsgServerProcessId = $"{UiMessages.MsgServerProcessId} {Process.GetCurrentProcess().Id}";
    }

    /// <summary>
    /// Load the logo
    /// </summary>
    /// <param name="assembly">Assembly to load the logo from</param>
    /// <param name="ressourcePath">Ressource path</param>
    public void LoadLogo(Assembly assembly, string ressourcePath)
    {
        //try
        //{

        if (assembly == null)
        {
            return;
        }

        var logoStream = assembly.GetManifestResourceStream(ressourcePath);

        if (logoStream == null)
        {
            return;
        }

        logoStream.Position = 0;

        Logo = new BitmapImage();

        // BitmapImage.UriSource must be in a BeginInit/EndInit block
        Logo.BeginInit();
        Logo.CacheOption = BitmapCacheOption.OnLoad;
        Logo.StreamSource = logoStream;

        // To save significant application memory, set the DecodePixelWidth or
        // DecodePixelHeight of the BitmapImage value of the image source to the desired
        // height or width of the rendered image. If you don't do this, the application will
        // cache the image as though it were rendered as its normal size rather than just
        // the size that is displayed.
        // Note: In order to preserve aspect ratio, set DecodePixelWidth
        // or DecodePixelHeight but not both.
        Logo.DecodePixelHeight = 300;
        Logo.EndInit();

        //}
        //catch
        //{
        //    // Do nothing
        //}
    }

    /// <summary>
    /// Shutdown for app
    /// </summary>
    public void ShutDown()
    {
        AppBuilder.StopApplication();
    }

    /// <summary>
    /// Check if there are new log entries
    /// </summary>
    public void CheckLogs()
    {

        if (_listener == null)
        {
            return;
        }

        var count = _listener.Messages.Count;

        if (count == 0)
        {
            return;
        }

        // Keep maximum log data length equal to MaxNumberOfLogEntries
        if (_logData.Count > 0 && _logData.Count + count > MaxNumberOfLogEntries)
        {
            for (var i = _logData.Count - MaxNumberOfLogEntries - 2; i >= 0; i--)
            {
                _logData.Remove(_logData[i]);
            }
        }

        // Add the received messages to log data
        for (var i = 0; i < count; i++)
        {
            var logMsg = GeneralHelper.DequeueFromQueue(_listener.Messages);

            if (_logData.Count > MaxNumberOfLogEntries)
            {
                continue;
            }

            _logData.Add(logMsg);
        }

        // If there are to much entries
        for (var i = _logData.Count - MaxNumberOfLogEntries - 2; i >= 0; i--)
        {
            _logData.Remove(_logData[i]);
        }


        OnPropertyChanged(nameof(LogData));
    }


    /// <summary>
    /// Log data as string to show on UI
    /// </summary>
    public string LogData
    {
        get
        {
            var x = new StringBuilder();
            foreach (var message in _logData)
            {
                x.AppendLine(message);
            }

            return x.ToString();

        }
    }

    /// <summary>
    /// Event level
    /// </summary>
    public EventLevel LogEventLevel
    {
        get => _logEventLevel;
        set
        {
            if (value == _logEventLevel)
            {
                return;
            }
            _logEventLevel = value;
            _listener.EventLevel = _logEventLevel;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// The logo to use for the user interface
    /// </summary>
    public BitmapImage Logo
    {
        get => _logo;
        private set
        {
            _logo = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Background color of the header line
    /// </summary>
    public Color HeaderBackColor
    {
        get => _headerBackColor;
        set
        {
            _headerBackColor = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Create the main form of the application
    /// </summary>
    /// <returns></returns>
    public virtual Window CreateWindow()
    {
        return new MainWindow(this)
        {
            WindowState = WindowState.Normal,
            Visibility = Visibility.Visible
        };
    }
}