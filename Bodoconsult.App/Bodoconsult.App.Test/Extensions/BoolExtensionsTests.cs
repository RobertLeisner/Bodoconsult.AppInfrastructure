// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Extensions;

namespace Bodoconsult.App.Test.Extensions;

[TestFixture]
internal class BoolExtensionsTests
{

    [Test]
    public void AsSqlString_False_Returns0()
    {
        // Arrange 
        const bool value = false;

        // Act  
        var result = value.AsSqlString();

        // Assert
        Assert.That(result, Is.EqualTo("0"));

    }

    [Test]
    public void AsSqlString_True_Returns1()
    {
        // Arrange 
        const bool value = true;

        // Act  
        var result = value.AsSqlString();

        // Assert
        Assert.That(result, Is.EqualTo("1"));

    }
}