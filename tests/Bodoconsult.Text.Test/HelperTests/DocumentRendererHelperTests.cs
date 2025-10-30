// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Text.Test.HelperTests;

[TestFixture]
public class DocumentRendererHelperTests
{
    [TestCase(2, PageNumberFormatEnum.UpperLatin, "B")]
    [TestCase(1, PageNumberFormatEnum.UpperLatin, "A")]
    [TestCase(2, PageNumberFormatEnum.LowerLatin, "b")]
    [TestCase(1, PageNumberFormatEnum.LowerLatin, "a")]
    [TestCase(2, PageNumberFormatEnum.LowerRoman, "ii")]
    [TestCase(1, PageNumberFormatEnum.LowerRoman, "i")]
    [TestCase(2, PageNumberFormatEnum.UpperRoman, "II")]
    [TestCase(1, PageNumberFormatEnum.UpperRoman, "I")]
    [TestCase(2, PageNumberFormatEnum.Decimal, "2")]
    [TestCase(1, PageNumberFormatEnum.Decimal, "1")]
    public void GetFormattedNumber_ValidPageNumber_CorrectFormatted(int pageNumber, PageNumberFormatEnum pageNumberFormat, string expectedResult)
    {
        // Arrange 

        // Act
        var result = DocumentRendererHelper.GetFormattedNumber(pageNumber, pageNumberFormat);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}