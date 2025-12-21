using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="SectionStyle"/> instances
/// </summary>
public class SectionStyleDocxTextRendererElement : DocxPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _sectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionStyleDocxTextRendererElement(SectionStyle sectionStyle) : base(sectionStyle)
    {
        _sectionStyle = sectionStyle;
        ClassName = "SectionStyle";
    }
}