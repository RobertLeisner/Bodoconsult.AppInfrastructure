// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Heading2"/> instances
/// </summary>
public class Heading2Style : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2Style()
    {
        TagToUse = "Heading2Style";
        Name = TagToUse;
        BorderBrush = new SolidColorBrush(Styleset.DefaultColor);
        BorderThickness.Bottom = Styleset.DefaultBorderWidth;
        Margins.Top = 1 * Styleset.DefaultFontSize;
        Paddings.Top = Styleset.DefaultPaddingWidth;
        Paddings.Bottom = Styleset.DefaultPaddingWidth;
        FontSize = Styleset.DefaultFontSize + 4;
        Bold = true;
        KeepWithNextParagraph = true;
    }
}