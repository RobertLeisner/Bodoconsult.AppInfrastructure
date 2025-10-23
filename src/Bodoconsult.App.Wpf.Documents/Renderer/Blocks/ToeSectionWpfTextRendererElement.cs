// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;


namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="ToeSection"/> instances
/// </summary>
public class ToeSectionWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly ToeSection _toeSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSectionWpfTextRendererElement(ToeSection toeSection) : base(toeSection)
    {
        _toeSection = toeSection;
        ClassName = toeSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        //if (_toeSection.ChildBlocks.Count == 0)
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

        //renderer.PdfDocument.CreateToeSection();

        //PdfDocumentRendererHelper.RenderBlockChildsToPdf(renderer, Block.ChildBlocks);
    }
}