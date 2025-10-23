// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="ParagraphCenter"/> instances
/// </summary>
public class ParagraphCenterPdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly ParagraphCenter _paragraphCenter;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterPdfTextRendererElement(ParagraphCenter paragraphCenter) : base(paragraphCenter)
    {
        _paragraphCenter = paragraphCenter;
        ClassName = paragraphCenter.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddParagraphCenter(Content.ToString());
    }


}