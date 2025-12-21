// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="FooterStyle"/> instances
/// </summary>
public class FooterStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly FooterStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FooterStyleDocxTextRendererElement(FooterStyle style) : base(style)
    {
        _style = style;
        ClassName = "FooterStyle";
    }
}