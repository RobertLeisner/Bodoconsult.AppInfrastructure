// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

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
/// WPF rendering element for <see cref="CitationSourceStyle"/> instances
/// </summary>
public class CitationSourceStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    /// <summary>
    /// Name of the citation source style
    /// </summary>
    public const string CitationSourceStyleName = "CitationSourceStyle";


    private readonly CitationSourceStyle _citationSourceStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationSourceStyleWpfTextRendererElement(CitationSourceStyle citationSourceStyle) : base(citationSourceStyle)
    {
        _citationSourceStyle = citationSourceStyle;
        ClassName = "CitationSourceStyle";
    }


    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {

        renderer.Dispatcher.Invoke(() =>
        {
            var styleName =  CitationSourceStyleName;

            var style = new Style(typeof(Paragraph));

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
        });
    }
}