using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.Text.Documents;
using System.Windows;
using System.Windows.Media;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="FigureStyle"/> instances
/// </summary>
public class FigureStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    /// <summary>
    /// Namwe of the figure caption style
    /// </summary>
    public const string FigureCaptionStyleName = "FigureCaptionStyle";

    private readonly FigureStyle _figureStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FigureStyleWpfTextRendererElement(FigureStyle figureStyle) : base(figureStyle)
    {
        _figureStyle = figureStyle;
        ClassName = "FigureStyle";
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        // Caption style
        renderer.Dispatcher.Invoke(() =>
        {
            // Image style
            var styleName = Style.StyleName;
            ImageStyle(renderer, styleName);

            // Caption style
            styleName = FigureCaptionStyleName;
            CaptionStyle(renderer, styleName);
        });
    }

    private void ImageStyle(WpfTextDocumentRenderer renderer, string styleName)
    {
        var style = new Style(typeof(System.Windows.Documents.Paragraph));

        //WpfDocumentRendererHelper.RenderParagraphStyle(Style, style);

        style.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.TextElement.FontSizeProperty,
            Value = MeasurementHelper.GetDiuFromPoint(Style.FontSize)
        });
        style.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.TextElement.FontFamilyProperty,
            Value = new FontFamily(Style.FontName)
        });

        style.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.TextElement.FontWeightProperty,
            Value = Style.Bold ? FontWeights.Bold : FontWeights.Normal
        });

        style.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.Block.MarginProperty,
            Value = new System.Windows.Thickness(MeasurementHelper.GetDiuFromPoint(Style.Margins.Left),
                MeasurementHelper.GetDiuFromPoint(Style.Margins.Top),
                MeasurementHelper.GetDiuFromPoint(Style.Margins.Right),
                0)
        });

        style.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.Block.TextAlignmentProperty,
            Value = System.Windows.TextAlignment.Center
        });

        renderer.StyleSet.Add(styleName, style);
    }

    private void CaptionStyle(WpfTextDocumentRenderer renderer, string styleName)
    {
        var style = new Style(typeof(System.Windows.Documents.Paragraph));

        //WpfDocumentRendererHelper.RenderParagraphStyle(Style, style);

        style.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.TextElement.FontSizeProperty,
            Value = MeasurementHelper.GetDiuFromPoint(Style.FontSize)
        });
        style.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.TextElement.FontFamilyProperty,
            Value = new FontFamily(Style.FontName)
        });

        style.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.TextElement.FontWeightProperty,
            Value = Style.Bold ? FontWeights.Bold : FontWeights.Normal
        });

        style.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.Block.MarginProperty,
            Value = new System.Windows.Thickness(MeasurementHelper.GetDiuFromPoint(Style.Margins.Left),
                0,
                MeasurementHelper.GetDiuFromPoint(Style.Margins.Right),
                MeasurementHelper.GetDiuFromPoint(Style.Margins.Bottom))
        });

        style.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.Block.TextAlignmentProperty,
            Value = System.Windows.TextAlignment.Center
        });

        renderer.StyleSet.Add(styleName, style);
    }
}