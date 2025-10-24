// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows.Documents;
using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="TotSection"/> instances
/// </summary>
public class TotSectionWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly TotSection _totSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotSectionWpfTextRendererElement(TotSection totSection) : base(totSection)
    {
        _totSection = totSection;
        ClassName = totSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        if (_totSection.ChildBlocks.Count == 0)
        {
            return;
        }

        renderer.Dispatcher.Invoke(() =>
        {
            var section = new System.Windows.Documents.Section();

            renderer.WpfDocument.Blocks.Add(section);
            renderer.CurrentSection = section;

            var span = new System.Windows.Documents.Span(new Run(renderer.Document.DocumentMetaData.TotHeading));
            var p = new System.Windows.Documents.Paragraph(span);
            renderer.CurrentSection.Blocks.Add(p);


            section.BreakPageBefore = _totSection.PageBreakBefore;
        });

        WpfDocumentRendererHelper.RenderBlockChildsToWpf(renderer, Block.ChildBlocks);
    }
}