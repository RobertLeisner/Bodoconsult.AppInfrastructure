// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.BusinessTransactions.Replies;

/// <summary>
/// Reply return an int <see cref="Value"/>
/// </summary>
public class IntegerBusinessTransactionReply: DefaultBusinessTransactionReply
{
    /// <summary>
    /// A integer value to transfer as reply for the business transaction
    /// </summary>
    public int Value { get; set; }
}