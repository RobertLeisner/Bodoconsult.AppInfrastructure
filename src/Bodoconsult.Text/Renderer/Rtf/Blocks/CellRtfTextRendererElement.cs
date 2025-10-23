// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System.Text;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="Cell"/> instances
/// </summary>
public class CellRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly Cell _cell;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellRtfTextRendererElement(Cell cell) : base(cell)
    {
        _cell = cell;
        ClassName = cell.StyleName;
    }

    /// <summary>
    /// Render cell to RTF string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="sb">Current string builder</param>
    public void RenderToString(ITextDocumentRenderer renderer, StringBuilder sb)
    {
        var type = _cell.Column.DataType;

        var style = (ParagraphStyleBase)renderer.Styleset.FindStyle($"Cell{DocumentRendererHelper.GetAlignment(type)}Style");


        //// Right aligned
        //if (type == typeof(double) || type == typeof(float) ||
        //    type == typeof(short) || type == typeof(int) ||
        //    type == typeof(long) || type == typeof(Int128) ||
        //    type == typeof(byte))
        //{
        //    style = (ParagraphStyleBase)renderer.Styleset.FindStyle("CellRightStyle");
        //}
        //else
        //// Centered aligned
        //if (type == typeof(bool) || type == typeof(DateTime))
        //{
        //    style = (ParagraphStyleBase)renderer.Styleset.FindStyle("CellCenterStyle");
        //}
        //// Default: left aligned
        //else
        //{
        //    style = (ParagraphStyleBase)renderer.Styleset.FindStyle("CellLeftStyle");
        //}
        sb.Append(@"\intbl\pard\plain");
        sb.Append(RtfHelper.GetFormatSettings(style, renderer.Styleset, true));

        sb.Append('{');

        DocumentRendererHelper.RenderInlineChildsToRtf(renderer, sb, _cell.ChildInlines);

        sb.Append("}\\cell ");
       
    }
}