// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Cell"/> instances
/// </summary>
public class CellWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly Cell _cell;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellWpfTextRendererElement(Cell cell) : base(cell)
    {
        _cell = cell;
        ClassName = GetClassName(cell);
    }

    private string GetClassName(Cell cell)
    {
        if (cell.Column.DataType == typeof(double))
        {
            return "CellRightStyle";
        }
        if (cell.Column.DataType == typeof(float))
        {
            return "CellRightStyle";
        }
        if (cell.Column.DataType == typeof(short))
        {
            return "CellRightStyle";
        }
        if (cell.Column.DataType == typeof(int))
        {
            return "CellRightStyle";
        }
        if (cell.Column.DataType == typeof(long))
        {
            return "CellRightStyle";
        }
        if (cell.Column.DataType == typeof(Int128))
        {
            return "CellRightStyle";
        }
        if (cell.Column.DataType == typeof(byte))
        {
            return "CellRightStyle";
        }
        if (cell.Column.DataType == typeof(bool))
        {
            return "CellCenterStyle";
        }
        if (cell.Column.DataType == typeof(DateTime))
        {
            return "CellCenterStyle";
        }

        // ToDo: Other alignments
        return "CellLeftStyle";
    }
}