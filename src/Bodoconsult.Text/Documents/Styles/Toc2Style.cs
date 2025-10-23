// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Toc2"/> instances
/// </summary>
public class Toc2Style : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc2Style()
    {
        TagToUse = "Toc2Style";
        Name = TagToUse;
        Margins.Left = 1 * Styleset.DefaultFontSize;
        FontSize = Styleset.DefaultFontSize;
    }
}