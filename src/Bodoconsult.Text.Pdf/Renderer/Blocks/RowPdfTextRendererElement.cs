// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Row"/> instances
/// </summary>
public class RowPdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly Row _row;

    /// <summary>
    /// Default ctor
    /// </summary>
    public RowPdfTextRendererElement(Row row) : base(row)
    {
        _row = row;
        ClassName = "RowStyle";
    }
}