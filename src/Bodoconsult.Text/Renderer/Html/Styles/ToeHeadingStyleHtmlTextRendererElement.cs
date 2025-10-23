using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TocHeadingStyle"/> instances
/// </summary>
public class ToeHeadingStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly ToeHeadingStyle _toeHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeHeadingStyleHtmlTextRendererElement(ToeHeadingStyle toeHeadingStyle) : base(toeHeadingStyle)
    {
        _toeHeadingStyle = toeHeadingStyle;
        ClassName = "ToeHeadingStyle";
    }
}