// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Toe"/> instances
/// </summary>
public class ToeHtmlTextRendererElement : HtmlLinkTextRendererElementBase
{
    private readonly Toe _toe;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeHtmlTextRendererElement(Toe toe) : base(toe)
    {
        _toe = toe;
        ClassName = toe.StyleName;
    }
}