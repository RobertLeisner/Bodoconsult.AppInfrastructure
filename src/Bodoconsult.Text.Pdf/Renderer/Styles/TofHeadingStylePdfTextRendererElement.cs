using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TofHeadingStyle"/> instances
/// </summary>
public class TofHeadingStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TofHeadingStyle _tofHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofHeadingStylePdfTextRendererElement(TofHeadingStyle tofHeadingStyle) : base(tofHeadingStyle)
    {
        _tofHeadingStyle = tofHeadingStyle;
        ClassName = "TofHeadingStyle";
    }
}