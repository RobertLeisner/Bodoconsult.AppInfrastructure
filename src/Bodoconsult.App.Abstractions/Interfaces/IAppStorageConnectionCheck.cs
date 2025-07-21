// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

namespace Bodoconsult.App.Abstractions.Interfaces
{
    /// <summary>
    ///  Check if the connection to the app data storage is available
    /// </summary>
    public interface IAppStorageConnectionCheck
    {
        /// <summary>
        /// Check if the connection to the app data storage is available. Returns true if the data storage is accessible else false
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Helpful information for the user if the check fails i.e. conenction etc.
        /// </summary>
        string HelpfulInformation { get; }

    }
}