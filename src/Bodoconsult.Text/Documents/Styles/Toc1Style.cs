// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Toc1"/> instances
/// </summary>
public class Toc1Style : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1Style()
    {
        TagToUse = "Toc1Style";
        Name = TagToUse;
        Margins.Left = 0;
        FontSize = Styleset.DefaultFontSize;
        Bold = true;
    }
}