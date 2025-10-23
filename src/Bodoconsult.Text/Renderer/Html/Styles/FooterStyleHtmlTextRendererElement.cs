// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="FooterStyle"/> instances
/// </summary>
public class FooterStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly FooterStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FooterStyleHtmlTextRendererElement(FooterStyle style) : base(style)
    {
        _style = style;
        ClassName = "FooterStyle";
    }
}