// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="Heading5Style"/> instances
/// </summary>
public class Heading5StyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly Heading5Style _heading5Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading5StyleDocxTextRendererElement(Heading5Style heading5Style) : base(heading5Style)
    {
        _heading5Style = heading5Style;
        ClassName = "Heading5Style";
    }
}