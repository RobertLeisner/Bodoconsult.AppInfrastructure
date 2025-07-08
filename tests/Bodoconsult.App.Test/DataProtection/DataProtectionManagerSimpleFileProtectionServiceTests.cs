// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Diagnostics;
using Bodoconsult.App.DataProtection;
using Bodoconsult.App.Helpers;
using Bodoconsult.App.Test.App;

namespace Bodoconsult.App.Test.DataProtection;

[NonParallelizable]
[SingleThreaded]
internal class DataProtectionManagerSimpleFileProtectionServiceTests : BaseDataProtectionManagerTests
{
    public DataProtectionManagerSimpleFileProtectionServiceTests()
    {
        FileProtectionService = new SimpleFileProtectionService();
        Extension = "dat";
    }
}