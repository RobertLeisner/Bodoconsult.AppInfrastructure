// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="CellRightStyle"/> instances
/// </summary>
public class CellRightStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly CellRightStyle _cellRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellRightStyleHtmlTextRendererElement(CellRightStyle cellRightStyle) : base(cellRightStyle)
    {
        _cellRightStyle = cellRightStyle;
        ClassName = "CellRightStyle";
    }
}