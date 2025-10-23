// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Paragraph"/> instances
/// </summary>
public class ParagraphHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Paragraph _paragraph;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphHtmlTextRendererElement(Paragraph paragraph) : base(paragraph)
    {
        _paragraph = paragraph;
        ClassName = paragraph.StyleName;
    }
}