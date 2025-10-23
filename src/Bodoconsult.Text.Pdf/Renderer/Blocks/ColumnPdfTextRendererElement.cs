// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Column"/> instances
/// </summary>
public class ColumnPdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly Column _column;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ColumnPdfTextRendererElement(Column column) : base(column)
    {
        _column = column;
        ClassName = "ColumnStyle";
    }
}