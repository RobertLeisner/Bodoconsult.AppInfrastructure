// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;
using System.Text;

namespace Bodoconsult.Text.Renderer.Rtf.Blocks;

/// <summary>
/// Rtf rendering element for <see cref="DefinitionListItem"/> instances
/// </summary>
public class DefinitionListItemRtfTextRendererElement : RtfTextRendererElementBase
{
    private readonly DefinitionListItem _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItemRtfTextRendererElement(DefinitionListItem item) : base(item)
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
        if (Block is ParagraphBase paragraph)
        {
            var style = (ParagraphStyleBase)renderer.Styleset.FindStyle(paragraph.StyleName);
            renderer.Content.Append($@"{{\pard\plain\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)}{RtfHelper.GetFormatSettings(style, renderer.Styleset)}");
        }
        else
        {
            renderer.Content.Append($@"{{\pard\plain\q{renderer.Styleset.GetIndexOfStyle(Block.StyleName)}");
        }

        DocumentRendererHelper.RenderBlockChildsToRtf(renderer, Block.ChildBlocks);

        var sb = new StringBuilder();
        DocumentRendererHelper.RenderInlineChildsToRtf(renderer, sb, Block.ChildInlines);
        renderer.Content.Append(sb);
        renderer.Content.Append($"}}\\par{Environment.NewLine}");
    }
}