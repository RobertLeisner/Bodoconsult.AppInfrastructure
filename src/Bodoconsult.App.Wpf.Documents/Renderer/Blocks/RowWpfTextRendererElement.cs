// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Row"/> instances
/// </summary>
public class RowWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly Row _row;

    /// <summary>
    /// Default ctor
    /// </summary>
    public RowWpfTextRendererElement(Row row) : base(row)
    {
        _row = row;
        ClassName = "RowStyle";
    }
}