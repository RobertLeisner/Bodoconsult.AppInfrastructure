// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using Bodoconsult.App.CentralServices;

namespace Bodoconsult.App.Test.CentralServices;

[TestFixture]
internal class UnitTestFakeAppDateService
{

    [Test]
    public void TestNow()
    {
        // Arrange 

        var date = DateTime.Now.AddDays(5);
        var service = new FakeAppDateService
        {
            DateTimeToDeliver = date
        };


        // Act  
        var result = service.Now;

        // Assert
        Assert.That(result, Is.EqualTo(date));

    }

}