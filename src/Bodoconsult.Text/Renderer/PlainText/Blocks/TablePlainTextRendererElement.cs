// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using Bodoconsult.App.Extensions;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Plain text rendering element for <see cref="Table"/> instances
/// </summary>
public class TablePlainTextRendererElement : ITextRendererElement
{
    private readonly Table _table;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TablePlainTextRendererElement(Table table)
    {
        _table = table;
    }


    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();

        // Header row
        renderer.Content.AppendLine("");

        var rowData = new List<List<string>>();

        var row = new List<string>();
        foreach (var column in _table.Columns)
        {
            row.Add(column.Name);
        }

        rowData.Add(row);

        // Rows
        DocumentRendererHelper.RenderRowsToPlain(renderer, _table.Rows, rowData);

        // Get the maximum length of the content for all columns
        GetMaximumLengtOfContent(rowData);

        // Print table
        PrintTable(renderer, rowData, _table);


        // Legend
        var childs = new List<Inline>();

        if (!string.IsNullOrEmpty(_table.CurrentPrefix))
        {
            childs.Add(new Span(_table.CurrentPrefix));
        }

        childs.AddRange(_table.ChildInlines);

        DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, childs);

        renderer.Content.Append(sb);
        renderer.Content.AppendLine("");
    }

    private void GetMaximumLengtOfContent(List<List<string>> rowData)
    {
        foreach (var tableRow in rowData)
        {
            for (var index = 0; index < tableRow.Count; index++)
            {
                var cell = tableRow[index];
                var column = _table.Columns[index];

                if (cell.Length > column.MaxLength)
                {
                    column.MaxLength = cell.Length;
                }
            }
        }
    }

    private static void PrintTable(ITextDocumentRenderer renderer, List<List<string>> rowData, Table table)
    {
        AddLine(renderer, table);

        foreach (var tableRow in rowData)
        {
            renderer.Content.Append('|');
            for (var index = 0; index < tableRow.Count; index++)
            {
                var cell = tableRow[index];
                var column = table.Columns[index];
                renderer.Content.Append($"{GetFormattedString(column, cell)}|");
            }

            renderer.Content.Append(Environment.NewLine);
        }

        AddLine(renderer, table);
    }

    private static void AddLine(ITextDocumentRenderer renderer, Table table)
    {
        renderer.Content.Append('-');

        foreach (var col in table.Columns)
        {
            renderer.Content.Append("-".Repeat(col.MaxLength + 1));
        }

        renderer.Content.Append(Environment.NewLine);
    }

    private static string GetFormattedString(Column column, string value)
    {
        // Right aligned
        if (column.DataType == typeof(double) || column.DataType == typeof(float) || 
            column.DataType == typeof(short) || column.DataType == typeof(int) || 
            column.DataType == typeof(long) || column.DataType == typeof(Int128) || 
            column.DataType == typeof(byte))
        {
            return value.PadLeft(column.MaxLength);
        }

        // Centered aligned
        if (column.DataType == typeof(bool) || column.DataType == typeof(DateTime))
        {
            if (value.Length == column.MaxLength)
            {
                return value;
            }
            
            var length1 = (column.MaxLength -value.Length) / 2;
            var length2 = column.MaxLength - value.Length - length1;

            return length2 <= 0 ? $"{" ".Repeat(length1)}{value}" : $"{" ".Repeat(length1)}{value}{" ".Repeat(length2)}";
        }

        // Default: left aligned
        return value.PadRight(column.MaxLength);
    }
}