using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="ImageStyle"/> instances
/// </summary>
public class ImageStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly ImageStyle _imageStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ImageStylePdfTextRendererElement(ImageStyle imageStyle) : base(imageStyle)
    {
        _imageStyle = imageStyle;
        ClassName = "ImageStyle";
    }
}