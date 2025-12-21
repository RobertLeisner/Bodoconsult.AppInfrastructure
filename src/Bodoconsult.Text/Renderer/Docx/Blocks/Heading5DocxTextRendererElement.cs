// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Heading5"/> instances
/// </summary>
public class Heading5DocxTextRendererElement : HeadingBaseDocxTextRendererElement
{
    private readonly Heading5 _heading5;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading5DocxTextRendererElement(Heading5 heading5) : base(heading5)
    {
        _heading5 = heading5;
        ClassName = heading5.StyleName;
    }
}