using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ImageStyle"/> instances
/// </summary>
public class ImageStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly ImageStyle _imageStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ImageStyleHtmlTextRendererElement(ImageStyle imageStyle) : base(imageStyle)
    {
        _imageStyle = imageStyle;
        ClassName = "ImageStyle";
    }
}