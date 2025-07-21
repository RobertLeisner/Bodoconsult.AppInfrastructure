﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.BusinessTransactions.Replies;
using Bodoconsult.App.Delegates;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.BusinessTransactions;

/// <summary>
/// Current implementation of a <see cref="IBusinessTransactionManager"/> based business transaction manager
/// </summary>
public class BusinessTransactionManager : IBusinessTransactionManager
{
    private readonly object _transactionLock = new();

    private readonly IAppLoggerProxy _logger;

    private readonly IAppEventSource _eventSource;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="logger">Current app logger</param>
    /// <param name="appEventSourceFactory">Current factory for an <see cref="IAppEventSource"/>> for tracing events</param>
    public BusinessTransactionManager(IAppLoggerProxy logger, IAppEventSourceFactory appEventSourceFactory)
    {
        _logger = logger;
        _eventSource = appEventSourceFactory.CreateInstance();
    }

    /// <summary>
    /// Current transaction cache. Instances are lazy loaded on first use
    /// </summary>
    public IList<BusinessTransaction> TransactionCache { get; } = new List<BusinessTransaction>();


    /// <summary>
    /// A dictionary containing delegates for creating business transactions.
    /// The key of the dictionary is the int tarnsaction ID
    /// </summary>
    public Dictionary<int, CreateBusinessTransactionDelegate> CreateBusinessTransactionDelegates { get; } = new();


    /// <summary>
    /// Add the transaction delivered by the provider to an internal storage
    /// </summary>
    /// <param name="provider"></param>
    public void AddProvider(IBusinessTransactionProvider provider)
    {
        foreach (var item in provider.CreateBusinessTransactionDelegates)
        {

            if (CreateBusinessTransactionDelegates.ContainsKey(item.Key))
            {
                throw new ArgumentException($"Adding provider to transaction manager: transaction {item.Key} already exists");
            }

            CreateBusinessTransactionDelegates.Add(item.Key, item.Value);
        }
    }

    /// <summary>
    /// Check for business transaction and return it
    /// </summary>
    /// <param name="transactionId">Requested transaction ID</param>
    /// <returns>Business transaction</returns>
    public BusinessTransaction CheckForBusinessTransaction(int transactionId)
    {

        BusinessTransaction t;

        lock (_transactionLock)
        {
            t = TransactionCache.FirstOrDefault(x => x.Id == transactionId);
        }

        if (t != null)
        {
            return t;
        }

        if (!CreateBusinessTransactionDelegates.ContainsKey(transactionId))
        {
            throw new ArgumentException(
                $"Checking for business transaction: No definition loaded for {transactionId}");
        }

        CreateBusinessTransactionDelegates.TryGetValue(transactionId, out var td);

        if (td == null)
        {
            throw new ArgumentException(
                $"Checking for business transaction: No definition delegate for {transactionId}");
        }


        t = td.Invoke();


        if (t.RunBusinessTransactionDelegate == null)
        {
            throw new ArgumentException(
                $"Checking for business transaction: Transaction {transactionId} does not have an runner method");
        }

        lock (_transactionLock)
        {
            TransactionCache.Add(t);
        }

        return t;
    }

    /// <summary>
    /// Run a business transaction 
    /// </summary>
    /// <param name="transactionId">ID of the requested transaction</param>
    /// <param name="requestData">Data delivered by the request</param>
    /// <returns></returns>
    public IBusinessTransactionReply RunBusinessTransaction(int transactionId, IBusinessTransactionRequestData requestData)
    {

        _logger.LogDebug($"Transaction {transactionId} with GUID {requestData.TransactionGuid} received");
        requestData.Benchmark?.AddStep("InternalReceived");

        BusinessTransaction transaction;
        string msg;

        try
        {
            transaction = CheckForBusinessTransaction(transactionId);
        }
        catch (Exception e)
        {
            msg = $"Checking for transaction {transactionId} failed";
            _logger.LogError(msg, e);

            requestData.Benchmark?.AddStep("InternalDone");
            return new DefaultBusinessTransactionReply
            {
                ErrorCode = 1,
                Message = msg,
                RequestData = requestData
            };
        }

        if (transaction == null)
        {
            msg = $"Transaction {transactionId} NOT found";
            _logger.LogError(msg);

            requestData.Benchmark?.AddStep("InternalDone");
            return new DefaultBusinessTransactionReply
            {
                ErrorCode = 1,
                Message = msg,
                RequestData = requestData
            };
        }

        // Set the transaction ID for the request data now to transfer it to the reply
        requestData.TransactionId = transactionId;

        try
        {

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            var result = transaction.RunBusinessTransactionDelegate(requestData);

            stopWatch.Stop();

            _logger.LogDebug($"Transaction {transactionId} with GUID {requestData.TransactionGuid} was successful. Duration {stopWatch.ElapsedMilliseconds} ms");
            _eventSource.ReportIncrement(BusinessTransactionEventSourceProvider.BtmRunBusinessTransactionSuccess);
            _eventSource.ReportMetric(BusinessTransactionEventSourceProvider.BtmRunBusinessTransactionDuration, stopWatch.ElapsedMilliseconds);

            result.RequestData = requestData;

            requestData.Benchmark?.AddStep("InternalDone");
            return result;

            // ToDo: EventCounter for transaction

        }
        catch (Exception e)
        {

            msg = $"Transaction {transactionId} with GUID {requestData.TransactionGuid} failed: {e.Message}: {e.StackTrace}";
            _logger.LogError(msg);
            requestData.Benchmark?.AddStep("InternalDone");
            return new DefaultBusinessTransactionReply
            {
                ErrorCode = transaction.ErrorCode,
                Message = msg,
                RequestData = requestData
            };
        }
    }
}