// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Windows;
using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer.Styles;
using Bodoconsult.Text.Documents;
using Paragraph = System.Windows.Documents.Paragraph;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Figure"/> instances
/// </summary>
public class FigureWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly Figure _figure;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FigureWpfTextRendererElement(Figure figure) : base(figure)
    {
        _figure = figure;
        ClassName = figure.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        WpfDocumentRendererHelper.AddImage(renderer, _figure);

        var childs = new List<Inline>();

        if (!string.IsNullOrEmpty(_figure.CurrentPrefix))
        {
            childs.Add(new Span(_figure.CurrentPrefix));
        }
        childs.AddRange(_figure.ChildInlines);

        renderer.Dispatcher.Invoke(() =>
        {
            var p = new Paragraph
            {
                Style = (Style)renderer.StyleSet[FigureStyleWpfTextRendererElement.FigureCaptionStyleName]
            };

            renderer.CurrentSection.Blocks.Add(p);

            WpfDocumentRendererHelper.RenderBlockInlinesToWpf(renderer, childs, p);
        });
    }
}