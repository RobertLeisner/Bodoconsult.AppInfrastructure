using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TotStyle"/> instances
/// </summary>
public class TotStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly TotStyle _totStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotStyleHtmlTextRendererElement(TotStyle totStyle) : base(totStyle)
    {
        _totStyle = totStyle;
        ClassName = "TotStyle";
    }
}