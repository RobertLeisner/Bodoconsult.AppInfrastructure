// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.ExceptionManagement;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Test.ExceptionManagement;

[TestFixture]
internal class UnitTestExceptionReplyBuilder
{

    [Test]
    public void TestCtor()
    {
        // Arrange 

        // Act  
        var e = new ExceptionReplyBuilder();

        // Assert
        Assert.That(e.ExceptionReplies, Is.Not.Null);
        Assert.That(!e.ExceptionReplies.Any());

    }

    [Test]
    public void TestAddProvider()
    {
        // Arrange 
        IExceptionReplyProvider p = new TestExceptionReplyProvider();

        IExceptionReplyBuilder e = new ExceptionReplyBuilder();
            
        // Act  
        e.AddProvider(p);

        // Assert
        Assert.That(e.ExceptionReplies.Any());

    }


    [Test]
    public void TestCreateReply()
    {
        // Arrange 
        IExceptionReplyProvider p = new TestExceptionReplyProvider();

        IExceptionReplyBuilder e = new ExceptionReplyBuilder();
 
        e.AddProvider(p);

        var ex = new ArgumentNullException();

        // Act  
        var reply = e.CreateReply(ex);

        // Assert
        Assert.That(reply, Is.Not.Null);

    }

    [Test]
    public void TestCreateReplyExceptionWithErrorCode()
    {
        // Arrange 
        const int errorCode = 12345;

        IExceptionReplyProvider p = new TestExceptionReplyProvider();

        IExceptionReplyBuilder e = new ExceptionReplyBuilder();

        e.AddProvider(p);

        var ex = new TestException("Hallo", errorCode);

        // Act  
        var reply = e.CreateReply(ex);

        // Assert
        Assert.That(reply, Is.Not.Null);
        Assert.That(reply.ErrorCode, Is.EqualTo(errorCode));
    }
}