// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="Toc5Style"/> instances
/// </summary>
public class Toc5StyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly Toc5Style _toc5Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc5StyleHtmlTextRendererElement(Toc5Style toc5Style) : base(toc5Style)
    {
        _toc5Style = toc5Style;
        ClassName = "Toc5Style";
    }
}