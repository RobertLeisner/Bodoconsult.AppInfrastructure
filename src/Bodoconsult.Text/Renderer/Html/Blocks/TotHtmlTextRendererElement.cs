// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Tot"/> instances
/// </summary>
public class TotHtmlTextRendererElement : HtmlLinkTextRendererElementBase
{
    private readonly Tot _tot;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotHtmlTextRendererElement(Tot tot) : base(tot)
    {
        _tot = tot;
        ClassName = tot.StyleName;
    }
}