// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Extensions;

namespace Bodoconsult.App.Test.Extensions;

[TestFixture]
internal class GuidExtensionsTests
{


    [Test]
    public void ToPlainString_ValidGuid_ReturnsPlainString()
    {
        // Arrange 
        var uid = Guid.NewGuid();

        // Act  
        var result = uid.ToPlainString();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Length, Is.EqualTo(32));

    }

}