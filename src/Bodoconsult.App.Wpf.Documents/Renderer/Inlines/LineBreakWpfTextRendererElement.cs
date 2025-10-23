// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;
using System;
using System.Text;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Inlines;

/// <summary>
/// Render a <see cref="LineBreak"/> element
/// </summary>
public class LineBreakWpfTextRendererElement : InlineWpfTextRendererElementBase
{
    private readonly LineBreak _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public LineBreakWpfTextRendererElement(LineBreak span)
    {
        _span = span;
    }

    /// <summary>
    /// Render the inline to a string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="sb">String</param>
    public override void RenderToString(WpfTextDocumentRenderer renderer, StringBuilder sb)
    {
        sb.Append(Environment.NewLine);
    }
}