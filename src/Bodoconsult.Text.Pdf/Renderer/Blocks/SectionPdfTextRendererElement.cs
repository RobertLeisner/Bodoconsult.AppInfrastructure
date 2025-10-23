// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Pdf.Helpers;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Section"/> instances
/// </summary>
public class SectionPdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly Section _section;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionPdfTextRendererElement(Section section) : base(section)
    {
        _section = section;
        ClassName = section.StyleName;
    }

    ///// <summary>
    ///// Render the element
    ///// </summary>
    ///// <param name="renderer">Current renderer</param>
    //public override void RenderIt(ITextDocumentRenderer renderer)
    //{

    //    DocumentRendererHelper.RenderBlockChildsToHtml(renderer, _section.ChildBlocks);
    //}

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {
        
        
        if (!string.IsNullOrEmpty(renderer.Document.DocumentMetaData.HeaderText))
        {
            renderer.PdfDocument.SetHeader(renderer.Document.DocumentMetaData.HeaderText);
        }
        if (!string.IsNullOrEmpty(renderer.Document.DocumentMetaData.FooterText))
        {
            renderer.PdfDocument.SetFooter(renderer.Document.DocumentMetaData.FooterText);
        }

        if (_section.IsRestartPageNumberingRequired)
        {
            renderer.PdfDocument.PageSetup.StartingNumber = 1;
        }

        renderer.PdfDocument.CreateContentSection();

        PdfDocumentRendererHelper.RenderBlockChildsToPdf(renderer, Block.ChildBlocks);
    }
}