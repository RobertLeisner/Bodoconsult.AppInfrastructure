using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TitleStyle"/> instances
/// </summary>
public class TitleStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly TitleStyle _titleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TitleStyleHtmlTextRendererElement(TitleStyle titleStyle) : base(titleStyle)
    {
        _titleStyle = titleStyle;
        ClassName = "TitleStyle";
    }
}