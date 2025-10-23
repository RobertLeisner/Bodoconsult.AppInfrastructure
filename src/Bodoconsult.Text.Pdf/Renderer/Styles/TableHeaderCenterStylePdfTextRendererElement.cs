// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TableHeaderCenterStyle"/> instances
/// </summary>
public class TableHeaderCenterStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderCenterStyle _tableHeaderStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderCenterStylePdfTextRendererElement(TableHeaderCenterStyle tableHeaderStyle): base(tableHeaderStyle)
    {
        _tableHeaderStyle = tableHeaderStyle;
        ClassName = "TableCenterHeaderStyle";
    }
}