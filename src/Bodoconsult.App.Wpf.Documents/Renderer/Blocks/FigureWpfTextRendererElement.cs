// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System.Collections.Generic;
using System.Text;
using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;

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
        //// Get max height and with for images in twips
        //StylesetHelper.GetMaxWidthAndHeight(renderer.Styleset, out var maxWidth, out var maxHeight);

        //StylesetHelper.GetWidthAndHeight(MeasurementHelper.GetTwipsFromPx(_figure.OriginalWidth),
        //    MeasurementHelper.GetTwipsFromPx(_figure.OriginalHeight), maxWidth, maxHeight, out var width, out var height);

        //var childs = new List<Inline>();

        //if (!string.IsNullOrEmpty(_figure.CurrentPrefix))
        //{
        //    childs.Add(new Span(_figure.CurrentPrefix));
        //}
        //childs.AddRange(_figure.ChildInlines);

        //var sb = new StringBuilder();
        //PdfDocumentRendererHelper.RenderBlockInlinesToStringForPdf(renderer, childs, sb);

        //renderer.PdfDocument.AddFigure(_figure.Uri, sb.ToString(), _figure.TagName, MeasurementHelper.GetCmFromTwips(width), MeasurementHelper.GetCmFromTwips(height));

    }
}