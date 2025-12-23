// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.App.Abstractions.Interfaces;

/// <summary>
/// Interface for table styles with basic table properties
/// </summary>
public interface ITypoTableStyle
{
    /// <summary>
    /// Border spacing in pt
    /// </summary>
    int BorderSpacing { get; }

    /// <summary>
    /// Margins in cm
    /// </summary>
    TypoThickness TypoMargins { get; }

    /// <summary>
    /// Border brush
    /// </summary>
    TypoBrush TypoBorderBrush { get; }

    /// <summary>
    /// Current borderline width setting
    /// </summary>
    TypoThickness TypoBorderThickness { get; }

    /// <summary>
    /// Inside the table horizontal border width in cm
    /// </summary>
    double InsideHorizontalBorderWidth { get;  }

    /// <summary>
    /// Inside the table vertical border width in cm
    /// </summary>
    double InsideVerticalBorderWidth { get;  }
}