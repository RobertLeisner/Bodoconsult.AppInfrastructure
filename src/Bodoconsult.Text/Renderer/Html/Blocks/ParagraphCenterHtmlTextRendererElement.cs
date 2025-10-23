// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="ParagraphCenter"/> instances
/// </summary>
public class ParagraphCenterHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly ParagraphCenter _paragraphCenter;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterHtmlTextRendererElement(ParagraphCenter paragraphCenter) : base(paragraphCenter)
    {
        _paragraphCenter = paragraphCenter;
        ClassName = paragraphCenter.StyleName;
    }
}