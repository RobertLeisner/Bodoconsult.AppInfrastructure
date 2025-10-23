using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="SectionSubtitleStyle"/> instances
/// </summary>
public class SectionSubtitleStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly SectionSubtitleStyle _sectionSubtitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitleStyleHtmlTextRendererElement(SectionSubtitleStyle sectionSubtitleStyle) : base(sectionSubtitleStyle)
    {
        _sectionSubtitleStyle = sectionSubtitleStyle;
        ClassName = "SectionSubtitleStyle";
    }
}