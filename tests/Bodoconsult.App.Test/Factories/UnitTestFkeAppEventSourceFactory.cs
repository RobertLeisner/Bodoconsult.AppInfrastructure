// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.EventCounters;
using Bodoconsult.App.Factories;

namespace Bodoconsult.App.Test.Factories;

[TestFixture]
internal class UnitTestFakeAppEventSourceFactory
{

    [Test]
    public void TestCreateInstance()
    {
        // Arrange 
        var f = new FakeAppEventSourceFactory();

        // Act  
        var inst = f.CreateInstance();

        // Assert
        Assert.That(inst, Is.Not.Null);
        Assert.That(inst, Is.TypeOf(typeof(FakeAppEventSource)));

    }
        
}