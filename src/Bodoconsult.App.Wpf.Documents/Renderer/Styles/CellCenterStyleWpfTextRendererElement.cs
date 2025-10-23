// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="CellCenterStyle"/> instances
/// </summary>
public class CellCenterStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly CellCenterStyle _cellCenterStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellCenterStyleWpfTextRendererElement(CellCenterStyle cellCenterStyle) : base(cellCenterStyle)
    {
        _cellCenterStyle = cellCenterStyle;
        ClassName = "CellCenterStyle";
        
    }
}