// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Heading4"/> instances
/// </summary>
public class Heading4HtmlTextRendererElement : HeadingBaseHtmlTextRendererElement
{
    private readonly Heading4 _heading4;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading4HtmlTextRendererElement(Heading4 heading4) : base(heading4)
    {
        _heading4 = heading4;
        ClassName = heading4.StyleName;
        TagToUse = "h4";
    }
}