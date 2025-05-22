// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Logging;
using Bodoconsult.App.WinForms.Interfaces;

namespace Bodoconsult.App.WinForms.AppStarter.Forms.ViewModel;

/// <summary>
/// ViewModel for MainWindow form
/// </summary>
public class MainWindowViewModel : IMainWindowViewModel
{

    private const int MaxNumberOfLogEntries = 100;

    private readonly AppEventListener _listener;

    private readonly IList<string> _logData = new List<string>();

    private EventLevel _logEventLevel;

    /// <summary>
    /// Current app start process handler
    /// </summary>
    public IAppBuilder AppBuilder { get; private set; }

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
    public string MsgConsoleWait { get; set; }

    /// <summary>
    /// Message "how to shitdon server app"
    /// </summary>
    public string MsgHowToShutdownServer { get; set; }

    /// <summary>
    /// Message to exit the app
    /// </summary>
    public string MsgExit { get; set; } = "Exit the app?";


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

    /// <summary>
    /// Current application context
    /// </summary>
    public TaskTrayApplicationContext ApplicationContext { get; set; }



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

        try
        {
            var assembly = Assembly.GetEntryAssembly();

            if (assembly != null)
            {
                var logoStream = assembly.GetManifestResourceStream(AppBuilder.AppGlobals.AppStartParameter.LogoRessourcePath);

                if (logoStream != null)
                {
                    Logo = new Bitmap(logoStream);
                }
            }

        }
        catch
        {
            // Do nothing
        }
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
    public Bitmap Logo { get; private set; }

    /// <summary>
    /// Background color of the header line
    /// </summary>
    public Color HeaderBackColor { get; set; } = Color.FromArgb(58, 131, 191);

    /// <summary>
    /// Create the main form of the application
    /// </summary>
    /// <returns></returns>
    public virtual Form CreateForm()
    {
        return new MainWindow(this)
        {
            Visible = true,
            WindowState = FormWindowState.Normal
        };
    }
}