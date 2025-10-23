// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Tof"/> instances
/// </summary>
public class TofStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TofStyle()
    {
        TagToUse = "TofStyle";
        Name = TagToUse;
        Margins.Left = 0;
        FontSize = Styleset.DefaultFontSize - 2;
    }
}