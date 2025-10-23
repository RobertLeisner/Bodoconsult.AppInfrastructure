using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TotSectionStyle"/> instances
/// </summary>
public class TotSectionStyleHtmlTextRendererElement : HtmlPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _tofSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotSectionStyleHtmlTextRendererElement(TotSectionStyle tofSectionStyle) : base(tofSectionStyle)
    {
        _tofSectionStyle = tofSectionStyle;
        ClassName = "TotSectionStyle";
    }
}