// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;
using TextElement = System.Windows.Documents.TextElement;
using System.Text;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Inlines;

/// <summary>
/// Render a <see cref="Italic"/> element
/// </summary>
public class ItalicWpfTextRendererElement : InlineWpfTextRendererElementBase
{
    private readonly Italic _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public ItalicWpfTextRendererElement(Italic span)
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

        if (element is System.Windows.Documents.Paragraph paragraph)
        {
            if (_span.ChildInlines.Count == 0)
            {
                var italic = new System.Windows.Documents.Italic(new System.Windows.Documents.Run(_span.Content));
                paragraph.Inlines.Add(italic);

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