// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Toe"/> instances
/// </summary>
public class ToeStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeStyle()
    {
        TagToUse = "ToeStyle";
        Name = TagToUse;
        Margins.Left = 0;
        FontSize = Styleset.DefaultFontSize - 2;
    }
}