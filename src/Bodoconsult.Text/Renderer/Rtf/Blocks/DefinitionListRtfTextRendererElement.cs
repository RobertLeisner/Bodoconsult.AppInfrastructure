// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="DefinitionList"/> instances
/// </summary>
public class DefinitionListRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly DefinitionList _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListRtfTextRendererElement(DefinitionList item) : base(item)
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
        // top margin
        var listStyle = (DefinitionListStyle)renderer.Document.Styleset.FindStyle("DefinitionListStyle");
        //renderer.Content.AppendLine($@"\pard\plain\sb{MeasurementHelper.GetTwipsFromPt(listStyle.Margins.Top)}\fs6\par");

        // Get the content of all inlines as string
        DocumentRendererHelper.RenderBlockChildsToRtf(renderer, Block.ChildBlocks);

        // bottom margin
        renderer.Content.AppendLine($@"\pard\plain\sb{MeasurementHelper.GetTwipsFromCm(listStyle.Margins.Bottom)}\fs6\par");

    }
}