// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Heading2"/> instances
/// </summary>
public class Heading2HtmlTextRendererElement : HeadingBaseHtmlTextRendererElement
{
    private readonly Heading2 _heading2;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2HtmlTextRendererElement(Heading2 heading2) : base(heading2)
    {
        _heading2 = heading2;
        ClassName = heading2.StyleName;
        TagToUse = "h2";
    }
}