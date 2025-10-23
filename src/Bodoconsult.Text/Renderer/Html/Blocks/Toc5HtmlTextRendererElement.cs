// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Toc5"/> instances
/// </summary>
public class Toc5HtmlTextRendererElement : HtmlLinkTextRendererElementBase
{
    private readonly Toc5 _toc5;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc5HtmlTextRendererElement(Toc5 toc5) : base(toc5)
    {
        _toc5 = toc5;
        ClassName = toc5.StyleName;
    }
}