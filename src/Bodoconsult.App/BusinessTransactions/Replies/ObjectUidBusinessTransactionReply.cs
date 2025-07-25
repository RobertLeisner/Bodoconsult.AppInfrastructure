﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.BusinessTransactions.Replies;

/// <summary>
/// A business transaction reply transporting an object UID
/// </summary>
public class ObjectUidBusinessTransactionReply : DefaultBusinessTransactionReply
{
    /// <summary>
    /// Object to transport with the reply
    /// </summary>
    public Guid ObjectUid { get; set; }

}