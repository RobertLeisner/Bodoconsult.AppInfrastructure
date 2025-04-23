// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using Bodoconsult.App.ExceptionManagement;

namespace Bodoconsult.App.Interfaces;

/// <summary>
/// Interface for exception reply providers to load exception replies in the central exception reply management
/// </summary>
public interface IExceptionReplyProvider
{
    /// <summary>
    /// Exception replies provided by the provider to load in the central exception reply management
    /// </summary>
    public Dictionary<string, ExceptionReplyData> ExceptionReplies { get; }

}