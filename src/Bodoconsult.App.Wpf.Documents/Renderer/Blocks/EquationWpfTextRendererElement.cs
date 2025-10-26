// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Wpf.Documents.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer.Styles;
using Bodoconsult.Text.Documents;
using System.Windows;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Equation"/> instances
/// </summary>
public class EquationWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly Equation _equation;

    /// <summary>
    /// Default ctor
    /// </summary>
    public EquationWpfTextRendererElement(Equation equation) : base(equation)
    {
        _equation = equation;
        ClassName = equation.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        WpfDocumentRendererHelper.AddImage(renderer, _equation);

        var childs = new List<Inline>();

        if (!string.IsNullOrEmpty(_equation.CurrentPrefix))
        {
            childs.Add(new Span(_equation.CurrentPrefix));
        }
        childs.AddRange(_equation.ChildInlines);

        renderer.Dispatcher.Invoke(() =>
        {
            var p = new System.Windows.Documents.Paragraph
            {
                Style = (Style)renderer.StyleSet[EquationStyleWpfTextRendererElement.EquationCaptionStyleName]
            };

            renderer.CurrentSection.Blocks.Add(p);

            WpfDocumentRendererHelper.RenderBlockInlinesToWpf(renderer, childs, p);
        });
    }
}