using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="SectionStyle"/> instances
/// </summary>
public class SectionStyleHtmlTextRendererElement : HtmlPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _sectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionStyleHtmlTextRendererElement(SectionStyle sectionStyle) : base(sectionStyle)
    {
        _sectionStyle = sectionStyle;
        ClassName = "SectionStyle";
    }
}