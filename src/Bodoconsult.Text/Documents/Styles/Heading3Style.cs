// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Heading3"/> instances
/// </summary>
public class Heading3Style : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3Style()
    {
        TagToUse = "Heading3Style";
        Name = TagToUse;
        FontSize = Styleset.DefaultFontSize + 2;
        Bold = true;
        Margins.Top = 2 * Styleset.DefaultFontSize;
        Paddings.Top = Styleset.DefaultPaddingWidth;
        Paddings.Bottom = Styleset.DefaultPaddingWidth;
        KeepWithNextParagraph = true;
    }
}