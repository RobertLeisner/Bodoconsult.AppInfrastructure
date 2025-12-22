// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;

namespace Bodoconsult.Text.Renderer.Docx.Blocks;

/// <summary>
/// Docx rendering element for <see cref="Image"/> instances
/// </summary>
public class ImageDocxTextRendererElement : DocxTextRendererElementBase
{
    private readonly Image _image;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ImageDocxTextRendererElement(Image image) : base(image)
    {
        _image = image;
        ClassName = image.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(DocxTextDocumentRenderer renderer)
    {     
        // Get max height and with for images in cm
        StylesetHelper.GetMaxWidthAndHeightInCm(renderer.Styleset, out var maxWidth, out var maxHeight);

        StylesetHelper.GetWidthAndHeightInCm(MeasurementHelper.GetCmFromPx(_image.OriginalWidth),
            MeasurementHelper.GetCmFromPx(_image.OriginalHeight), maxWidth, maxHeight, out var width, out var height);

        renderer.DocxDocument.AddImage(_image.Uri, "Image", MeasurementHelper.GetPxFromCm(width), MeasurementHelper.GetPxFromCm(height));

    }
}