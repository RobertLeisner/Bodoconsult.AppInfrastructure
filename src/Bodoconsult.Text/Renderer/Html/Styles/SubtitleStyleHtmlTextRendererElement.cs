using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="SubtitleStyle"/> instances
/// </summary>
public class SubtitleStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly SubtitleStyle _subtitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitleStyleHtmlTextRendererElement(SubtitleStyle subtitleStyle) : base(subtitleStyle)
    {
        _subtitleStyle = subtitleStyle;
        ClassName = "SubtitleStyle";
    }
}