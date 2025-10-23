using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="SectionStyle"/> instances
/// </summary>
public class SectionStylePdfTextRendererElement : PdfPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _sectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionStylePdfTextRendererElement(SectionStyle sectionStyle) : base(sectionStyle)
    {
        _sectionStyle = sectionStyle;
        ClassName = "SectionStyle";
    }
}