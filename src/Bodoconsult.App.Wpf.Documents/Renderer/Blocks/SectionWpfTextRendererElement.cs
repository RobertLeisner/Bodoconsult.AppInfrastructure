// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.Text.Documents;


namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Section"/> instances
/// </summary>
public class SectionWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly Section _section;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionWpfTextRendererElement(Section section) : base(section)
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
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        renderer.Dispatcher.Invoke(() =>
        {
            var section = new System.Windows.Documents.Section();

            renderer.WpfDocument.Blocks.Add(section);
            renderer.CurrentSection = section;


            section.BreakPageBefore = _section.PageBreakBefore;
        });

        //if (!string.IsNullOrEmpty(renderer.Document.DocumentMetaData.HeaderText))
        //{
        //    renderer.PdfDocument.SetHeader(renderer.Document.DocumentMetaData.HeaderText);
        //}
        //if (!string.IsNullOrEmpty(renderer.Document.DocumentMetaData.FooterText))
        //{
        //    renderer.PdfDocument.SetFooter(renderer.Document.DocumentMetaData.FooterText);
        //}

        //if (_section.IsRestartPageNumberingRequired)
        //{
        //    renderer.PdfDocument.PageSetup.StartingNumber = 1;
        //}

        //renderer.PdfDocument.CreateContentSection();

        
        WpfDocumentRendererHelper.RenderBlockChildsToWpf(renderer, Block.ChildBlocks);
    }
}