// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Tot"/> instances
/// </summary>
public class TotStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TotStyle()
    {
        TagToUse = "TotStyle";
        Name = TagToUse;
        Margins.Left = 0;
        FontSize = Styleset.DefaultFontSize - 2;
    }
}