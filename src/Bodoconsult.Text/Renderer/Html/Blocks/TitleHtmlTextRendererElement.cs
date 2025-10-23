// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Title"/> instances
/// </summary>
public class TitleHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Title _title;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TitleHtmlTextRendererElement(Title title) : base(title)
    {
        _title = title;
        ClassName = title.StyleName;
    }
}