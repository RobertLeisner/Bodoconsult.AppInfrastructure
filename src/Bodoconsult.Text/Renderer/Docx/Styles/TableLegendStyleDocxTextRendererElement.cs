// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="TableLegendStyle"/> instances
/// </summary>
public class TableLegendStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly TableLegendStyle _tableLegendStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableLegendStyleDocxTextRendererElement(TableLegendStyle table) : base(table)
    {
        _tableLegendStyle = table;
        ClassName = "TableLegendStyle";
    }
}