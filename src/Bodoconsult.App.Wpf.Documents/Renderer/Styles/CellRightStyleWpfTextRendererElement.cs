// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="CellRightStyle"/> instances
/// </summary>
public class CellRightStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly CellRightStyle _cellRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellRightStyleWpfTextRendererElement(CellRightStyle cellRightStyle) : base(cellRightStyle)
    {
        _cellRightStyle = cellRightStyle;
        ClassName = "CellRightStyle";
    }
}