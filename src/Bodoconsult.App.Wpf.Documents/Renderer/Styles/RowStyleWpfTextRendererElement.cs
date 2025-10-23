// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="RowStyle"/> instances
/// </summary>
public class RowStyleWpfTextRendererElement : WpfStyleTextRendererElementBase
{
    private readonly RowStyle _rowStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public RowStyleWpfTextRendererElement(RowStyle rowStyle)
    {
        _rowStyle = rowStyle;
        ClassName = "RowStyle";
    }
}