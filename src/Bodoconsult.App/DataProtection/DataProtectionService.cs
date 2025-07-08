// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Bodoconsult.App.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

// https://duendesoftware.com/blog/20250313-data-protection-aspnetcore-duende-identityserver

// https://andrewlock.net/an-introduction-to-the-data-protection-system-in-asp-net-core/

// https://github.com/dotnet/aspnetcore/blob/main/src/DataProtection/

namespace Bodoconsult.App.DataProtection
{
    public class DataProtectionService : IDataProtectionService
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;

        private readonly IKeyManager _keyManager;


        public static DataProtectionService CreateInstance(string destinationFolderPath, string appName)
        {
            var dirInfo = new DirectoryInfo(destinationFolderPath);

            var provider = BodoDataProtectionProvider.Create(dirInfo, appName);

            var service = new DataProtectionService(destinationFolderPath, provider.Item1, provider.Item2);

            return service;
        }


        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="destinationFolderPath">The folder path the encrypted file is stored in</param>
        /// <param name="dataProtectionProvider"></param>
        /// <param name="keyManager"></param>
        public DataProtectionService(string destinationFolderPath, IDataProtectionProvider dataProtectionProvider, IKeyManager keyManager)
        {
            DestinationFolderPath = destinationFolderPath;
            _dataProtectionProvider = dataProtectionProvider;
            _keyManager = keyManager;
        }

        /// <summary>
        /// The folder path the encrypted file is stored in
        /// </summary>
        public string DestinationFolderPath { get; }

        /// <summary>
        /// Store a value in a safe manner
        /// </summary>
        /// <param name="key">Key name for the value</param>
        /// <param name="value">Value to store</param>
        public string Protect(string key, string value)
        {
            var protector = _dataProtectionProvider.CreateProtector(key);

            // Protect the payload
            var result = protector.Protect(value);

            return result;
        }

        /// <summary>
        /// Load a value stored in a safe manner
        /// </summary>
        /// <param name="key">Key name for the value</param>
        /// <param name="cipherValue">The encrypted value to decrypt</param>
        public string Unprotect(string key, string cipherValue)
        {
            var protector = _dataProtectionProvider.CreateProtector(key);
            var value = protector.Unprotect(cipherValue);
            return value;
        }
    }
}
