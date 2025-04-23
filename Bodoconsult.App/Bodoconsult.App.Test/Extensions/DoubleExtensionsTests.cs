// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Extensions;

namespace Bodoconsult.App.Test.Extensions;

[TestFixture]
internal class DoubleExtensionsTests
{

    [Test]
    public void AsSqlString_Number_Returns5001()
    {
        // Arrange 
        const double value = 5001;

        // Act  
        var result = value.AsSqlString();

        // Assert
        Assert.That(result, Is.EqualTo("5001"));

    }

    [Test]
    public void AsSqlString_NumberWithDecimals_Returns5001Dot00()
    {
        // Arrange 
        const double value = 5001.01;

        // Act  
        var result = value.AsSqlString("0.00");

        // Assert
        Assert.That(result, Is.EqualTo("5001.01"));

    }

}