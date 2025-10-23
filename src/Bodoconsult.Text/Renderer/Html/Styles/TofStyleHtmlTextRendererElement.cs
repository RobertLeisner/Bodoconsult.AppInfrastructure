using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="TofStyle"/> instances
/// </summary>
public class TofStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly TofStyle _tofStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofStyleHtmlTextRendererElement(TofStyle tofStyle) : base(tofStyle)
    {
        _tofStyle = tofStyle;
        ClassName = "TofStyle";
    }
}