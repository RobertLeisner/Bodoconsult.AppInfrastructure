// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="HeaderStyle"/> instances
/// </summary>
public class HeaderStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly HeaderStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public HeaderStyleHtmlTextRendererElement(HeaderStyle style) : base(style)
    {
        _style = style;
        ClassName = "HeaderStyle";
    }
}