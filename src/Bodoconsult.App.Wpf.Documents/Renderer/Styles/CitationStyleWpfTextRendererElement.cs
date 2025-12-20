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
/// WPF rendering element for <see cref="CitationStyle"/> instances
/// </summary>
public class CitationStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{


    private readonly CitationStyle _citationStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationStyleWpfTextRendererElement(CitationStyle citationStyle) : base(citationStyle)
    {
        _citationStyle = citationStyle;
        ClassName = "CitationStyle";
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {

        renderer.Dispatcher.Invoke(() =>
        {
            var styleName = Style.Name;
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

        });
    }
}