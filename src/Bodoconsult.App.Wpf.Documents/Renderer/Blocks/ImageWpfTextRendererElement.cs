// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Abstractions.Helpers;
using Bodoconsult.App.Wpf.Documents.Renderer;
using Bodoconsult.App.Wpf.Documents.Services;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using Bodoconsult.App.Wpf.Documents.Helpers;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Blocks;

/// <summary>
/// WPF rendering element for <see cref="Image"/> instances
/// </summary>
public class ImageWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly Image _image;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ImageWpfTextRendererElement(Image image) : base(image)
    {
        _image = image;
        ClassName = image.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(WpfTextDocumentRenderer renderer)
    {
        WpfDocumentRendererHelper.AddImage(renderer, _image);
    }


}