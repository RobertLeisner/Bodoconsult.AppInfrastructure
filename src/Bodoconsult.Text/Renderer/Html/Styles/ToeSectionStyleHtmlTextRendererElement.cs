using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ToeSectionStyle"/> instances
/// </summary>
public class ToeSectionStyleHtmlTextRendererElement : HtmlPageStyleTextRendererElementBase
{
    private readonly PageStyleBase _toeSectionStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSectionStyleHtmlTextRendererElement(ToeSectionStyle toeSectionStyle) : base(toeSectionStyle)
    {
        _toeSectionStyle = toeSectionStyle;
        ClassName = "ToeSectionStyle";
    }
}