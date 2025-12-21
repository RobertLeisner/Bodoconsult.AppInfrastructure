// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="HeaderStyle"/> instances
/// </summary>
public class HeaderStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly HeaderStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public HeaderStyleDocxTextRendererElement(HeaderStyle style) : base(style)
    {
        _style = style;
        ClassName = "HeaderStyle";
    }
}