// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using System;
using System.Text;

namespace Bodoconsult.Text.Pdf.Renderer.Inlines;

/// <summary>
/// Render a <see cref="LineBreak"/> element
/// </summary>
public class LineBreakPdfTextRendererElement : InlinePdfTextRendererElementBase
{
    private readonly LineBreak _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public LineBreakPdfTextRendererElement(LineBreak span)
    {
        _span = span;
    }

    /// <summary>
    /// Render the inline element to string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="paragraph">Paragraph to render the inline into</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer, MigraDoc.DocumentObjectModel.Paragraph paragraph)
    {
        paragraph.AddLineBreak();
    }


    /// <summary>
    /// Render the inline to a string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="sb">String</param>
    public override void RenderToString(PdfTextDocumentRenderer renderer, StringBuilder sb)
    {
        sb.Append(Environment.NewLine);
    }
}