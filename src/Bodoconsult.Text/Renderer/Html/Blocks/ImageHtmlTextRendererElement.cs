// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Image"/> instances
/// </summary>
public class ImageHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Image _image;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ImageHtmlTextRendererElement(Image image) : base(image)
    {
        _image = image;
        ClassName = image.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        DocumentRendererHelper.CreateImageHtml(renderer, _image, TagToUse, LocalCss, ClassName);
    }
}