using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="SectionTitleStyle"/> instances
/// </summary>
public class SectionTitleStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly SectionTitleStyle _sectionTitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleStyleDocxTextRendererElement(SectionTitleStyle sectionTitleStyle) : base(sectionTitleStyle)
    {
        _sectionTitleStyle = sectionTitleStyle;
        ClassName = "SectionTitleStyle";
    }
}