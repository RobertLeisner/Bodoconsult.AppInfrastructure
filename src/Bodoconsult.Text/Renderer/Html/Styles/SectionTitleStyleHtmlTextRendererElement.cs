using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="SectionTitleStyle"/> instances
/// </summary>
public class SectionTitleStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly SectionTitleStyle _sectionTitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleStyleHtmlTextRendererElement(SectionTitleStyle sectionTitleStyle) : base(sectionTitleStyle)
    {
        _sectionTitleStyle = sectionTitleStyle;
        ClassName = "SectionTitleStyle";
    }
}