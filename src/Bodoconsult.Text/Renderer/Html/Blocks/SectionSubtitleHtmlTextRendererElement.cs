// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="SectionSubtitle"/> instances
/// </summary>
public class SectionSubtitleHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly SectionSubtitle _sectionSubtitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitleHtmlTextRendererElement(SectionSubtitle sectionSubtitle) : base(sectionSubtitle)
    {
        _sectionSubtitle = sectionSubtitle;
        ClassName = sectionSubtitle.StyleName;
    }
}