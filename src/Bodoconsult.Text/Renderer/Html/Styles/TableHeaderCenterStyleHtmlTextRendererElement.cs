// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TableHeaderCenterStyle"/> instances
/// </summary>
public class TableHeaderCenterStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderCenterStyle _tableHeaderStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderCenterStyleHtmlTextRendererElement(TableHeaderCenterStyle tableHeaderStyle): base(tableHeaderStyle)
    {
        _tableHeaderStyle = tableHeaderStyle;
        ClassName = "TableCenterHeaderStyle";
    }
}