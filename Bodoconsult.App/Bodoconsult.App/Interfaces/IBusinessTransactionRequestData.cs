// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Benchmarking;

namespace Bodoconsult.App.Interfaces;

/// <summary>
/// Interface for defining minimum requirements for business transaction request data
/// </summary>
public interface IBusinessTransactionRequestData
{
    /// <summary>
    /// The ID of the requested business transaction
    /// </summary>
    int TransactionId { get; set; }

    /// <summary>
    /// Unique GUID of the current transaction
    /// </summary>
    Guid TransactionGuid { get; }


    /// <summary>
    /// Benchmark object (see output in StSys_Benchmark.csv)
    /// Make sure to create it, addStep, and dispose it 
    /// </summary>
    Bench Benchmark { get; set; }


    /// <summary>
    /// Request meta data: client GUID
    /// </summary>
    public Guid MetaDataClientGuid { get; set; }

    /// <summary>
    /// Request meta data: client name
    /// </summary>
    public string MetaDataClientName { get; set; }

    /// <summary>
    /// Request meta data: IP address the request is coming from
    /// </summary>
    public string MetaDataIpAddress { get; set; }

    /// <summary>
    /// Request meta data: user name in cleartext
    /// </summary>
    public string MetaDataUserName { get; set; }

    /// <summary>
    /// Request meta data: User ID
    /// </summary>
    public int MetaDataUserId { get; set; }

}