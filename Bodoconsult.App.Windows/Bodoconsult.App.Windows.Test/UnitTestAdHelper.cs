// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System.Diagnostics;
using System.Runtime.Versioning;
using Bodoconsult.App.Windows.Network.ActiveDirectory.Helpers;
using NUnit.Framework;

namespace Bodoconsult.App.Windows.Test;

[TestFixture]
[SupportedOSPlatform("windows")]
public class UnitTestAdHelper
{
    [Test]
    public void TestGetLdapDomainForCurrentUser()
    {
        var result = AdHelper.GetLdapDomainForCurrentUser();

        Debug.Print(result);

        Assert.That(string.IsNullOrEmpty(result), Is.False);
    }

}