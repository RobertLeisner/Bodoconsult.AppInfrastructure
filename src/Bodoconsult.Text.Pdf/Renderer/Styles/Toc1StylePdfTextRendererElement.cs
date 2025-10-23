using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="Toc1Style"/> instances
/// </summary>
public class Toc1StylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly Toc1Style _toc1Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1StylePdfTextRendererElement(Toc1Style toc1Style) : base(toc1Style)
    {
        _toc1Style = toc1Style;
        ClassName = "Toc1Style";
    }
}