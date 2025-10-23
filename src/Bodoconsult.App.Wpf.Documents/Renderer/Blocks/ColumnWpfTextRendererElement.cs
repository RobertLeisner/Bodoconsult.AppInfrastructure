// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Column"/> instances
/// </summary>
public class ColumnWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly Column _column;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ColumnWpfTextRendererElement(Column column) : base(column)
    {
        _column = column;
        ClassName = "ColumnStyle";
    }
}