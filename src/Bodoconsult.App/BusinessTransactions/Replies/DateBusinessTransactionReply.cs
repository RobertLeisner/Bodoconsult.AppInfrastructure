// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.BusinessTransactions.Replies;

/// <summary>
/// Reply returnind a date
/// </summary>
public class DateBusinessTransactionReply: DefaultBusinessTransactionReply
{
    /// <summary>
    /// A date time value to transfer as reply for the business transaction
    /// </summary>
    public DateTime? Date { get; set; }
}