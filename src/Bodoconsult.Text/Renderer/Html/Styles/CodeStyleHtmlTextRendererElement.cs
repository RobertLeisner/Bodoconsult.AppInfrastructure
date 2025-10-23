// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="CodeStyle"/> instances
/// </summary>
public class CodeStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly CodeStyle _style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CodeStyleHtmlTextRendererElement(CodeStyle style) : base(style)
    {
        _style = style;
        ClassName = "CodeStyle";
    }
}