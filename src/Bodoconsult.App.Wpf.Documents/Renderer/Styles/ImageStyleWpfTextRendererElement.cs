using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="ImageStyle"/> instances
/// </summary>
public class ImageStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly ImageStyle _imageStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ImageStyleWpfTextRendererElement(ImageStyle imageStyle) : base(imageStyle)
    {
        _imageStyle = imageStyle;
        ClassName = "ImageStyle";
    }
}