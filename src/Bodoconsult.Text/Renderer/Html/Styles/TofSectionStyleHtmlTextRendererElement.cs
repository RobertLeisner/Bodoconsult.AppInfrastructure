using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TofSectionStyle"/> instances
/// </summary>
public class TofSectionStyleHtmlTextRendererElement : HtmlPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tofSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionStyleHtmlTextRendererElement(TofSectionStyle tofSectionStyle) : base(tofSectionStyle)
    {
        _tofSectionStyle = tofSectionStyle;
        ClassName = "TofSectionStyle";
    }
}