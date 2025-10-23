// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="ParagraphRight"/> instances
/// </summary>
public class ParagraphRightPdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly ParagraphRight _paragraphRight;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRightPdfTextRendererElement(ParagraphRight paragraphRight) : base(paragraphRight)
    {
        _paragraphRight = paragraphRight;
        ClassName = paragraphRight.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddParagraphRight(Content.ToString());
    }
}