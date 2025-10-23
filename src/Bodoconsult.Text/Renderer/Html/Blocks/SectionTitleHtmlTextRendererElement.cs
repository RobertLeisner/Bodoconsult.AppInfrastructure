// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="SectionTitle"/> instances
/// </summary>
public class SectionTitleHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly SectionTitle _sectionTitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleHtmlTextRendererElement(SectionTitle sectionTitle) : base(sectionTitle)
    {
        _sectionTitle = sectionTitle;
        ClassName = sectionTitle.StyleName;
    }
}