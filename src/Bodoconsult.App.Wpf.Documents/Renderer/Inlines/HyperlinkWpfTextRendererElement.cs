// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows.Documents;
using Bodoconsult.App.Wpf.Documents.Helpers;
using Hyperlink = Bodoconsult.Text.Documents.Hyperlink;
using Inline = Bodoconsult.Text.Documents.Inline;
using Paragraph = System.Windows.Documents.Paragraph;
using TextElement = System.Windows.Documents.TextElement;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Inlines;

/// <summary>
/// Render a <see cref="Text.Documents.Hyperlink"/> element
/// </summary>
public class HyperlinkWpfTextRendererElement : InlineWpfTextRendererElementBase
{
    private readonly Hyperlink _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Hyperlink</param>
    public HyperlinkWpfTextRendererElement(Hyperlink span)
    {
        _span = span;
    }


    /// <summary>
    /// Render the inline to a string
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="element">Base text element</param>
    /// <param name="childInlines">Child inlines of an inline</param>
    /// <exception cref="NotSupportedException"></exception>
    public override void RenderToElement(WpfTextDocumentRenderer renderer, TextElement element, List<Inline> childInlines)
    {

        if (element is Paragraph paragraph)
        {
            if (_span.ChildInlines.Count == 0)
            {
                var hyperlink = new System.Windows.Documents.Hyperlink(new Run(_span.Content))
                    {
                        NavigateUri = new Uri(_span.Uri)
                    };
                paragraph.Inlines.Add(hyperlink);

                return;
            }

            WpfDocumentRendererHelper.RenderBlockInlinesToWpf(renderer, _span.ChildInlines, paragraph);
            return;
        }

        if (element is System.Windows.Documents.Inline inline)
        {
            WpfDocumentRendererHelper.RenderBlockInlinesToWpf(renderer, _span.ChildInlines, inline);
        }
    }

}