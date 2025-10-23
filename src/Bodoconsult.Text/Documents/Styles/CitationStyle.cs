// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Citation"/> instances
/// </summary>
public class CitationStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationStyle()
    {
        TagToUse = "CitationStyle";
        Name = TagToUse;
        TextAlignment = TextAlignment.Center;
        Margins.Top = 3 * Styleset.DefaultPaddingWidth;
        Margins.Bottom = 0;
        Margins.Left = Styleset.DefaultMarginLeft;
        Margins.Right = Styleset.DefaultMarginRight;
        Italic = true;
        KeepWithNextParagraph = true;
        KeepTogether = true;
    }
}