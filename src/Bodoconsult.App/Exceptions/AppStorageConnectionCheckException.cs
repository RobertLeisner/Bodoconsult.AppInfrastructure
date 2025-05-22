// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Exceptions;

/// <summary>
/// Exception thrown if a app storage connection check fails
/// </summary>
public class AppStorageConnectionCheckException : Exception
{

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="message"></param>
    public AppStorageConnectionCheckException(string message) : base(message)
    { }

}