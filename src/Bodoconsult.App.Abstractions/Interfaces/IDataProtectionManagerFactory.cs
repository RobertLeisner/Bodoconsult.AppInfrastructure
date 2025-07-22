// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces
{
    /// <summary>
    ///  Interface for factories creating IDataProtectionManager instances
    /// </summary>
    public interface IDataProtectionManagerFactory
    {
        /// <summary>
        /// Create an IDataProtectionManager instance
        /// </summary>
        /// <param name="destinationFilePath">File path to store the secrets storage</param>
        /// <returns>IDataProtectionManager instance</returns>
        IDataProtectionManager CreateInstance(string destinationFilePath);
    }
}
