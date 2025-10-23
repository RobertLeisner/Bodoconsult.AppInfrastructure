// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="CellRightStyle"/> instances
/// </summary>
public class CellRightStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly CellRightStyle _cellRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellRightStylePdfTextRendererElement(CellRightStyle cellRightStyle) : base(cellRightStyle)
    {
        _cellRightStyle = cellRightStyle;
        ClassName = "CellRightStyle";
    }
}