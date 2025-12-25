// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Pdf.Styles;

/// <summary>
/// PDF rendering element for <see cref="TableHeaderRightStyle"/> instances
/// </summary>
public class TableHeaderRightStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TableHeaderRightStyle _tableHeaderRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHeaderRightStylePdfTextRendererElement(TableHeaderRightStyle tableHeaderRightStyle) : base(tableHeaderRightStyle)
    {
        _tableHeaderRightStyle = tableHeaderRightStyle;
        ClassName = "TableHeaderRightStyle";
    }
}