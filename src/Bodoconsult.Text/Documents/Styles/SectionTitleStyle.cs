// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="SectionTitle"/> instances
/// </summary>
public class SectionTitleStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleStyle()
    {
        TagToUse = "SectionTitleStyle";
        Name = TagToUse;
        TextAlignment = TextAlignment.Center;
        Margins.Top = Styleset.DefaultFontSize * 4;
        FontSize = Styleset.DefaultFontSize + 4;
        Bold = true;
    }
}