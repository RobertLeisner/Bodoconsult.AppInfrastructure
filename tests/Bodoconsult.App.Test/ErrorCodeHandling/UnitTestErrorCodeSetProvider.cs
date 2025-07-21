// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.ErrorCodeHandling;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Test.ErrorCodeHandling;

[TestFixture]
internal class UnitTestErrorCodeSetProvider
{

    [Test]
    public void TestCtor()
    {
        // Arrange 

        // Act  
        var prov = new ErrorCodeSetProvider();

        // Assert
        Assert.That(prov.ErrorCodeSets.Count, Is.EqualTo(0));

    }

    [Test]
    public void TestAddObject()
    {
        // Arrange 
        var data = new ErrorCodeSet();

        var prov = new ErrorCodeSetProvider();

        // Act  
        prov.Add(data);

        // Assert
        Assert.That(prov.ErrorCodeSets.Count, Is.EqualTo(1));

    }

    [Test]
    public void TestAddString()
    {
        // Arrange 
        var data = "Code1;98;0;Test message 1\r\nCode2;99;100;Test message 2\r\n";

        var prov = new ErrorCodeSetProvider();

        // Act  
        prov.Add(data);

        // Assert
        Assert.That(prov.ErrorCodeSets.Count, Is.EqualTo(2));

        var item1 = prov.ErrorCodeSets[0];
        Assert.That(item1.Identifier, Is.EqualTo("Code1"));
        Assert.That(item1.ErrorCode, Is.EqualTo(98));
        Assert.That(item1.NextLevelErrorCode, Is.EqualTo(0));

        var item2 = prov.ErrorCodeSets[1];
        Assert.That(item2.Identifier, Is.EqualTo("Code2"));
        Assert.That(item2.ErrorCode, Is.EqualTo(99));
        Assert.That(item2.NextLevelErrorCode, Is.EqualTo(100));
    }


    [Test]
    public void TestGet()
    {
        // Arrange 
        var data = "Code1;98;0;Test message 1\r\nCode2;99;100;Test message 2\r\n";

        var prov = new ErrorCodeSetProvider();

        prov.Add(data);

        // Act  
        var result = prov.GetTranslations();

        // Assert
        Assert.That(result.Count, Is.EqualTo(2));

        var item1 = result[0];
        Assert.That(item1.Identifier, Is.EqualTo("Code1"));
        Assert.That(item1.Message, Is.EqualTo("Test message 1"));

        var item2 = result[1];
        Assert.That(item2.Identifier, Is.EqualTo("Code2"));
        Assert.That(item2.Message, Is.EqualTo("Test message 2"));

    }
}