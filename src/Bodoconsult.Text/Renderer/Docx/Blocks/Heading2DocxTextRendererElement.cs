// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Heading2"/> instances
/// </summary>
public class Heading2DocxTextRendererElement : HeadingBaseDocxTextRendererElement
{
    private readonly Heading2 _heading2;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2DocxTextRendererElement(Heading2 heading2) : base(heading2)
    {
        _heading2 = heading2;
        ClassName = heading2.StyleName;
    }
}