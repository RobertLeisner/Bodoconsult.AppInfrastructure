// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TocSectionStyle"/> instances
/// </summary>
public class TocSectionStyleHtmlTextRendererElement : HtmlPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tocSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionStyleHtmlTextRendererElement(TocSectionStyle tocSectionStyle) : base(tocSectionStyle)
    {
        _tocSectionStyle = tocSectionStyle;
        ClassName = "TocSectionStyle";
    }
}