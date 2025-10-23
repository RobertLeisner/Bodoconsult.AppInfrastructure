// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Bodoconsult.App.Abstractions.Helpers;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Table"/> instances
/// </summary>
public class TableRtfTextRendererElement : ITextRendererElement
{
    private readonly Table _table;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TableRtfTextRendererElement(Table table) 
    {
        _table = table;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        var tableStyle = (TableStyle)renderer.Styleset.FindStyle("TableStyle");

        // top margin
        renderer.Content.Append($@"\pard\plain\sb{MeasurementHelper.GetTwipsFromPt(tableStyle.Margins.Top)}\fs6\par");

        //// bottom margin
        //renderer.Content.Append($"");

        renderer.Content.Append(@"\trowd\trhdr\trautofit1\trqc\trpaddfb3\trpaddfr3\trpaddft3\trpaddfl3\trpaddb80\trpaddr80\trpaddt80\trpaddl80");

        ParagraphStyleBase style;
        var sb = new StringBuilder();

        for (var index = 0; index < _table.Columns.Count; index++)
        {
            var column = _table.Columns[index];
            style = (ParagraphStyleBase)renderer.Styleset.FindStyle($"TableHeader{DocumentRendererHelper.GetAlignment(column.DataType)}Style");

            renderer.Content.Append($@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx{index + 1}000");

            sb.Append(@"\intbl\pard\plain");
            sb.Append(RtfHelper.GetFormatSettings(style, renderer.Styleset, true));
            sb.Append($"{{{column.Name}}}\\cell");
        }

        renderer.Content.Append(sb);
        renderer.Content.Append($"\\row{Environment.NewLine}");

        DocumentRendererHelper.RenderRowsToRtf(renderer, _table.Rows);

        style = (ParagraphStyleBase)renderer.Styleset.FindStyle("TableLegendStyle");
        renderer.Content.Append($@"\pard\plain\q{renderer.Styleset.GetIndexOfStyle("TableLegendStyle")}{RtfHelper.GetFormatSettings(style, renderer.Styleset)}\sb{MeasurementHelper.GetTwipsFromPt(tableStyle.Margins.Bottom)}{{");
        var childs = new List<Inline>();

        if (!string.IsNullOrEmpty(_table.CurrentPrefix))
        {
            renderer.Content.Append($@"{{\*\bkmkstart {_table.TagName}}}");
            childs.Add(new Span(_table.CurrentPrefix));
        }

        childs.AddRange(_table.ChildInlines);
        sb.Clear();
        DocumentRendererHelper.RenderInlineChildsToRtf(renderer, sb, childs);
        renderer.Content.Append($@"{sb}{{\*\bkmkend {_table.TagName} }}}}\par{Environment.NewLine}");
    }
}