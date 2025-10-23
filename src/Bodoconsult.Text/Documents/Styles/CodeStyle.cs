// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="Code"/> instances
/// </summary>
public class CodeStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public CodeStyle()
    {
        TagToUse = "CodeStyle";
        Name = TagToUse;
        FontName = Styleset.DefaultFontNameMonoSpaced;
    }
}