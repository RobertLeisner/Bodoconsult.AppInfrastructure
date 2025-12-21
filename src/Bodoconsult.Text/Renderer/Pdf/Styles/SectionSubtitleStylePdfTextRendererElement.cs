using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Pdf.Styles;

/// <summary>
/// PDF rendering element for <see cref="SectionSubtitleStyle"/> instances
/// </summary>
public class SectionSubtitleStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly SectionSubtitleStyle _sectionSubtitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitleStylePdfTextRendererElement(SectionSubtitleStyle sectionSubtitleStyle) : base(sectionSubtitleStyle)
    {
        _sectionSubtitleStyle = sectionSubtitleStyle;
        ClassName = "SectionSubtitleStyle";
    }
}