// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;
using System.Windows.Documents;


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
        if (_toeSection.ChildBlocks.Count == 0)
        {
            return;
        }

        renderer.Dispatcher.Invoke(() =>
        {
            var section = new System.Windows.Documents.Section();

            renderer.WpfDocument.Blocks.Add(section);
            renderer.CurrentSection = section;

            var span = new System.Windows.Documents.Span(new Run(renderer.Document.DocumentMetaData.ToeHeading));
            var p = new System.Windows.Documents.Paragraph(span);
            renderer.CurrentSection.Blocks.Add(p);

            section.BreakPageBefore = _toeSection.PageBreakBefore;
        });

        //WpfDocumentRendererHelper.RenderBlockChildsToPdf(renderer, Block.ChildBlocks);
    }
}