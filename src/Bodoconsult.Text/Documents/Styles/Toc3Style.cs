// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Toc3"/> instances
/// </summary>
public class Toc3Style : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc3Style()
    {
        TagToUse = "Toc3Style";
        Name = TagToUse;
        Margins.Left = 2 * Styleset.DefaultFontSize;
    }
}