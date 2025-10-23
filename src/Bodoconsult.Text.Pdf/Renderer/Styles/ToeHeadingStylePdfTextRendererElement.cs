using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="TocHeadingStyle"/> instances
/// </summary>
public class ToeHeadingStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly ToeHeadingStyle _toeHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeHeadingStylePdfTextRendererElement(ToeHeadingStyle toeHeadingStyle) : base(toeHeadingStyle)
    {
        _toeHeadingStyle = toeHeadingStyle;
        ClassName = "ToeHeadingStyle";
    }
}