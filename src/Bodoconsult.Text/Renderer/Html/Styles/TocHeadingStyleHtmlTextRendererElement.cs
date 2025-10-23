// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TocHeadingStyle"/> instances
/// </summary>
public class TocHeadingStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly TocHeadingStyle _tocHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocHeadingStyleHtmlTextRendererElement(TocHeadingStyle tocHeadingStyle) : base(tocHeadingStyle)
    {
        _tocHeadingStyle = tocHeadingStyle;
        ClassName = "TocHeadingStyle";
    }
}