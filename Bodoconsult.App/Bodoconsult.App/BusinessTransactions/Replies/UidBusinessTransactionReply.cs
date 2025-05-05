// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.BusinessTransactions.Replies
{
    /// <summary>
    /// A business transaction reply transporting an UID
    /// </summary>
    public class UidBusinessTransactionReply : DefaultBusinessTransactionReply
    {
        /// <summary>
        /// UID to transport with the reply
        /// </summary>
        public Guid Uid { get; set; }

    }
}