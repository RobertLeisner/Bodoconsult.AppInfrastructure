// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.Text.Documents;
using System.Windows;
using System.Windows.Media;

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
            var style = new Style(typeof(System.Windows.Documents.Paragraph));


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

        });
    }
}