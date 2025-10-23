// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ToeStyle"/> instances
/// </summary>
public class ToeStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly ToeStyle _toeStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeStyleHtmlTextRendererElement(ToeStyle toeStyle) : base(toeStyle)
    {
        _toeStyle = toeStyle;
        ClassName = "TotStyle";
    }
}