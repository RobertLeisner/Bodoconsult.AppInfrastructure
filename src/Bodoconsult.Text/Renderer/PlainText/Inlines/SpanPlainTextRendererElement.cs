// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.


// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System.Text;

namespace Bodoconsult.Text.Renderer.PlainText;


/// <summary>
/// Render a <see cref="Span"/> element
/// </summary>
public class SpanPlainTextRendererElement : InlinePlainTextRendererElementBase
{
    private readonly Span _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public SpanPlainTextRendererElement(Span span)
    {
        _span = span;
    }

    ///// <summary>
    ///// Render the element
    ///// </summary>
    ///// <param name="renderer">Current renderer</param>
    //public void RenderIt(ITextDocumentRender renderer)
    //{
    //    //if (_span.ChildInlines.Count == 0)
    //    //{
    //        renderer.Content.Append($"{renderer.CheckContent(_span.Content)}");
    //    //}
    //    //else
    //    //{
    //    //    DocumentRendererHelper.RenderInlineChilds(renderer, _span.ChildInlines);
    //    //}
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
            //if (_span.Parent is Block)
            //{
            //    sb.Append($"{renderer.CheckContent(_span.Content)}{Environment.NewLine}");
            //}
            //else
            //{
            sb.Append($"{renderer.CheckContent(_span.Content)}");
            //}
        }
        else
        {
            DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, _span.ChildInlines, tag: string.Empty);

            //if (_span.Parent is Block)
            //{
            //    sb.Append($"{Environment.NewLine}");
            //}
        }
    }
}