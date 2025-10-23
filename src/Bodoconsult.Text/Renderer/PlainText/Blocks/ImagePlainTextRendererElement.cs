// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Text rendering element for <see cref="Image"/> instances
/// </summary>
public class ImagePlainTextRendererElement : ITextRendererElement
{
    private readonly Image _image;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ImagePlainTextRendererElement(Image image)
    {
        _image = image;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        DocumentRendererHelper.CreateImagePlainText(renderer, _image);
    }
}