// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Toc1"/> instances
/// </summary>
public class Toc1HtmlTextRendererElement : HtmlLinkTextRendererElementBase
{
    private readonly Toc1 _toc1;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1HtmlTextRendererElement(Toc1 toc1) : base(toc1)
    {
        _toc1 = toc1;
        ClassName = toc1.StyleName;
    }
}

