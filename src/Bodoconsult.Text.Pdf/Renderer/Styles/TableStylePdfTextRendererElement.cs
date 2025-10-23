// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TableStyle"/> instances
/// </summary>
public class TableStylePdfTextRendererElement : PdfStyleTextRendererElementBase
{
    private readonly TableStyle _tableStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableStylePdfTextRendererElement(TableStyle tableStyle)
    {
        _tableStyle = tableStyle;
        ClassName = "TableStyle";
    }
}