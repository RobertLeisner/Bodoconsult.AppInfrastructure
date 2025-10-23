using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="Toc3Style"/> instances
/// </summary>
public class Toc3StylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly Toc3Style _toc3Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc3StylePdfTextRendererElement(Toc3Style toc3Style) : base(toc3Style)
    {
        _toc3Style = toc3Style;
        ClassName = "Toc3Style";
    }
}