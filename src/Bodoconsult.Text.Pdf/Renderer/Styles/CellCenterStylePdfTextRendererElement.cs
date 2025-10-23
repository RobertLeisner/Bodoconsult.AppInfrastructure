// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="CellCenterStyle"/> instances
/// </summary>
public class CellCenterStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly CellCenterStyle _cellCenterStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellCenterStylePdfTextRendererElement(CellCenterStyle cellCenterStyle) : base(cellCenterStyle)
    {
        _cellCenterStyle = cellCenterStyle;
        ClassName = "CellCenterStyle";
        
    }
}