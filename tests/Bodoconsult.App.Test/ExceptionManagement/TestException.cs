// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Test.ExceptionManagement;

/// <summary>
/// Exceptions used for usermanagement
/// </summary>
public class TestException : Exception, IExceptionWithErrorCode
{
    public TestException(string message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

    public TestException(string message, int errorCode, Exception e) : base(message, e)
    {
        ErrorCode = errorCode;
    }


    public int ErrorCode { get;  }

}