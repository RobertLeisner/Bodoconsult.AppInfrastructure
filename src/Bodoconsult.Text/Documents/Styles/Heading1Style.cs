// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Heading1"/> instances
/// </summary>
public class Heading1Style : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading1Style()
    {
        TagToUse = "Heading1Style";
        Name = TagToUse;
        BorderBrush = new SolidColorBrush(Styleset.DefaultColor);
        BorderThickness.Bottom = 2 * Styleset.DefaultBorderWidth;
        BorderThickness.Top = 2 * Styleset.DefaultBorderWidth;
        Margins.Top = 4 * Styleset.DefaultFontSize;
        Margins.Bottom = 1 * Styleset.DefaultFontSize;
        Paddings.Top = Styleset.DefaultPaddingWidth;
        Paddings.Bottom = Styleset.DefaultPaddingWidth;
        FontSize = Styleset.DefaultFontSize + 6;
        Bold = true;
        PageBreakBefore = true;
        KeepWithNextParagraph = true;
    }
}