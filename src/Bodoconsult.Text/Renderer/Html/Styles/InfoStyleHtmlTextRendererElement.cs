using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="InfoStyle"/> instances
/// </summary>
public class InfoStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly InfoStyle _infoStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public InfoStyleHtmlTextRendererElement(InfoStyle infoStyle) : base(infoStyle)
    {
        _infoStyle = infoStyle;
        ClassName = "InfoStyle";
    }
}