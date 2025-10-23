using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="CitationStyle"/> instances
/// </summary>
public class CitationStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly CitationStyle _citationStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationStylePdfTextRendererElement(CitationStyle citationStyle) : base(citationStyle)
    {
        _citationStyle = citationStyle;
        ClassName = "CitationStyle";
    }
}