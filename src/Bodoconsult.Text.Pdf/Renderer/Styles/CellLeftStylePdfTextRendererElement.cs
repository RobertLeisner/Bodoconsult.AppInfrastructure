// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="CellLeftStyle"/> instances
/// </summary>
public class CellLeftStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly CellLeftStyle _cellLeftStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellLeftStylePdfTextRendererElement(CellLeftStyle cellLeftStyle) : base(cellLeftStyle)
    {
        _cellLeftStyle = cellLeftStyle;
        ClassName = "CellLeftStyle";
    }
}