// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.DataProtection;

namespace Bodoconsult.App.Test.TestData;

internal class EntityWithUidWithSecrets
{
    [DataProtectionKey]
    public Guid Uid { get; set; }

    [DataProtectionSecret]
    public string Secret { get; set; }

    [DataProtectionSecret]
    public string Secret2 { get; set; }
}