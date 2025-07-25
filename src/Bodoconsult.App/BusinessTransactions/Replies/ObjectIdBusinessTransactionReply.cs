// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.BusinessTransactions.Replies;

/// <summary>
/// A business transaction reply transporting an object ID
/// </summary>
public class ObjectIdBusinessTransactionReply : DefaultBusinessTransactionReply
{
    /// <summary>
    /// Object to transport with the reply
    /// </summary>
    public int ObjectId { get; set; }

}