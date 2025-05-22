using Bodoconsult.Core.Windows.System;
using NUnit.Framework;
using System.Runtime.Versioning;

namespace Bodoconsult.App.Windows.Test;

[SupportedOSPlatform("windows")]
[TestFixture]
public class UnitTestClipBoard
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void TestSetText()
    {

        // Arrange
        const string text = "CopyToClipboard";

        // Act
        Clipboard.SetText(text);

        var result = Clipboard.GetText();


        // Assert
        Assert.That(result, Is.EqualTo(text));
    }
}