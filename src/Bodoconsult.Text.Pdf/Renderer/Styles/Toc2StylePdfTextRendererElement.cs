using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="Toc2Style"/> instances
/// </summary>
public class Toc2StylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly Toc2Style _toc2Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc2StylePdfTextRendererElement(Toc2Style toc2Style) : base(toc2Style)
    {
        _toc2Style = toc2Style;
        ClassName = "Toc2Style";
    }
}