using System.Windows;
using System.Windows.Media;
using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.Text.Documents;
using Block = System.Windows.Documents.Block;
using Paragraph = System.Windows.Documents.Paragraph;
using TextElement = System.Windows.Documents.TextElement;
using Thickness = System.Windows.Thickness;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="EquationStyle"/> instances
/// </summary>
public class EquationStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    /// <summary>
    /// Namwe of the figure caption style
    /// </summary>
    public const string EquationCaptionStyleName = "EquationCaptionStyle";

    private readonly EquationStyle _equationStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public EquationStyleWpfTextRendererElement(EquationStyle equationStyle) : base(equationStyle)
    {
        _equationStyle = equationStyle;
        ClassName = "EquationStyle";
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
            styleName = EquationCaptionStyleName;
            CaptionStyle(renderer, styleName);
        });
    }

    private void ImageStyle(WpfTextDocumentRenderer renderer, string styleName)
    {
        var style = new Style(typeof(Paragraph));

        //WpfDocumentRendererHelper.RenderParagraphStyle(Style, style);

        style.Setters.Add(new Setter
        {
            Property = TextElement.FontSizeProperty,
            Value = MeasurementHelper.GetDiuFromPoint(Style.FontSize)
        });
        style.Setters.Add(new Setter
        {
            Property = TextElement.FontFamilyProperty,
            Value = new FontFamily(Style.FontName)
        });

        style.Setters.Add(new Setter
        {
            Property = TextElement.FontWeightProperty,
            Value = Style.Bold ? FontWeights.Bold : FontWeights.Normal
        });

        style.Setters.Add(new Setter
        {
            Property = Block.MarginProperty,
            Value = new Thickness(MeasurementHelper.GetDiuFromPoint(Style.Margins.Left),
                MeasurementHelper.GetDiuFromPoint(Style.Margins.Top),
                MeasurementHelper.GetDiuFromPoint(Style.Margins.Right),
                0)
        });

        style.Setters.Add(new Setter
        {
            Property = Block.TextAlignmentProperty,
            Value = TextAlignment.Center
        });

        renderer.StyleSet.Add(styleName, style);
    }

    private void CaptionStyle(WpfTextDocumentRenderer renderer, string styleName)
    {
        var style = new Style(typeof(Paragraph));

        //WpfDocumentRendererHelper.RenderParagraphStyle(Style, style);

        style.Setters.Add(new Setter
        {
            Property = TextElement.FontSizeProperty,
            Value = MeasurementHelper.GetDiuFromPoint(Style.FontSize)
        });
        style.Setters.Add(new Setter
        {
            Property = TextElement.FontFamilyProperty,
            Value = new FontFamily(Style.FontName)
        });

        style.Setters.Add(new Setter
        {
            Property = TextElement.FontWeightProperty,
            Value = Style.Bold ? FontWeights.Bold : FontWeights.Normal
        });

        style.Setters.Add(new Setter
        {
            Property = Block.MarginProperty,
            Value = new Thickness(MeasurementHelper.GetDiuFromCm(Style.Margins.Left),
                0,
                MeasurementHelper.GetDiuFromCm(Style.Margins.Right),
                MeasurementHelper.GetDiuFromCm(Style.Margins.Bottom))
        });

        style.Setters.Add(new Setter
        {
            Property = Block.TextAlignmentProperty,
            Value = TextAlignment.Center
        });

        renderer.StyleSet.Add(styleName, style);
    }
}