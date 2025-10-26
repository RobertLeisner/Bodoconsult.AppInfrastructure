// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.Text.Documents;
using TextElement = System.Windows.Documents.TextElement;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Inlines;

/// <summary>
/// Render a <see cref="LineBreak"/> element
/// </summary>
public class LineBreakWpfTextRendererElement : InlineWpfTextRendererElementBase
{
    private readonly LineBreak _span;

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="span">Paragraph</param>
    public LineBreakWpfTextRendererElement(LineBreak span)
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
                var italic = new System.Windows.Documents.LineBreak();
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