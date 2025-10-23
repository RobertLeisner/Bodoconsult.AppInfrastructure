// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="SectionTitle"/> instances
/// </summary>
public class SectionTitlePdfTextRendererElement : ParagraphPdfTextRendererElementBase
{
    private readonly SectionTitle _sectionTitle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitlePdfTextRendererElement(SectionTitle sectionTitle) : base(sectionTitle)
    {
        _sectionTitle = sectionTitle;
        ClassName = sectionTitle.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        base.RenderIt(renderer);
        Paragraph = renderer.PdfDocument.AddSectionTitle(Content.ToString());
    }
}