// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Table"/> instances
/// </summary>
public class TableHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Table _table;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableHtmlTextRendererElement(Table table) : base(table)
    {
        _table = table;
        ClassName = "TableStyle";
        TagToUse = "table";
    }


    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();

        if (string.IsNullOrEmpty(LocalCss))
        {
            renderer.Content.AppendLine($"<{TagToUse} class=\"{ClassName}\">");
        }
        else
        {
            renderer.Content.AppendLine($"<{TagToUse} class=\"{ClassName}\" style=\"{LocalCss}\">");
        }

        // Header row
        AddHeaderRow(renderer, _table);


        // Rows
        DocumentRendererHelper.RenderRowsToHtml(renderer, _table.Rows);

        sb.Append($"</{TagToUse}>{Environment.NewLine}");

        // Legend
        sb.Append($"<p class=\"TableLegendStyle\">{Environment.NewLine}");
        sb.Append($"<a name=\"{_table.TagName}\" />");

        var childs = new List<Inline>();

        if (!string.IsNullOrEmpty(_table.CurrentPrefix))
        {
            childs.Add(new Span(_table.CurrentPrefix));
        }

        childs.AddRange(_table.ChildInlines);

        DocumentRendererHelper.RenderInlineChildsToHtml(renderer, sb, childs);
        sb.Append($"</p>{Environment.NewLine}");

        renderer.Content.Append(sb);
    }

    private static void AddHeaderRow(ITextDocumentRenderer renderer, Table table)
    {
        renderer.Content.AppendLine("<tr class=\"RowStyle\">");

        foreach (var column in table.Columns)
        {
            renderer.Content.AppendLine($"<th class=\"TableHeader{DocumentRendererHelper.GetAlignment(column.DataType)}Style\">{column.Name}</th>");
        }

        renderer.Content.AppendLine("</tr>");
    }
}