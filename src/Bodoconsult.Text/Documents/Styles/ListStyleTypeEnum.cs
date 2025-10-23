// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// List style type enum like bullet, square
/// </summary>
public enum ListStyleTypeEnum
{
    /// <summary>
    /// Disc or bullet
    /// </summary>
    Disc,
    /// <summary>
    /// Circle
    /// </summary>
    Circle,
    /// <summary>
    /// Square
    /// </summary>
    Square,
    /// <summary>
    /// Decimal
    /// </summary>
    Decimal,
    /// <summary>
    /// Decimal with leading zeros
    /// </summary>
    DecimalLeadingZero,
    /// <summary>
    /// Upper roman numbers
    /// </summary>
    UpperRoman,
    /// <summary>
    /// Lower roman numbers
    /// </summary>
    LowerRoman,
    /// <summary>
    /// Upper letters from alphabet
    /// </summary>
    UpperLatin,
    /// <summary>
    /// Upper letters from alphabet
    /// </summary>
    LowerLatin,
    /// <summary>
    /// Customized. If choosing this value, set a char for the style to use for list
    /// </summary>
    Customized
}