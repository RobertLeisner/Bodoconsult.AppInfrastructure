// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="CellRightStyle"/> instances
/// </summary>
public class CellRightStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly CellRightStyle _cellRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellRightStyleDocxTextRendererElement(CellRightStyle cellRightStyle) : base(cellRightStyle)
    {
        _cellRightStyle = cellRightStyle;
        ClassName = "CellRightStyle";
    }
}