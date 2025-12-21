// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="CellLeftStyle"/> instances
/// </summary>
public class CellLeftStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly CellLeftStyle _cellLeftStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellLeftStyleDocxTextRendererElement(CellLeftStyle cellLeftStyle) : base(cellLeftStyle)
    {
        _cellLeftStyle = cellLeftStyle;
        ClassName = "CellLeftStyle";
    }
}