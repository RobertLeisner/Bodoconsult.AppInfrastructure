// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="SectionSubtitle"/> instances
/// </summary>
public class SectionSubtitleStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitleStyle()
    {
        TagToUse = "SectionSubtitleStyle";
        Name = TagToUse;
        FontSize = Styleset.DefaultFontSize + 2;
        Margins.Top = Styleset.DefaultFontSize * 2;
        TextAlignment = TextAlignment.Center;
        Bold = true;
    }
}