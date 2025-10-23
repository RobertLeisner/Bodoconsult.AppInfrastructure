// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using System;
using System.Text;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Render a <see cref="LineBreak"/> element
/// </summary>
public class LineBreakPlainTextRendererElement : InlinePlainTextRendererElementBase
{
    private readonly LineBreak _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public LineBreakPlainTextRendererElement(LineBreak span)
    {
        _span = span;
    }

    ///// <summary>
    ///// Render the element
    ///// </summary>
    ///// <param name="renderer">Current renderer</param>
    //public void RenderIt(ITextDocumentRender renderer)
    //{
    //    renderer.Content.Append($"{Environment.NewLine}");
    //}

    /// <summary>
    /// Render the inline element to string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="sb">String to add the inline element rendered</param>
    public override void RenderToString(ITextDocumentRenderer renderer, StringBuilder sb)
    {
        sb.Append($"{Environment.NewLine}{Environment.NewLine}");
    }
}