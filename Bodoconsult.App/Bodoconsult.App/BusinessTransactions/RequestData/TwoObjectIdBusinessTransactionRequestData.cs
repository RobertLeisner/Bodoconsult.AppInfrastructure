// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.BusinessTransactions.RequestData
{
    /// <summary>
    /// The request data for a business transaction request asking for two object IDs
    /// </summary>
    public class TwoObjectIdBusinessTransactionRequestData : BaseBusinessTransactionRequestData
    {
        /// <summary>
        /// The ID of the requested object 1
        /// </summary>
        public int ObjectId1 { get; set; }

        /// <summary>
        /// The ID of the requested object 2
        /// </summary>
        public int ObjectId2 { get; set; }
    }
}