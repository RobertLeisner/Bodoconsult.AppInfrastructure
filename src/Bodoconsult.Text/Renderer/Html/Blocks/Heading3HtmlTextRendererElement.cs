// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Heading3"/> instances
/// </summary>
public class Heading3HtmlTextRendererElement : HeadingBaseHtmlTextRendererElement
{
    private readonly Heading3 _heading3;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3HtmlTextRendererElement(Heading3 heading3) : base(heading3)
    {
        _heading3 = heading3;
        ClassName = heading3.StyleName;
        TagToUse = "h3";
    }
}