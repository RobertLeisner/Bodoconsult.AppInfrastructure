// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="CellLeftStyle"/> instances
/// </summary>
public class CellLeftStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly CellLeftStyle _cellLeftStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellLeftStyleHtmlTextRendererElement(CellLeftStyle cellLeftStyle) : base(cellLeftStyle)
    {
        _cellLeftStyle = cellLeftStyle;
        ClassName = "CellLeftStyle";
    }
}