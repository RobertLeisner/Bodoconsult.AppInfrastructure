// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;


namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="TocSection"/> instances
/// </summary>
public class TocSectionWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly TocSection _tocSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionWpfTextRendererElement(TocSection tocSection) : base(tocSection)
    {
        _tocSection = tocSection;
        ClassName = tocSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        //if (_tocSection.ChildBlocks.Count == 0)
        //{
        //    return;
        //}

        //if (!string.IsNullOrEmpty(renderer.Document.DocumentMetaData.HeaderText))
        //{
        //    renderer.PdfDocument.SetHeader(renderer.Document.DocumentMetaData.HeaderText);
        //}
        //if (!string.IsNullOrEmpty(renderer.Document.DocumentMetaData.FooterText))
        //{
        //    renderer.PdfDocument.SetFooter(renderer.Document.DocumentMetaData.FooterText);
        //}
        //renderer.PdfDocument.CreateTocSection();

        //PdfDocumentRendererHelper.RenderBlockChildsToPdf(renderer, Block.ChildBlocks);
    }
}