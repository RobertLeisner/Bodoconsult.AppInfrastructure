// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Defines the line spacing rules available
/// </summary>
public enum LineSpacingRuleEnum
{
    /// <summary>
    /// Automatically determined line height
    /// </summary>
    Auto,
    /// <summary>
    /// Exact line height
    /// </summary>
    Exact,
    /// <summary>
    /// Minimum Line Height
    /// </summary>
    AtLeast
}