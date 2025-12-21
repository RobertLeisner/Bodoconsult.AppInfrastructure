// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using MigraDoc.DocumentObjectModel;
using Paragraph = MigraDoc.DocumentObjectModel.Paragraph;

namespace Bodoconsult.Text.Pdf.Renderer.Inlines;

/// <summary>
/// Render a <see cref="Italic"/> element
/// </summary>
public class ItalicPdfTextRendererElement : InlinePdfTextRendererElementBase
{
    private readonly Italic _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public ItalicPdfTextRendererElement(Italic span)
    {
        _span = span;
    }

    /// <summary>
    /// Render the inline element to string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="paragraph">Paragraph to render the inline into</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer, Paragraph paragraph)
    {
        var sb = new StringBuilder();

        if (!string.IsNullOrEmpty(_span.Content))
        {
            sb.Append(_span.Content);
        }
        else
        {
            PdfDocumentRendererHelper.RenderBlockInlinesToStringForPdf(renderer, _span.ChildInlines, sb);
        }

        paragraph.AddFormattedText(sb.ToString(), TextFormat.Italic);
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