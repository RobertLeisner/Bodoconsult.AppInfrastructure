// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Toc4"/> instances
/// </summary>
public class Toc4PdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Toc4 _toc4;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc4PdfTextRendererElement(Toc4 toc4) : base(toc4)
    {
        _toc4 = toc4;
        ClassName = toc4.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddToc4Entry(Content.ToString(), Block.TagName);
    }
}