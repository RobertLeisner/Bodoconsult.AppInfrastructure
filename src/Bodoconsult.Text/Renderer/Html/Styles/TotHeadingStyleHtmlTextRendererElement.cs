using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TotHeadingStyle"/> instances
/// </summary>
public class TotHeadingStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly TotHeadingStyle _totHeadingStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotHeadingStyleHtmlTextRendererElement(TotHeadingStyle totHeadingStyle) : base(totHeadingStyle)
    {
        _totHeadingStyle = totHeadingStyle;
        ClassName = "TotHeadingStyle";
    }
}