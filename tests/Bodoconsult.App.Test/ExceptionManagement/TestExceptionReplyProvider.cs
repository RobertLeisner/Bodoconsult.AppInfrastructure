// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.ExceptionManagement;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Test.ExceptionManagement;

internal class TestExceptionReplyProvider : IExceptionReplyProvider
{

    public TestExceptionReplyProvider()
    {
        //
        var e = new ExceptionReplyData
        {
            Message =  "Argument may NOT be null!"
        };

        ExceptionReplies.Add(nameof(ArgumentNullException), e);

        //
        e = new ExceptionReplyData
        {
            Message = "Test exception!"
        };

        ExceptionReplies.Add(nameof(TestException), e);

    }

    public Dictionary<string, ExceptionReplyData> ExceptionReplies { get; } = new();
}