// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using System;

namespace Bodoconsult.I18N;

public class I18NException : Exception
{
    public I18NException(string message, Exception innerException = null) : base(message, innerException)
    {
            
    }
}