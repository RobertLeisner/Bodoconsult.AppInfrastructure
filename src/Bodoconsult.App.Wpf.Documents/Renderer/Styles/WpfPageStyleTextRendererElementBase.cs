// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Wpf.Documents.Interfaces;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using Thickness = System.Windows.Thickness;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// Base class for <see cref="PageStyleBase"/> based styles
/// </summary>
public abstract class WpfPageStyleTextRendererElementBase : IWpfTextRendererElement
{

    /// <summary>
    /// Current block to renderer
    /// </summary>
    public PageStyleBase Style { get; private set; }

    /// <summary>
    /// CSS class name
    /// </summary>
    public string ClassName { get; protected set; }

    /// <summary>
    /// Default ctor
    /// </summary>
    /// <param name="style">Current page style</param>
    protected WpfPageStyleTextRendererElementBase(PageStyleBase style)
    {
        Style = style;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(WpfTextDocumentRenderer renderer)
    {

        renderer.Dispatcher.Invoke(() =>
        {

            var pdfStyle = renderer.WpfDocument;

            //pdfStyle.Orientation = Style.TypeAreaHeight < Style.TypeAreaWidth ? Orientation.Landscape : Orientation.Portrait;
            pdfStyle.PageWidth = MeasurementHelper.GetDiuFromCm(Style.PageWidth);
            pdfStyle.PageHeight = MeasurementHelper.GetDiuFromCm(Style.PageHeight);
            pdfStyle.PagePadding = new Thickness(MeasurementHelper.GetDiuFromCm(Style.MarginLeft), 
                MeasurementHelper.GetDiuFromCm(Style.MarginTop),
                MeasurementHelper.GetDiuFromCm(Style.MarginRight),
                MeasurementHelper.GetDiuFromCm(Style.MarginBottom));
            pdfStyle.ColumnWidth = double.NaN;
            //pdfStyle.LeftMargin = Unit.FromCentimeter(Style.MarginLeft);
            //pdfStyle.RightMargin = Unit.FromCentimeter(Style.MarginRight);
            //pdfStyle.TopMargin = Unit.FromCentimeter(Style.MarginTop);
            //pdfStyle.BottomMargin = Unit.FromCentimeter(Style.MarginBottom);

            //// ToDo: other formats
            //pdfStyle.PageFormat = PageFormat.A4;

        });
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        throw new NotSupportedException();
    }
}