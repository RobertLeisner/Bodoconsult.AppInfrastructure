// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="CitationSourceStyle"/> instances
/// </summary>
public class CitationSourceStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly CitationSourceStyle _citationSourceStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationSourceStyleHtmlTextRendererElement(CitationSourceStyle citationSourceStyle) : base(citationSourceStyle)
    {
        _citationSourceStyle = citationSourceStyle;
        ClassName = "CitationSourceStyle";
    }
}