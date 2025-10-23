// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="CellLeftStyle"/> instances
/// </summary>
public class CellLeftStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly CellLeftStyle _cellLeftStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellLeftStyleWpfTextRendererElement(CellLeftStyle cellLeftStyle) : base(cellLeftStyle)
    {
        _cellLeftStyle = cellLeftStyle;
        ClassName = "CellLeftStyle";
    }
}