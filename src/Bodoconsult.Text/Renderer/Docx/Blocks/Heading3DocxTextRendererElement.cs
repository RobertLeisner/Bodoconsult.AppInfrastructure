// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Heading3"/> instances
/// </summary>
public class Heading3DocxTextRendererElement : HeadingBaseDocxTextRendererElement
{
    private readonly Heading3 _heading3;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3DocxTextRendererElement(Heading3 heading3) : base(heading3)
    {
        _heading3 = heading3;
        ClassName = heading3.StyleName;
    }
}