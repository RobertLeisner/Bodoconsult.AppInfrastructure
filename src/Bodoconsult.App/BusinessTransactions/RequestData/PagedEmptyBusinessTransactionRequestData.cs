// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

namespace Bodoconsult.App.BusinessTransactions.RequestData
{
    /// <summary>
    /// The request data for an paged empty business transaction request (containing only request metadata)
    /// </summary>
    public class PagedEmptyBusinessTransactionRequestData : BaseBusinessTransactionRequestData
    {
        /// <summary>
        /// The current page of data to deliver
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The requested size as number of items per page
        /// </summary>
        public int PageSize { get; set; }

    }


    public enum TestoutTerminalConfig
    {
        Alternate,
        FixedTerminal
    }
}