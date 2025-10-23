// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.Test.TestDocumentation;

/// <summary>
/// The priority of a test as importance for the whole
/// </summary>
public enum TestPriority
{
    /// <summary>
    /// Normal priority
    /// </summary>
    Normal = 1,
    /// <summary>
    /// Low priority
    /// </summary>
    Low = 0,
    /// <summary>
    /// High priority
    /// </summary>
    High = 2,
    /// <summary>
    /// Ignore the test
    /// </summary>
    Ignore = -1,
    /// <summary>
    /// Ignore the test if an error has happened
    /// </summary>
    IgnoreIfError = -2
}