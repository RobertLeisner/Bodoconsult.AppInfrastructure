// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Paragraph"/> instances
/// </summary>
public class ParagraphPdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Paragraph _paragraph;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphPdfTextRendererElement(Paragraph paragraph) : base(paragraph)
    {
        _paragraph = paragraph;
        ClassName = paragraph.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddParagraphLeft(Content.ToString());
    }
}