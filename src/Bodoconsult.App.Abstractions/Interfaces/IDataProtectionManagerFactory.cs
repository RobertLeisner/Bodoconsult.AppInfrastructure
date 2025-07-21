// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
