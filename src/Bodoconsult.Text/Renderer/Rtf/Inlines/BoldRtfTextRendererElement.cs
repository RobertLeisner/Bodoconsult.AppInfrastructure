// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Rtf.Inlines;

/// <summary>
/// Render a <see cref="Bold"/> element
/// </summary>
public class BoldRtfTextRendererElement : InlineRtfTextRendererElementBase
{
    private readonly Bold _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public BoldRtfTextRendererElement(Bold span)
    {
        _span = span;
    }

    ///// <summary>
    ///// Render the element
    ///// </summary>
    ///// <param name="renderer">Current renderer</param>
    //public void RenderIt(ITextDocumentRender renderer)
    //{
    //    if (_span.ChildInlines.Count == 0)
    //    {
    //        if (_span.Parent is Block)
    //        {
    //            renderer.Content.Append($"*{renderer.CheckContent(_span.Content)}*{Environment.NewLine}");
    //        }
    //        else
    //        {
    //            renderer.Content.Append($"*{renderer.CheckContent(_span.Content)}*");
    //        }
    //    }
    //    else
    //    {
    //        DocumentRendererHelper.RenderInlineChilds(renderer, _span.ChildInlines, "*");
    //    }
    //}


    /// <summary>
    /// Render the inline element to string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="sb">String to add the inline element rendered</param>
    public override void RenderToString(ITextDocumentRenderer renderer, StringBuilder sb)
    {
        if (_span.ChildInlines.Count == 0)
        {
            sb.Append($@"\b{{{renderer.CheckContent(_span.Content)}}}\b0");
        }
        else
        {
            sb.Append($"\\b{{");
            DocumentRendererHelper.RenderInlineChildsToRtf(renderer, sb, _span.ChildInlines);
            sb.Append($"}}\\b0");

            if (_span.Parent is Block)
            {
                sb.Append($"{Environment.NewLine}");
            }
        }
    }
}