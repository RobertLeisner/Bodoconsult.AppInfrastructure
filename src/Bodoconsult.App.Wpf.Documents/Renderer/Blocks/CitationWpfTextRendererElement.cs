// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Windows;
using System.Windows.Documents;
using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer.Styles;
using Bodoconsult.Text.Documents;
using Inline = Bodoconsult.Text.Documents.Inline;
using Paragraph = System.Windows.Documents.Paragraph;
using Span = Bodoconsult.Text.Documents.Span;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Citation"/> instances
/// </summary>
public class CitationWpfTextRendererElement : ParagraphWpfTextRendererElementBase
{
    private readonly Citation _citation;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationWpfTextRendererElement(Citation citation) : base(citation)
    {
        _citation = citation;
        ClassName = citation.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        renderer.Dispatcher.Invoke(() =>
        {

            // Citation
            Paragraph = new Paragraph();
            var style = (Style)renderer.StyleSet[_citation.StyleName];
            Paragraph.Style = style;

            renderer.CurrentSection.Blocks.Add(Paragraph);

            var childs = new List<Inline>();

            if (string.IsNullOrEmpty(_citation.CurrentPrefix))
            {
                childs.Add(new Span(_citation.CurrentPrefix));
            }

            childs.AddRange(_citation.ChildInlines);

            WpfDocumentRendererHelper.RenderBlockInlinesToWpf(renderer, childs, Paragraph);

            // Citation source
            var paragraph = new Paragraph(new Run(_citation.Source));
            style = (Style)renderer.StyleSet[CitationSourceStyleWpfTextRendererElement.CitationSourceStyleName];
            paragraph.Style = style;

            renderer.CurrentSection.Blocks.Add(paragraph);
        });
    }
}

