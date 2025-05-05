// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.App.BusinessTransactions.RequestData
{
    /// <summary>
    /// The request data for an business transaction request asking for a certain object ID and returns a list of data
    /// </summary>
    public class ObjectIdListBusinessTransactionRequestData : BaseBusinessTransactionListRequestData
    {
        /// <summary>
        /// The ID of the requested object
        /// </summary>
        public int ObjectId { get; set; }

    }
}