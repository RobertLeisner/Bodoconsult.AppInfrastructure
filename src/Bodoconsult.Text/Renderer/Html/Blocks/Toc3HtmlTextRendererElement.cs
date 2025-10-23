// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Toc3"/> instances
/// </summary>
public class Toc3HtmlTextRendererElement : HtmlLinkTextRendererElementBase
{
    private readonly Toc3 _toc3;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc3HtmlTextRendererElement(Toc3 toc3) : base(toc3)
    {
        _toc3 = toc3;
        ClassName = toc3.StyleName;
    }
}