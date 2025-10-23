// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="ParagraphRight"/> instances
/// </summary>
public class ParagraphRightHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly ParagraphRight _paragraphRight;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRightHtmlTextRendererElement(ParagraphRight paragraphRight) : base(paragraphRight)
    {
        _paragraphRight = paragraphRight;
        ClassName = paragraphRight.StyleName;
    }
}