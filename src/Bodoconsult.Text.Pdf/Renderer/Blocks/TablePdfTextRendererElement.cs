﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Pdf.PdfSharp;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Pdf.Helpers;
using System.Collections.Generic;
using System.Text;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Table"/> instances
/// </summary>
public class TablePdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly Table _table;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TablePdfTextRendererElement(Table table) : base(table)
    {
        _table = table;
        ClassName = "TableStyle";
    }


    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {

        var dt = new PdfTable();

        var sb = new StringBuilder();

        var childs = new List<Inline>();
        if (!string.IsNullOrEmpty(_table.CurrentPrefix))
        {
            childs.Add(new Span(_table.CurrentPrefix));
        }
        childs.AddRange(_table.ChildInlines);


        PdfDocumentRendererHelper.RenderBlockInlinesToStringForPdf(renderer, childs, sb);
        var legend = sb.ToString();

        foreach (var column in _table.Columns)
        {
            var col = new PdfColumn(column.Name);

            switch (DocumentRendererHelper.GetAlignment(column.DataType))
            {
                case "Center":
                    col.TextAlignment = PdfTextAlignment.Center;
                    break;
                case "Right":
                    col.TextAlignment = PdfTextAlignment.Right;
                    break;
                default:
                    col.TextAlignment = PdfTextAlignment.Left;
                    break;
            }

            col.MaxLength = column.MaxLength;

            dt.Columns.Add(col);
        }


        foreach (var dataRow in _table.Rows)
        {
            var row = new PdfRow();


            foreach (var cell in dataRow.Cells)
            {
                sb.Clear();
                PdfDocumentRendererHelper.RenderBlockInlinesToStringForPdf(renderer, cell.ChildInlines, sb);

                var pdfCell = new PdfCell(sb.ToString());
                row.Cells.Add(pdfCell);
            }

            dt.Rows.Add(row);
        }

        renderer.PdfDocument.AddTable(dt, legend, _table.TagName);
    }
}