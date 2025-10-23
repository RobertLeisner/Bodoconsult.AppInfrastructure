// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="Image"/> instances
/// </summary>
public class ImagePdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly Image _image;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ImagePdfTextRendererElement(Image image) : base(image)
    {
        _image = image;
        ClassName = image.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(PdfTextDocumentRenderer renderer)
    {     
        // Get max height and with for images in twips
        StylesetHelper.GetMaxWidthAndHeight(renderer.Styleset, out var maxWidth, out var maxHeight);

        StylesetHelper.GetWidthAndHeight(MeasurementHelper.GetTwipsFromPx(_image.OriginalWidth),
            MeasurementHelper.GetTwipsFromPx(_image.OriginalHeight), maxWidth, maxHeight, out var width, out var height);

        renderer.PdfDocument.AddImage(_image.Uri, MeasurementHelper.GetCmFromTwips(width), MeasurementHelper.GetCmFromTwips(height));

    }
}