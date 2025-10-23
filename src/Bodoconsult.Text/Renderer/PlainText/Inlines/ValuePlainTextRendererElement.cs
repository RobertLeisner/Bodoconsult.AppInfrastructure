// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Render a <see cref="Value"/> element
/// </summary>
public class ValuePlainTextRendererElement : InlinePlainTextRendererElementBase
{
    private readonly Value _value;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="value">Paragraph</param>
    public ValuePlainTextRendererElement(Value value)
    {
        _value = value;
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
        sb.Append($"{renderer.CheckContent(_value.Content)}");
    }
}