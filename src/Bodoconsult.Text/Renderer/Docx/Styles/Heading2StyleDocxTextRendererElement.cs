// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="Heading2Style"/> instances
/// </summary>
public class Heading2StyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly Heading2Style _heading2Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2StyleDocxTextRendererElement(Heading2Style heading2Style) : base(heading2Style)
    {
        _heading2Style = heading2Style;
        ClassName = "Heading2Style";
    }
}