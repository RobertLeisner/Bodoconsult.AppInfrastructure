// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using System.Collections.Generic;
using System.Text;
using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer;

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
        // Get max height and with for images in twips
        StylesetHelper.GetMaxWidthAndHeight(renderer.Styleset, out var maxWidth, out var maxHeight);

        StylesetHelper.GetWidthAndHeight(MeasurementHelper.GetTwipsFromPx(_equation.OriginalWidth),
            MeasurementHelper.GetTwipsFromPx(_equation.OriginalHeight), maxWidth, maxHeight, out var width, out var height);

        var childs = new List<Inline>();

        if (!string.IsNullOrEmpty(_equation.CurrentPrefix))
        {
            childs.Add(new Span(_equation.CurrentPrefix));
        }
        childs.AddRange(_equation.ChildInlines);

        //var sb = new StringBuilder();
        //PdfDocumentRendererHelper.RenderBlockInlinesToStringForPdf(renderer, childs, sb);

        //renderer.PdfDocument.AddFigure(_equation.Uri, sb.ToString(), _equation.TagName, MeasurementHelper.GetCmFromTwips(width), MeasurementHelper.GetCmFromTwips(height));

    }
}