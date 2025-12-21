// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="Heading3Style"/> instances
/// </summary>
public class Heading3StyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly Heading3Style _heading3Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3StyleDocxTextRendererElement(Heading3Style heading3Style) : base(heading3Style)
    {
        _heading3Style = heading3Style;
        ClassName = "Heading3Style";
    }
}