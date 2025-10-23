// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Cell"/> instances
/// </summary>
public class CellHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Cell _cell;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellHtmlTextRendererElement(Cell cell) : base(cell)
    {
        _cell = cell;
        ClassName = GetClassName(cell);
        TagToUse = "td";
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
        if (cell.Column.DataType == typeof(System.Int128))
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