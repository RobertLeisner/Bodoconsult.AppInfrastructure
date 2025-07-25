// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.BusinessTransactions.RequestData;

/// <summary>
/// The request data for a business transaction request asking for a certain object ID and delivering a integer value
/// </summary>
public class ObjectIdIntBusinessTransactionRequestData : BaseBusinessTransactionRequestData
{
    /// <summary>
    /// The ID of the requested object
    /// </summary>
    public int ObjectId { get; set; }

    /// <summary>
    /// The int value provided by the request
    /// </summary>
    public int Value { get; set; }
}