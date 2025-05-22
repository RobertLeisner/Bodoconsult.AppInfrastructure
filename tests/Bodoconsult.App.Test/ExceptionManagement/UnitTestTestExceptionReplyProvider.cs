// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

namespace Bodoconsult.App.Test.ExceptionManagement;

[TestFixture]
internal class UnitTestTestExceptionReplyProvider
{


    [Test]
    public void TestCtor()
    {
        // Arrange 

        // Act  
        var p = new TestExceptionReplyProvider();

        // Assert
        Assert.That(p.ExceptionReplies, Is.Not.Null);

    }
        

}