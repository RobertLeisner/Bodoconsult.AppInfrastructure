// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Generic;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Table"/> instances
/// </summary>
public class TableDocxTextRendererElement : DocxTextRendererElementBase
{
    private readonly Table _table;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableDocxTextRendererElement(Table table) : base(table)
    {
        _table = table;
        ClassName = "TableStyle";
    }


    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {

        //var dt = new DocxTable();

        //var sb = new StringBuilder();

        //var childs = new List<Inline>();
        //if (!string.IsNullOrEmpty(_table.CurrentPrefix))
        //{
        //    childs.Add(new Span(_table.CurrentPrefix));
        //}
        //childs.AddRange(_table.ChildInlines);


        //DocxDocumentRendererHelper.RenderBlockInlinesToStringForDocx(renderer, childs, sb);
        //var legend = sb.ToString();

        //foreach (var column in _table.Columns)
        //{
        //    var col = new DocxColumn(column.Name);

        //    switch (DocumentRendererHelper.GetAlignment(column.DataType))
        //    {
        //        case "Center":
        //            col.TextAlignment = DocxTextAlignment.Center;
        //            break;
        //        case "Right":
        //            col.TextAlignment = DocxTextAlignment.Right;
        //            break;
        //        default:
        //            col.TextAlignment = DocxTextAlignment.Left;
        //            break;
        //    }

        //    col.MaxLength = column.MaxLength;

        //    dt.Columns.Add(col);
        //}


        //foreach (var dataRow in _table.Rows)
        //{
        //    var row = new DocxRow();


        //    foreach (var cell in dataRow.Cells)
        //    {
        //        sb.Clear();
        //        DocxDocumentRendererHelper.RenderBlockInlinesToStringForDocx(renderer, cell.ChildInlines, sb);

        //        var DocxCell = new DocxCell(sb.ToString());
        //        row.Cells.Add(DocxCell);
        //    }

        //    dt.Rows.Add(row);
        //}

        //renderer.DocxDocument.AddTable(dt, legend, _table.TagName);
    }
}