// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Benchmarking;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.BusinessTransactions.RequestData;

/// <summary>
/// Base class for <see cref="IBusinessTransactionRequestData"/> implementations
/// </summary>
public abstract class BaseBusinessTransactionRequestData: IBusinessTransactionRequestData
{
    /// <summary>
    /// The ID of the requested business transaction
    /// </summary>
    public int TransactionId { get; set; }

    /// <summary>
    /// Unique GUID of the transaction
    /// </summary>
    public Guid TransactionGuid { get; } = Guid.NewGuid();

    /// <summary>
    /// Benchmark object (see output in XXX_Benchmark.csv)
    /// Make sure to create it, addStep, and dispose it 
    /// </summary>
    public Bench Benchmark { get; set; }

    /// <summary>
    /// Request metadata: client GUID
    /// </summary>
    public Guid MetaDataClientGuid { get; set; }

    /// <summary>
    /// Request metadata: client name
    /// </summary>
    public string MetaDataClientName { get; set; }

    /// <summary>
    /// Request metadata: IP address the request is coming from
    /// </summary>
    public string MetaDataIpAddress { get; set; }

    /// <summary>
    /// Request metadata: user name in cleartext
    /// </summary>
    public string MetaDataUserName { get; set; }

    /// <summary>
    /// Request metadata: User ID
    /// </summary>
    public int MetaDataUserId { get; set; }
}