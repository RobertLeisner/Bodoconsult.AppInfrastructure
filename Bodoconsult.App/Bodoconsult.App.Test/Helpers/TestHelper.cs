// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Benchmarking;
using Bodoconsult.App.BusinessTransactions;
using Bodoconsult.App.ClientNotifications;
using Bodoconsult.App.EventCounters;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Logging;
using Bodoconsult.App.Test.App;
using System.Diagnostics;
using System.Reflection;

namespace Bodoconsult.App.Test.Helpers;

internal static class TestHelper
{
    /// <summary>
    /// Create a <see cref="IAppEventSource"/> instance
    /// </summary>
    /// <returns><see cref="IAppEventSource"/> instance based on <see cref="AppApmEventSource"/></returns>
    internal static IAppEventSource CreateAppEventSource()
    {
        var logger = GetFakeAppLoggerProxy();

        var aes = new AppApmEventSource(logger);
        aes.AddProvider(new BusinessTransactionEventSourceProvider());

        return aes;
    }

    public static IClientNotificationLicenseManager GetFakeLicenceManager()
    {
        return new FakeClientNotificationLicenseManager();
    }

    private static string _testDataPath;

    public static string TempPath = Path.GetTempPath();

    public static string TestDataPath
    {
        get
        {

            if (!string.IsNullOrEmpty(_testDataPath))
            {
                return _testDataPath;
            }

            var path = new DirectoryInfo(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName).Parent.Parent.Parent.FullName;

            _testDataPath = Path.Combine(path, "TestData");

            if (!Directory.Exists(_testDataPath))
            {
                Directory.CreateDirectory(_testDataPath);
            }

            return _testDataPath;
        }
    }

    /// <summary>
    /// Start an app by file name
    /// </summary>
    /// <param name="fileName"></param>
    public static void StartFile(string fileName)
    {

        if (!Debugger.IsAttached)
        {
            return;
        }

        Assert.That(File.Exists(fileName));

        var p = new Process { StartInfo = new ProcessStartInfo { UseShellExecute = true, FileName = fileName } };

        p.Start();

    }

    /// <summary>
    /// Get a fully setup fake logger
    /// </summary>
    /// <returns>Logger instance</returns>
    public static AppLoggerProxy GetFakeAppLoggerProxy()
    {
        if (_logger != null)
        {
            return _logger;
        }
        _logger = new AppLoggerProxy(new FakeLoggerFactory(), Globals.Instance.LogDataFactory);
        return _logger;
    }

    private static AppLoggerProxy _logger;

    /// <summary>
    /// Get a fully setup fake bench logger
    /// </summary>
    /// <returns>Bench logger instance</returns>
    public static AppBenchProxy GetFakeAppBenchProxy()
    {
        if (_bench != null)
        {
            return _bench;
        }
        _bench = new AppBenchProxy(new FakeLoggerFactory(), Globals.Instance.LogDataFactory);
        return _bench;
    }

    private static AppBenchProxy _bench;
}