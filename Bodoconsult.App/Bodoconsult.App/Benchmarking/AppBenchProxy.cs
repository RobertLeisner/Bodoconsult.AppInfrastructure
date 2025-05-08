﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using System.Text;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Logging;
using Microsoft.Extensions.Logging;

namespace Bodoconsult.App.Benchmarking;

/// <summary>
/// Current implementation of <see cref="IAppBenchProxy"/> for benchmark viewer https://github.com/crep4ever/benchmark-viewer.
/// Collect logging messages and write them in a separate job. Implementation by Freddy Darsonville
/// </summary>
public class AppBenchProxy : IAppBenchProxy
{
    private readonly ILogDataFactory _logDataFactory;

    public ILoggerFactory LoggerFactory { get; }

    private IProducerConsumerQueue<LogData> _logMessages;

    private readonly ILogger _logger;

    /// <summary>
    /// Ctor. Requires a ILoggerFactory
    /// </summary>
    /// <param name="logger"></param>
    public AppBenchProxy(ILoggerFactory logger, ILogDataFactory logDataFactory)
    {
        LoggerFactory = logger;
        _logger = logger.CreateLogger($"Default");

        BaseCtor();

        _logDataFactory = logDataFactory;
    }



    /// <summary>
    /// Base Ctor
    /// </summary>
    private void BaseCtor()
    {
        StartLogging();
    }

    /// <summary>
    /// Write a log entry to the logger. Not intended for direct usage. Public only for unit testing!
    /// </summary>
    /// <param name="logData">Current data to log</param>
    public void WriteLogEntry(LogData logData)
    {
        // Output format:
        // "yyyy.MM.dd HH:mm:ss.fffffff",   "Method",   "START",    "", "comment",  ""

        // LogData member:
        // LogDate                      , SourceFile,   SourceMethod, "", Message, ""               

        try
        {
            _logger.Log(logData.LogLevel,
                logData.EventId,
                null,
                $"\"{logData.LogDate:yyyy-MM-dd HH:mm:ss.fff}\",\"{logData.SourceFile}\",\"{logData.SourceMethod}\",\"\",\"{logData.Message}\",\"\"");
        }
        catch
        {
            Debug.Print("Logger error");
        }

        _logDataFactory.EnqueueInstance(logData);
    }

    /// <summary>
    /// Concrete Implem of LogStart
    /// </summary>
    /// <param name="key"></param>
    /// <param name="comment"></param>
    public void LogStart(string key, string comment)
    {
        var log = _logDataFactory.DequeueInstance();
        log.Exception = null;
        log.Message = comment;
        log.LogLevel = LogLevel.Information;
        log.SourceFile = key;
        log.SourceMethod = "START";
        log.SourceRowNumber = 0;
        log.Args = new object[] { };

        _logMessages?.Enqueue(log);
    }

    /// <summary>
    /// Concrete Implem of LogStep
    /// </summary>
    /// <param name="key"></param>
    /// <param name="comment"></param>
    public void LogStep(string key, string comment)
    {
        var log = _logDataFactory.DequeueInstance();
        log.Exception = null;
        log.Message = comment;
        log.LogLevel = LogLevel.Information;
        log.SourceFile = key;
        log.SourceMethod = "STEP";
        log.SourceRowNumber = 0;
        log.Args = new object[] { };

        _logMessages?.Enqueue(log);
    }

    /// <summary>
    /// Concrete Implem of LogStop
    /// </summary>
    /// <param name="key"></param>
    /// <param name="comment"></param>
    public void LogStop(string key, string comment)
    {
        var log = _logDataFactory.DequeueInstance();
        log.Exception = null;
        log.Message = comment;
        log.LogLevel = LogLevel.Information;
        log.SourceFile = key;
        log.SourceMethod = "STOP";
        log.SourceRowNumber = 0;
        log.Args = new object[] { };

        _logMessages?.Enqueue(log);
    }



    /// <summary>
    /// Start the logging
    /// </summary>
    public void StartLogging()
    {
        if (_logMessages != null)
        {
            StopLogging();
        }

        _logMessages = new ProducerConsumerQueue<LogData>
        {
            ConsumerTaskDelegate = WriteLogEntry
        };
        _logMessages.StartConsumer();
    }

    /// <summary>
    /// Stop the logging
    /// </summary>
    public void StopLogging()
    {
        _logMessages.StopConsumer();
    }



    #region Helper methods

    /// <summary>
    /// Format args as JSON string
    /// </summary>
    /// <param name="args">Args delivered by the method caller</param>
    /// <returns>JSON formatted string</returns>
    public static string FormatArgs(object[] args)
    {

        if (args == null || args.Length == 0)
        {
            return "";
        }

        var s = new StringBuilder();
        s.AppendLine("");
        foreach (var arg in args)
        {
            if (arg is Exception e)
            {
                s.AppendLine($"{e.GetType().Name}: {e.Message} {e.StackTrace}: " //+ Globals.JsonSerializeNice(e)
                );
            }
            else if (arg != null)
            {
                ObjectHelper.GetObjectPropertiesAsString(arg, s);
            }
        }

        return s.ToString();

    }

    #endregion
    /// <summary>
    /// automatically LogStop
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }
        StopLogging();
        LoggerFactory?.Dispose();
    }

    /// <summary>
    /// automatically LogStop
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {

        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Dtor.
    /// </summary>
    ~AppBenchProxy()
    {
        Dispose(false);
    }

    /// <summary>
    /// Create a app bench proxy
    /// </summary>
    /// <param name="benchmarkFileName">Benchmark filename</param>
    /// <param name="logDataFactory">Current logdata factory. Should be singleton instance for loggers</param>
    /// <returns>Instance implementing <see cref="IAppBenchProxy"/></returns>
    public static IAppBenchProxy CreateAppBenchProxy(string benchmarkFileName, ILogDataFactory logDataFactory)
    {
        var benchLoggerFactory = new BenchLoggerFactory(benchmarkFileName);
        var appBenchProxyFactory = new AppBenchProxyFactory();
        var benchProxy = appBenchProxyFactory.CreateInstance(benchLoggerFactory, logDataFactory);
        return benchProxy;
    }
}