// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// Render a <see cref="Italic"/> element
/// </summary>
public class ItalicHtmlTextRendererElement : InlineHtmlTextRendererElementBase
{
    private readonly Italic _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public ItalicHtmlTextRendererElement(Italic span)
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
    //            renderer.Content.Append($"**{renderer.CheckContent(_span.Content)}**{Environment.NewLine}");
    //        }
    //        else
    //        {
    //            renderer.Content.Append($"**{renderer.CheckContent(_span.Content)}**");
    //        }
    //    }
    //    else
    //    {
    //        DocumentRendererHelper.RenderInlineChilds(renderer, _span.ChildInlines, tag: "**");
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
                sb.Append($"<i>{renderer.CheckContent(_span.Content)}</i>");
        }
        else
        {
            DocumentRendererHelper.RenderInlineChildsToHtml(renderer, sb, _span.ChildInlines, tag: "i");
        }
    }
}