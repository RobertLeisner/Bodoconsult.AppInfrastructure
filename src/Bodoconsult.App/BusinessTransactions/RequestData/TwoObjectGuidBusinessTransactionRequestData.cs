// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.BusinessTransactions.RequestData;

/// <summary>
/// The request data for an business transaction request providing two objects UIDs
/// </summary>
public class TwoObjectGuidBusinessTransactionRequestData : BaseBusinessTransactionRequestData
{
    /// <summary>
    /// The GUID of the requested object 1
    /// </summary>
    public Guid ObjectGuid1 { get; set; }

    /// <summary>
    /// The GUID of the requested object 2
    /// </summary>
    public Guid ObjectGuid2 { get; set; }

}