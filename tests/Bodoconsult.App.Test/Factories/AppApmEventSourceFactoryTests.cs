// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.EventCounters;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Factories;
using Bodoconsult.App.Test.Helpers;

namespace Bodoconsult.App.Test.Factories;

[TestFixture]
internal class AppApmEventSourceFactoryTests
{

    private readonly IAppLoggerProxy _logger = TestHelper.GetFakeAppLoggerProxy();

    [Test]
    public void TestCreateInstance()
    {
        // Arrange
        var f = new AppApmEventSourceFactory(_logger);

        // Act  
        var inst = f.CreateInstance();

        // Assert
        Assert.That(inst, Is.Not.Null);
        Assert.That(inst, Is.TypeOf(typeof(AppApmEventSource)));

    }

}