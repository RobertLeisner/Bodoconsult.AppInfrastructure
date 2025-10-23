// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for TOF heading instances
/// </summary>
public class TofHeadingStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TofHeadingStyle()
    {
        TagToUse = "TofHeadingStyle";
        Name = TagToUse;
        BorderBrush = new SolidColorBrush(Styleset.DefaultColor);
        BorderThickness.Bottom = 2 * Styleset.DefaultBorderWidth;
        BorderThickness.Top = 2 * Styleset.DefaultBorderWidth;
        Margins.Top = 4 * Styleset.DefaultFontSize;
        Margins.Bottom = 1 * Styleset.DefaultFontSize;
        Paddings.Top = Styleset.DefaultPaddingWidth;
        Paddings.Bottom = Styleset.DefaultPaddingWidth;
        Bold = true;
        FontSize = Styleset.DefaultFontSize + 2;
    }
}