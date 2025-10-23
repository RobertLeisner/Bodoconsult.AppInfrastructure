// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Toc2"/> instances
/// </summary>
public class Toc2PdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Toc2 _toc2;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc2PdfTextRendererElement(Toc2 toc2) : base(toc2)
    {
        _toc2 = toc2;
        ClassName = toc2.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddToc2Entry(Content.ToString(), Block.TagName);
    }
}