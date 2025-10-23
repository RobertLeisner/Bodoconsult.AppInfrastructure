// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;


namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="TofSection"/> instances
/// </summary>
public class TofSectionWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly TofSection _tofSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionWpfTextRendererElement(TofSection tofSection) : base(tofSection)
    {
        _tofSection = tofSection;
        ClassName = tofSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        if (_tofSection.ChildBlocks.Count == 0)
        {
            return;
        }

        //if (!string.IsNullOrEmpty(renderer.Document.DocumentMetaData.HeaderText))
        //{
        //    renderer.PdfDocument.SetHeader(renderer.Document.DocumentMetaData.HeaderText);
        //}
        //if (!string.IsNullOrEmpty(renderer.Document.DocumentMetaData.FooterText))
        //{
        //    renderer.PdfDocument.SetFooter(renderer.Document.DocumentMetaData.FooterText);
        //}

        //renderer.PdfDocument.CreateTofSection();

        //PdfDocumentRendererHelper.RenderBlockChildsToPdf(renderer, Block.ChildBlocks);
    }
}