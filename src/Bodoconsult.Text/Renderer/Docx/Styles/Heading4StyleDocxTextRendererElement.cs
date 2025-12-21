// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="Heading4Style"/> instances
/// </summary>
public class Heading4StyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly Heading4Style _heading4Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading4StyleDocxTextRendererElement(Heading4Style heading4Style) : base(heading4Style)
    {
        _heading4Style = heading4Style;
        ClassName = "Heading4Style";
    }
}