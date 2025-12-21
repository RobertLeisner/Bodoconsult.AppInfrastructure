// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="CellCenterStyle"/> instances
/// </summary>
public class CellCenterStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly CellCenterStyle _cellCenterStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellCenterStyleDocxTextRendererElement(CellCenterStyle cellCenterStyle) : base(cellCenterStyle)
    {
        _cellCenterStyle = cellCenterStyle;
        ClassName = "CellCenterStyle";
        
    }
}