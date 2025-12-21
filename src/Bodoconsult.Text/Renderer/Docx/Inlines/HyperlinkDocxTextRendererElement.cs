// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using MigraDoc.DocumentObjectModel;
using Hyperlink = Bodoconsult.Text.Documents.Hyperlink;
using Paragraph = MigraDoc.DocumentObjectModel.Paragraph;

namespace Bodoconsult.Text.Renderer.Docx.Inlines;

/// <summary>
/// Render a <see cref="Documents.Hyperlink"/> element
/// </summary>
public class HyperlinkDocxTextRendererElement : InlineDocxTextRendererElementBase
{
    private readonly Hyperlink _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Hyperlink</param>
    public HyperlinkDocxTextRendererElement(Hyperlink span)
    {
        _span = span;
    }

    /// <summary>
    /// Render the inline element to string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="paragraph">Paragraph to render the inline into</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer, Paragraph paragraph)
    {
        var h = paragraph.AddHyperlink(_span.Uri, HyperlinkType.Web);
        h.AddFormattedText(_span.Content);
    }


    /// <summary>
    /// Render the inline to a string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="sb">String</param>
    public override void RenderToString(DocxTextDocumentRenderer renderer, StringBuilder sb)
    {
        sb.Append($"[{renderer.CheckContent(_span.Content)}]({_span.Uri})");
    }
}