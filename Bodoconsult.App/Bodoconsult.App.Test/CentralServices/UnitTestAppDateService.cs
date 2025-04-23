// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.CentralServices;

namespace Bodoconsult.App.Test.CentralServices;

[TestFixture]
internal class UnitTestAppDateService
{

    [Test]
    public void TestNow()
    {
        // Arrange 
        var service = new AppDateService();

        // Act  
        var result = service.Now;

        // Assert
        Assert.That(result, Is.GreaterThan(DateTime.MinValue));

    }
        
}