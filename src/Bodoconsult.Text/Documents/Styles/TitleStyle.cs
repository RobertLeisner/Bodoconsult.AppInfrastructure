// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Title"/> instances
/// </summary>
public class TitleStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TitleStyle()
    {
        TagToUse = "TitleStyle";
        Name = TagToUse;
        FontSize = Styleset.DefaultFontSize + 8;
        Margins.Top = Styleset.DefaultFontSize * 4;
        Margins.Bottom = Styleset.DefaultFontSize * 2;
        TextAlignment = TextAlignment.Center;
        Bold = true;
    }
}