// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Pdf.PdfSharp;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bodoconsult.Pdf.Extensions;

/// <summary>
/// Extension methods for <see cref="DataTable"/> instances
/// </summary>
public static class DataTableExtensions
{

    /// <summary>
    /// Enumerate all rows
    /// </summary>
    /// <param name="table">Current data table</param>
    /// <returns>Enumerable list of rows</returns>
    public static IEnumerable<DataRow> EnumerateRows(this DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            yield return row;
        }
    }

    /// <summary>
    /// Enumerate all colums
    /// </summary>
    /// <param name="table">Current data table</param>
    /// <returns>Enumerable list of columns</returns>
    public static IEnumerable<DataColumn> EnumerateColumns(this DataTable table)
    {
        foreach (DataColumn column in table.Columns)
        {
            yield return column;
        }
    }

    /// <summary>
    /// Convert a <see cref="DataTable"/> to a <see cref="PdfTable"/>
    /// </summary>
    /// <param name="dt">Current <see cref="DataTable"/> to convert</param>
    /// <returns>Resulting <see cref="PdfTable"/> instance</returns>
    public static PdfTable ToPdfTable(this DataTable dt)
    {
        var result = new PdfTable();

        foreach (DataColumn column in dt.Columns)
        {
            var col = new PdfColumn(column.ColumnName)
            {
                TextAlignment = GetAlignment(column.DataType),
                MaxLength = column.ColumnName.Length,
            };

            result.Columns.Add(col);
        }

        foreach (DataRow dataRow in dt.Rows)
        {
            var row = new PdfRow();

            for (var index = 0; index < dataRow.ItemArray.Length; index++)
            {
                var column = result.Columns[index];
                var dataCells = dataRow.ItemArray[index];

                var value = dataCells == null ? string.Empty : dataCells.ToString() ?? string.Empty;
                if (value.Length > column.MaxLength)
                {
                    column.MaxLength = value.Length;
                }
                row.Cells.Add(new PdfCell(value));
            }

            result.Rows.Add(row);
        }

        return result;
    }

    /// <summary>
    /// Get the alignment for a datatype
    /// </summary>
    /// <param name="type">Datatype</param>
    /// <returns>Alignment</returns>
    public static PdfTextAlignment GetAlignment(Type type)
    {
        // Right aligned
        if (type == typeof(double) || type == typeof(float) ||
            type == typeof(short) || type == typeof(int) ||
            type == typeof(long) || type == typeof(Int128) ||
            type == typeof(byte))
        {
            return PdfTextAlignment.Right;
        }

        // Centered aligned
        if (type == typeof(bool) || type == typeof(DateTime))
        {
            return PdfTextAlignment.Center;
        }

        // Default: left aligned
        return PdfTextAlignment.Left;
    }
}