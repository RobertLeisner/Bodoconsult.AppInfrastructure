// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Pdf.Styles;

/// <summary>
/// PDF rendering element for <see cref="TableLegendStyle"/> instances
/// </summary>
public class TableLegendStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TableLegendStyle _tableLegendStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableLegendStylePdfTextRendererElement(TableLegendStyle table) : base(table)
    {
        _tableLegendStyle = table;
        ClassName = "TableLegendStyle";
    }
}