using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="Heading2Style"/> instances
/// </summary>
public class Heading2StylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly Heading2Style _heading2Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2StylePdfTextRendererElement(Heading2Style heading2Style) : base(heading2Style)
    {
        _heading2Style = heading2Style;
        ClassName = "Heading2Style";
    }
}