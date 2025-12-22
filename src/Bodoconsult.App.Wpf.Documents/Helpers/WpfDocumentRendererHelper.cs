// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Abstractions.Interfaces;
using Bodoconsult.App.Wpf.Documents.Delegates;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.App.Wpf.Documents.Renderer.Blocks;
using Bodoconsult.App.Wpf.Documents.Renderer.Inlines;
using Bodoconsult.App.Wpf.Documents.WpfElements;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Block = Bodoconsult.Text.Documents.Block;
using Figure = System.Windows.Documents.Figure;
using Image = System.Windows.Controls.Image;
using Inline = Bodoconsult.Text.Documents.Inline;
using ListItem = System.Windows.Documents.ListItem;
using Paragraph = System.Windows.Documents.Paragraph;
using Span = System.Windows.Documents.Span;
using TextElement = System.Windows.Documents.TextElement;
using Thickness = System.Windows.Thickness;

namespace Bodoconsult.App.Wpf.Documents.Helpers;

/// <summary>
/// Helepr class for rendering a <see cref="Text.Documents.Document"/> to WPF
/// </summary>
public static class WpfDocumentRendererHelper
{
    /// <summary>
    /// No margin thickness
    /// </summary>
    public static Thickness NoMarginThickness = new(0);

    /// <summary>
    /// No margin thickness
    /// </summary>
    public static Thickness SmallPaddingThickness = new(3);

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
            Property = TextElement.FontSizeProperty,
            Value = MeasurementHelper.GetDiuFromPoint(docStyle.FontSize)
        });
        wpfStyle.Setters.Add(new Setter
        {
            Property = TextElement.FontFamilyProperty,
            Value = new FontFamily(docStyle.FontName)
        });

        wpfStyle.Setters.Add(new Setter
        {
            Property = TextElement.FontWeightProperty,
            Value = docStyle.Bold ? FontWeights.Bold : FontWeights.Normal
        });
        wpfStyle.Setters.Add(new Setter
        {
            Property = System.Windows.Documents.Block.MarginProperty,
            Value = new Thickness(MeasurementHelper.GetDiuFromCm(docStyle.Margins.Left),
                MeasurementHelper.GetDiuFromCm(docStyle.Margins.Top),
                MeasurementHelper.GetDiuFromCm(docStyle.Margins.Right),
                MeasurementHelper.GetDiuFromCm(docStyle.Margins.Bottom))
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
            var section = new PagingSection();

            //section..PageWidth = MeasurementHelper.GetDiuFromCm(Style.PageWidth);
            //pdfStyle.PageHeight = MeasurementHelper.GetDiuFromCm(Style.PageHeight);
            //pdfStyle.ColumnWidth = double.NaN;

            renderer.WpfDocument.Blocks.Add(section);
            renderer.CurrentSection = section;

            var span = new Span(new Run(headingText));
            var p = new Paragraph(span);

            var style = (Style)renderer.StyleSet[styleName];
            p.Style = style;

            renderer.CurrentSection.Blocks.Add(p);

            section.BreakPageBefore = docSection.PageBreakBefore;
        });

        RenderBlockChildsToWpf(renderer, docSection.ChildBlocks);
    }

    /// <summary>
    /// Add an image to the document
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="image">Current image</param>
    public static void AddImage(WpfTextDocumentRenderer renderer, ImageBase image)
    {
        // Get max height and with for images in twips
        StylesetHelper.GetMaxWidthAndHeight(renderer.Styleset, out var maxWidth, out var maxHeight);

        StylesetHelper.GetWidthAndHeight(MeasurementHelper.GetTwipsFromPx(image.OriginalWidth),
            MeasurementHelper.GetTwipsFromPx(image.OriginalHeight), maxWidth, maxHeight, out var width, out var height);

        renderer.Dispatcher.Invoke(() =>
        {

            var wpfImage = new Image
            {
                Margin = NoMarginThickness
            };
            var bimg = new BitmapImage();
            bimg.BeginInit();
            bimg.UriSource = new Uri(image.Uri, UriKind.RelativeOrAbsolute);
            bimg.EndInit();
            wpfImage.Source = bimg;

            wpfImage.Width = MeasurementHelper.GetDiuFromTwips(width);
            wpfImage.Height = MeasurementHelper.GetDiuFromTwips(height);

            var figure = new Figure
            {
                Margin = NoMarginThickness
            };

            //var style = FindStyleResource("FigureBlock");

            var block = new BlockUIContainer(wpfImage)
            {
                Margin = NoMarginThickness
            };

            //style = FindStyleResource("FigureImage");

            //figure.Style = style;
            figure.Blocks.Add(block);
            figure.HorizontalAnchor = FigureHorizontalAnchor.ColumnCenter;
            figure.CanDelayPlacement = false;

            var paragraphContainer = new Paragraph
            {
                Margin = NoMarginThickness
            };

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
            //                : string.Empty) + title, string.Empty);
            //    paragraphContainer.Style = style;
            //}
            paragraphContainer.Inlines.Add(figure);

            renderer.CurrentSection.Blocks.Add(paragraphContainer);
        });
    }

    /// <summary>
    /// Render child inlines of a block to WPF
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="childLines">Child inilines</param>
    /// <param name="listItem">List item to render in</param>
    public static void RenderBlockInlinesToWpf(WpfTextDocumentRenderer renderer, ReadOnlyLdmlList<Inline> childLines, ListItem listItem)
    {
        foreach (var child in childLines)
        {
            var element = (InlineWpfTextRendererElementBase)renderer.WpfTextRendererElementFactory.CreateInstanceWpf(child);
            element.RenderToElement(renderer, listItem, child.ChildInlines);
        }
    }

    /// <summary>
    /// Render child inlines of a block to WPF
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="childInlines">Child inilines</param>
    /// <param name="cell">Cell item to render in</param>
    public static void RenderBlockChildsToWpf(WpfTextDocumentRenderer renderer, ReadOnlyLdmlList<DefinitionListItem> childInlines, TableCell cell)
    {
        foreach (var child in childInlines)
        {
            var element = (DefinitionListItemWpfTextRendererElement)renderer.WpfTextRendererElementFactory.CreateInstanceWpf(child);
            element.RenderIt(renderer, cell);
        }
    }

    /// <summary>
    /// Draw in a section area
    /// </summary>
    /// <param name="drawDelegate">Delegate drawing in the section area</param>
    /// <param name="area">Drawing area</param>
    /// <param name="page">Page number</param>
    /// <param name="dpi">DPI</param>
    /// <param name="pageNumberFormat">Page number format</param>
    /// <returns>Section Visual</returns>
    public static Visual CreateSectionVisual(DrawSectionDelegate drawDelegate, Rect area, int page, double dpi,
        PageNumberFormatEnum pageNumberFormat)
    {
        var visual = new DrawingVisual();
        using (var context = visual.RenderOpen())
        {
            drawDelegate(context, area, page, dpi, pageNumberFormat);
        }
        return visual;
    }
}