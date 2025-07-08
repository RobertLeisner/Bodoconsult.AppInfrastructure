Logging with IAppLoggerProxy / AppLoggerProxy

# Overview

AppLoggerProxy is a high performance logger infrastructure for multithreaded and or multitasked apps with low resulting garbage pressure. 

Log entries are stored to a intermediate queue and then processed on a single thread during app runtime using a IWatchdog implementation. This avoids file access errors resulting from different threads trying to access the destinantion log at the same time.

To reduce garbage pressure log entries are reused. Therefore you should use a singelton instance of a LogDataFactory for the whole app. You can store this singleton instance i.e. in a singleton IAppGlobals instance for your app.

Each instance of IAppLoggerProxy is representing a separate logging target.

Log entries are written to the logging target in a single threaded way to avoid trouble with accessing log file from multiple threads.

## Supported logging targets

IAppLoggerProxy supports the following logging targets by default:

-   Log4Net

-   Console

-   Debug window (only in debug mode)

-   Eventlog

-   EventSource (to use log entries in the app itself i.e. for showing it in a GUI)

This logging targets can be activated seperately or in a combined manor. Combine Log4Net and EventSource in appsettings.json if you want to log to a file and to the GUI at the same time for example.

## Configuring central app logging in appsettings.json

Central app logging with IAppLoggerProxy can be configured in the appsettings.json file. See  a typical example here:

``` json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(LocalDB)\\MSSQLLocalDb;Initial Catalog=XYDatabase;Integrated Security=true;MultipleActiveResultSets=True;App=ConsoleApp1"
  },
  "Logging": {
    "MinimumLogLevel": "Debug",
    "LogLevel": {
      "Default": "Information",
      "System": "Information",
      "Microsoft": "Information",
      "Microsoft.EntityFrameworkCore": "Warning"
    },
    "Log4Net": {
      "LogLevel": {
        "Default": "Debug"
      }
    },
    //"Console": {
    //  "IncludeScopes": true,
    // "DisableColors": false
    //},
    //, "EventLog": {
    // "SourceName": "MyApp"
    // "LogName": "MyLogName"
    // "MachineName": "MyMachineName"
    //},
    "Debug": {
      "LogLevel": {
        "Default": "Debug"
      }
    },
    "EventSource": {
      "LogLevel": {
        "Default": "Error"
      }
    }
  }
}
``` 

## Configuring other loggers 

### Creating multiple logfiles

If you want to setup multiple logfiles for your app for example per device the app handles you can create multiple instances of IAppLoggerProxy. See class MonitorLoggerFactory. It takes a full path for the logfile to log in and the other settings from log4net.config.

### Using log4net as logger

If you want to use log4net for logging you can use the Log4NetLoggerFactory. 

``` csharp
var logger = new AppLoggerProxy(new Log4NetLoggerFactory.(), Globals.LogDataFactory);

_log.LogWarning("Hallo");			
```

You can configure the logger with a log4net.config file in the project main folder. See log4net documentation for details.

### Fake logger for unit tests 

For unit tests you can use a fake implementation of a logger. It logs to the output window only.

``` csharp
var logger = new AppLoggerProxy(new FakeLoggerFactory(), Globals.LogDataFactory);

_log.LogWarning("Hallo");	
```