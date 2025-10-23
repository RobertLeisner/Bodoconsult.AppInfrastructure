// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Heading1"/> instances
/// </summary>
public class Heading1HtmlTextRendererElement : HeadingBaseHtmlTextRendererElement
{
    private readonly Heading1 _heading1;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading1HtmlTextRendererElement(Heading1 heading1) : base(heading1)
    {
        _heading1 = heading1;
        ClassName = heading1.StyleName;
        TagToUse = "h1";
    }
}