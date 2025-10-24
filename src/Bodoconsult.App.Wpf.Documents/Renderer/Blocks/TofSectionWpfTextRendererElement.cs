// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;
using System.Windows.Documents;


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

        if (_tofSection.ChildBlocks.Count == 0)
        {
            return;
        }

        renderer.Dispatcher.Invoke(() =>
        {
            var section = new System.Windows.Documents.Section();

            renderer.WpfDocument.Blocks.Add(section);
            renderer.CurrentSection = section;

            var span = new System.Windows.Documents.Span(new Run(renderer.Document.DocumentMetaData.TofHeading));
            var p = new System.Windows.Documents.Paragraph(span);
            renderer.CurrentSection.Blocks.Add(p);

            section.BreakPageBefore = _tofSection.PageBreakBefore;
        });

        WpfDocumentRendererHelper.RenderBlockChildsToWpf(renderer, Block.ChildBlocks);
    }
}