// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Toc4"/> instances
/// </summary>
public class Toc4HtmlTextRendererElement : HtmlLinkTextRendererElementBase
{
    private readonly Toc4 _toc4;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc4HtmlTextRendererElement(Toc4 toc4) : base(toc4)
    {
        _toc4 = toc4;
        ClassName = toc4.StyleName;
    }
}