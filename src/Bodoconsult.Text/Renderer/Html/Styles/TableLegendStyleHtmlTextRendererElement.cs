// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TableLegendStyle"/> instances
/// </summary>
public class TableLegendStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly TableLegendStyle _tableLegendStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableLegendStyleHtmlTextRendererElement(TableLegendStyle table) : base(table)
    {
        _tableLegendStyle = table;
        ClassName = "TableLegendStyle";
    }
}