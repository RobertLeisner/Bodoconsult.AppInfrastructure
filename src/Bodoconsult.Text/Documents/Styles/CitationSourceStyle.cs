// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Citation"/> source instances
/// </summary>
public class CitationSourceStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationSourceStyle()
    {
        TagToUse = "CitationSourceStyle";
        Name = TagToUse;
        TextAlignment = TextAlignment.Center;
        Margins.Top = 0;
        Margins.Bottom = Styleset.DefaultPaddingWidth;
        Margins.Left = Styleset.DefaultMarginLeft;
        Margins.Right = Styleset.DefaultMarginRight;
        FontSize = Styleset.DefaultFontSize - 4;
    }
}