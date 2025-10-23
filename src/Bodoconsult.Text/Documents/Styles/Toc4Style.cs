// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Toc4"/> instances
/// </summary>
public class Toc4Style : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc4Style()
    {
        TagToUse = "Toc4Style";
        Name = TagToUse;
        Margins.Left = 3 * Styleset.DefaultFontSize;
    }
}