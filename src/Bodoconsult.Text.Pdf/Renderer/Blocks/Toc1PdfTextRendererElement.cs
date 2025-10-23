// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Toc1"/> instances
/// </summary>
public class Toc1PdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Toc1 _toc1;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1PdfTextRendererElement(Toc1 toc1) : base(toc1)
    {
        _toc1 = toc1;
        ClassName = toc1.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddToc1Entry(Content.ToString(), Block.TagName);
    }
}

