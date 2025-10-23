using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="SectionTitleStyle"/> instances
/// </summary>
public class SectionTitleStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly SectionTitleStyle _sectionTitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleStylePdfTextRendererElement(SectionTitleStyle sectionTitleStyle) : base(sectionTitleStyle)
    {
        _sectionTitleStyle = sectionTitleStyle;
        ClassName = "SectionTitleStyle";
    }
}