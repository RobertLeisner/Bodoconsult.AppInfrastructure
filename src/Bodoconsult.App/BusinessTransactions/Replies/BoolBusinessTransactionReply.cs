// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.BusinessTransactions.Replies;

/// <summary>
/// Reply return a bool <see cref="Value"/>
/// </summary>
public class BoolBusinessTransactionReply: DefaultBusinessTransactionReply
{
    /// <summary>
    /// A bool value to transfer as reply for the business transaction
    /// </summary>
    public bool Value { get; set; }
}