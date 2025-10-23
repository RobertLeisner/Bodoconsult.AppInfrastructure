using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TofHeadingStyle"/> instances
/// </summary>
public class TofHeadingStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly TofHeadingStyle _tofHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofHeadingStyleHtmlTextRendererElement(TofHeadingStyle tofHeadingStyle) : base(tofHeadingStyle)
    {
        _tofHeadingStyle = tofHeadingStyle;
        ClassName = "TofHeadingStyle";
    }
}