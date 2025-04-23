// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Extensions;

namespace Bodoconsult.App.Test.Extensions;

[TestFixture]
class StringExtensionsTests
{

    [Test]
    public void AsSqlString_EmptyString_ReturnsNull()
    {
        // Arrange 
        const string value = "";

        // Act  
        var result = value.AsSqlString();

        // Assert
        Assert.That(result, Is.EqualTo("null"));

    }

    [Test]
    public void AsSqlString_NullString_ReturnsNull()
    {
        // Arrange 
        const string value = null;

        // Act  
        var result = value.AsSqlString();

        // Assert
        Assert.That(result, Is.EqualTo("null"));

    }

    [Test]
    public void AsSqlString_String_ReturnsNull()
    {
        // Arrange 
        const string value = "Value";

        // Act  
        var result = value.AsSqlString();

        // Assert
        Assert.That(result, Is.EqualTo("'Value'"));

    }

    [Test]
    public void LimitToLength_String_ReturnsTruncatedString()
    {
        // Arrange 
        const string value = "Value";

        // Act  
        var result = value.LimitToLength(2);

        // Assert
        Assert.That(result, Is.EqualTo("Va"));

    }

    [Test]
    public void LimitToLength_String_ReturnsString()
    {
        // Arrange 
        const string value = "Value";

        // Act  
        var result = value.LimitToLength(15);

        // Assert
        Assert.That(result, Is.EqualTo("Value"));

    }

    [Test]
    public void LimitToLength_EmptyString_ReturnsEmptyString()
    {
        // Arrange 
        const string value = "";

        // Act  
        var result = value.LimitToLength(15);

        // Assert
        Assert.That(result, Is.EqualTo(""));

    }

    [Test]
    public void LimitToLength_NullString_ReturnsNull()
    {
        // Arrange 
        const string value = null;

        // Act  
        var result = value.LimitToLength(15);

        // Assert
        Assert.That(result, Is.EqualTo(null));

    }
}