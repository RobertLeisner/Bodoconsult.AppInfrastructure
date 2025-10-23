// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;
using System.Diagnostics;
using System.Text;
using Bodoconsult.App.Abstractions.Helpers;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="DefinitionListTerm"/> instances
/// </summary>
public class DefinitionListTermRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly DefinitionListTerm _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListTermRtfTextRendererElement(DefinitionListTerm item) : base(item)
    {
        _item = item;
        ClassName = item.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();

        var pageStyle = (DocumentStyle)renderer.Document.Styleset.FindStyle("DocumentStyle");
        var pageWidth = MeasurementHelper.GetTwipsFromCm(pageStyle.TypeAreaWidth);

        var width1 = (int)(0.15 * pageWidth);
        var width2 = (int)(0.85 * pageWidth);

        sb.Append($@"\trowd\trftsWidth{pageWidth}\trautofit1\trql\trpaddfb3\trpaddfr3\trpaddft3\trpaddfl3\trpaddb0\trpaddr0\trpaddt0\trpaddl0\cellx{width1}\cellx{width2}");
        sb.Append(@"{\intbl{");

        var style = (ParagraphStyleBase)renderer.Styleset.FindStyle(_item.StyleName);
        sb.Append($@"\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)}{RtfHelper.GetFormatSettings(style, renderer.Styleset)}");
        DocumentRendererHelper.RenderInlineChildsToRtf(renderer, sb, Block.ChildInlines);
        //sb.Append("Blubb");
        Debug.Print(sb.ToString());

        sb.Append($"}}\\cell}}{Environment.NewLine}");
        sb.Replace("\\par\r\n}\\cell", "}\\cell");

        Debug.Print(sb.ToString());


        sb.Append(@"{\intbl{");

        renderer.Content.Append(sb);

        DocumentRendererHelper.RenderBlockChildsToRtf(renderer, Block.ChildBlocks);

        //renderer.Content.Append("Blabb");
        renderer.Content.Append($@"}}\cell}}\row{Environment.NewLine}");
    }
}