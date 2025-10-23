// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Toc3"/> instances
/// </summary>
public class Toc3PdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Toc3 _toc3;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc3PdfTextRendererElement(Toc3 toc3) : base(toc3)
    {
        _toc3 = toc3;
        ClassName = toc3.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddToc3Entry(Content.ToString(), Block.TagName);
    }
}