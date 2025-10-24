// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.App.Wpf.Documents.Renderer.Inlines;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Block = Bodoconsult.Text.Documents.Block;
using Inline = Bodoconsult.Text.Documents.Inline;
using Paragraph = System.Windows.Documents.Paragraph;
using Thickness = System.Windows.Thickness;

namespace Bodoconsult.App.Wpf.Documents.Helpers;

/// <summary>
/// Helepr class for rendering a <see cref="Text.Documents.Document"/> to WPF
/// </summary>
public static class WpfDocumentRendererHelper
{
    /// <summary>
    /// Render child blocks to WPF
    /// </summary>
    /// <param name="renderer">Current WPF renderer</param>
    /// <param name="childBlocks"></param>
    public static void RenderBlockChildsToWpf(WpfTextDocumentRenderer renderer, ReadOnlyLdmlList<Block> childBlocks)
    {

        foreach (var child in childBlocks)
        {
            var element = renderer.WpfTextRendererElementFactory.CreateInstanceWpf(child);
            element.RenderIt(renderer);
        }
    }

    /// <summary>
    /// Render style properties to WPF style
    /// </summary>
    /// <param name="docStyle"></param>
    /// <param name="wpfStyle"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void RenderParagraphStyle(ParagraphStyleBase docStyle, Style wpfStyle)
    {
        
        wpfStyle.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.TextElement.FontSizeProperty,
            Value = MeasurementHelper.PointToDiu(docStyle.FontSize)
        });
        wpfStyle.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.TextElement.FontFamilyProperty,
            Value = new FontFamily(docStyle.FontName)
        });

        wpfStyle.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.TextElement.FontWeightProperty,
            Value = docStyle.Bold ? FontWeights.Bold : FontWeights.Normal
        });
        wpfStyle.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.Block.MarginProperty,
            Value = new Thickness(MeasurementHelper.PointToDiu(docStyle.Margins.Left),
                MeasurementHelper.PointToDiu(docStyle.Margins.Top),
                MeasurementHelper.PointToDiu(docStyle.Margins.Right),
                MeasurementHelper.PointToDiu(docStyle.Margins.Bottom))
        });
    }

    /// <summary>
    /// Render child inlines to WPF
    /// </summary>
    /// <param name="renderer"></param>
    /// <param name="childs"></param>
    /// <param name="paragraph"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void RenderBlockInlinesToWpf(WpfTextDocumentRenderer renderer, List<Inline> childs, Paragraph paragraph)
    {
        foreach (var child in childs)
        {
            var element = (InlineWpfTextRendererElementBase)renderer.WpfTextRendererElementFactory.CreateInstanceWpf(child);
            element.RenderToElement(renderer, paragraph, child.ChildInlines);
        }
    }

    /// <summary>
    /// Render child inlines to WPF
    /// </summary>
    /// <param name="renderer"></param>
    /// <param name="childs"></param>
    /// <param name="inline"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void RenderBlockInlinesToWpf(WpfTextDocumentRenderer renderer, List<Inline> childs, System.Windows.Documents.Inline inline)
    {
        foreach (var child in childs)
        {
            var element = (InlineWpfTextRendererElementBase)renderer.WpfTextRendererElementFactory.CreateInstanceWpf(child);
            element.RenderToElement(renderer, inline, child.ChildInlines);
        }
    }

    /// <summary>
    /// Create a document section
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="docSection">Current section data</param>
    /// <param name="styleName">Heading style name</param>
    /// <param name="headingText">Headig text</param>
    public static void CreateSection(WpfTextDocumentRenderer renderer, SectionBase docSection, string styleName, string headingText)
    {
        if (docSection.ChildBlocks.Count == 0)
        {
            return;
        }

        renderer.Dispatcher.Invoke(() =>
        {
            var section = new System.Windows.Documents.Section();

            //section..PageWidth = MeasurementHelper.GetDiuFromCm(Style.PageWidth);
            //pdfStyle.PageHeight = MeasurementHelper.GetDiuFromCm(Style.PageHeight);
            //pdfStyle.ColumnWidth = double.NaN;

            renderer.WpfDocument.Blocks.Add(section);
            renderer.CurrentSection = section;

            var span = new System.Windows.Documents.Span(new Run(headingText));
            var p = new Paragraph(span);

            var style = (Style)renderer.StyleSet[styleName];
            p.Style = style;

            renderer.CurrentSection.Blocks.Add(p);

            section.BreakPageBefore = docSection.PageBreakBefore;
        });

        RenderBlockChildsToWpf(renderer, docSection.ChildBlocks);
    }

    public static void AddImage(WpfTextDocumentRenderer renderer, ImageBase image)
    {
        // Get max height and with for images in twips
        StylesetHelper.GetMaxWidthAndHeight(renderer.Styleset, out var maxWidth, out var maxHeight);

        StylesetHelper.GetWidthAndHeight(MeasurementHelper.GetTwipsFromPx(image.OriginalWidth),
            MeasurementHelper.GetTwipsFromPx(image.OriginalHeight), maxWidth, maxHeight, out var width, out var height);

        renderer.Dispatcher.Invoke(() =>
        {

            var wpfImage = new System.Windows.Controls.Image();
            var bimg = new BitmapImage();
            bimg.BeginInit();
            bimg.UriSource = new Uri(image.Uri, UriKind.RelativeOrAbsolute);
            bimg.EndInit();
            wpfImage.Source = bimg;

            wpfImage.Width = MeasurementHelper.GetDiuFromTwips(width);
            wpfImage.Height = MeasurementHelper.GetDiuFromTwips(height);

            var figure = new System.Windows.Documents.Figure();

            //var style = FindStyleResource("FigureBlock");

            var block = new BlockUIContainer(wpfImage)
            {
                //Name =
                //    string.IsNullOrEmpty(title)
                //        ? $"imageContainer{_imageCounter}"
                //        : $"figureContainer{_figureCounter}",
                //BreakPageBefore = _isPageBreak,
                //Style = style
            };

            //style = FindStyleResource("FigureImage");

            //figure.Style = style;
            figure.Blocks.Add(block);
            figure.HorizontalAnchor = FigureHorizontalAnchor.ColumnCenter;
            figure.CanDelayPlacement = false;

            var paragraphContainer = new System.Windows.Documents.Paragraph();

            //if (string.IsNullOrEmpty(title))
            //{
            //    style = FindStyleResource("FigureOnlyImage");
            //}
            //else
            //{
            //    style = FindStyleResource("FigureText");
            //    paragraphContainer =
            //        CheckContent(
            //            (TypographySettingsService.ShowFigureCounter
            //                ? $"{TypographySettingsService.FigureCounterPrefix} {_figureCounter:#,##0}: "
            //                : "") + title, "");
            //    paragraphContainer.Style = style;
            //}
            paragraphContainer.Inlines.Add(figure);

            renderer.CurrentSection.Blocks.Add(paragraphContainer);
        });
    }
}