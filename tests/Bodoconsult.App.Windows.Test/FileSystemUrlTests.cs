// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.IO;
using Bodoconsult.App.Windows.FileSystem;
using Bodoconsult.App.Windows.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.App.Windows.Test;

[TestFixture]
public class FileSystemUrlTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void TestCtor()
    {

        // Arrange
        var url = Path.Combine(TestHelper.TestDataPath, "Bodoconsult.url");

        var fri = new FileInfo(url);

        // Act
        var urlFile = new FileSystemUrl(fri);

        // Assert
        Assert.That(urlFile.Caption, Is.EqualTo("Bodoconsult"));
    }

    [Test]
    public void TestRead()
    {

        // Arrange
        var url = Path.Combine(TestHelper.TestDataPath, "Bodoconsult.url");

        var fri = new FileInfo(url);

        var urlFile = new FileSystemUrl(fri);

        // Act
        urlFile.Read();

        // Assert
        Assert.That(urlFile.Url, Is.EqualTo("http://www.bodoconsult.de/"));
        Assert.That(urlFile.Caption, Is.EqualTo("Bodoconsult"));
    }
}