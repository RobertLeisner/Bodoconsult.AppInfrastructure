// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace Bodoconsult.Text.Documents;

/// <summary>
/// Style for <see cref="ParagraphJustify"/> instances
/// </summary>
public class ParagraphJustifyStyle : ParagraphStyleBase
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphJustifyStyle()
    {
        TagToUse = "ParagraphJustifyStyle";
        Name = TagToUse;
        TextAlignment = TextAlignment.Justify;
    }
}