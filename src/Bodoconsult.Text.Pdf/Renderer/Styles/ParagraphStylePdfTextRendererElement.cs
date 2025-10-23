using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="ParagraphStyle"/> instances
/// </summary>
public class ParagraphStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyle _paragraphStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphStylePdfTextRendererElement(ParagraphStyle paragraphStyle) : base(paragraphStyle)
    {
        _paragraphStyle = paragraphStyle;
        ClassName = "ParagraphStyle";
    }
}