// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Exceptions;

/// <summary>
/// Exception for license management
/// </summary>
public class LicenseMissingException : Exception
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public LicenseMissingException() : base("License is missing!")
    {

    }

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="message"></param>
    public LicenseMissingException(string message) : base(message)
    {

    }

}