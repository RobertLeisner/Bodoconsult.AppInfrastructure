// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;

namespace Bodoconsult.App.Test.HelperTests;

[TestFixture]
internal class MeasurementHelperTests
{

    [Test]
    public void GetPtFromCm_1cm_ReturnsPt()
    {
        // Arrange 
        const int input = 1;

        // Act  
        var result = MeasurementHelper.GetPtFromCm(input);

        // Assert
        Assert.That(result, Is.EqualTo(28.3));

    }

    [Test]
    public void GetPtFromMm_1mm_ReturnsPt()
    {
        // Arrange 
        const int input = 1;

        // Act  
        var result = MeasurementHelper.GetPtFromMm(input);

        // Assert
        Assert.That(result, Is.EqualTo(2.83));

    }

    [Test]
    public void GetTwipsFromCm_1cm_ReturnsTwips()
    {
        // Arrange 
        const int input = 1;

        // Act  
        var result = MeasurementHelper.GetTwipsFromCm(input);

        // Assert
        Assert.That(result, Is.EqualTo(567));

    }

}