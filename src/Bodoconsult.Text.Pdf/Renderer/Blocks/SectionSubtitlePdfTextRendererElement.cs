// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="SectionSubtitle"/> instances
/// </summary>
public class SectionSubtitlePdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly SectionSubtitle _sectionSubtitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitlePdfTextRendererElement(SectionSubtitle sectionSubtitle) : base(sectionSubtitle)
    {
        _sectionSubtitle = sectionSubtitle;
        ClassName = sectionSubtitle.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddSectionSubtitle(Content.ToString());
    }
}