// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Toc5"/> instances
/// </summary>
public class Toc5PdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly Toc5 _toc5;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc5PdfTextRendererElement(Toc5 toc5) : base(toc5)
    {
        _toc5 = toc5;
        ClassName = toc5.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddToc5Entry(Content.ToString(), Block.TagName);
    }
}