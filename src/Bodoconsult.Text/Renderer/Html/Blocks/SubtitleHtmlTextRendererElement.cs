// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Subtitle"/> instances
/// </summary>
public class SubtitleHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Subtitle _subtitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitleHtmlTextRendererElement(Subtitle subtitle) : base(subtitle)
    {
        _subtitle = subtitle;
        ClassName = subtitle.StyleName;
    }
}