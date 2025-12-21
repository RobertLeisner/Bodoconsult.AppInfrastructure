// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Collections.Generic;
using System.Text;
using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Equation"/> instances
/// </summary>
public class EquationDocxTextRendererElement : DocxTextRendererElementBase
{
    private readonly Equation _equation;

    /// <summary>
    /// Default ctor
    /// </summary>
    public EquationDocxTextRendererElement(Equation equation) : base(equation)
    {
        _equation = equation;
        ClassName = equation.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {
        //// Get max height and with for images in twips
        //StylesetHelper.GetMaxWidthAndHeight(renderer.Styleset, out var maxWidth, out var maxHeight);

        //StylesetHelper.GetWidthAndHeight(MeasurementHelper.GetTwipsFromPx(_equation.OriginalWidth),
        //    MeasurementHelper.GetTwipsFromPx(_equation.OriginalHeight), maxWidth, maxHeight, out var width, out var height);

        //var childs = new List<Inline>();

        //if (!string.IsNullOrEmpty(_equation.CurrentPrefix))
        //{
        //    childs.Add(new Span(_equation.CurrentPrefix));
        //}
        //childs.AddRange(_equation.ChildInlines);

        //var sb = new StringBuilder();
        //DocxDocumentRendererHelper.RenderBlockInlinesToStringForDocx(renderer, childs, sb);

        //renderer.DocxDocument.AddFigure(_equation.Uri, sb.ToString(), _equation.TagName, MeasurementHelper.GetCmFromTwips(width), MeasurementHelper.GetCmFromTwips(height));

    }
}