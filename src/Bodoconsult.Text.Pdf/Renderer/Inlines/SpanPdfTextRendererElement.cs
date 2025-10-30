// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using System.Text;

namespace Bodoconsult.Text.Pdf.Renderer.Inlines;


/// <summary>
/// Render a <see cref="Span"/> element
/// </summary>
public class SpanPdfTextRendererElement : InlinePdfTextRendererElementBase
{
    private readonly Span _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public SpanPdfTextRendererElement(Span span)
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
        paragraph.AddText(_span.Content ?? string.Empty);
    }


    /// <summary>
    /// Render the inline to a string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="sb">String</param>
    public override void RenderToString(PdfTextDocumentRenderer renderer, StringBuilder sb)
    {
        sb.Append(renderer.CheckContent(_span.Content));
    }
}