using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="Heading2Style"/> instances
/// </summary>
public class Heading2StyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly Heading2Style _heading2Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2StyleHtmlTextRendererElement(Heading2Style heading2Style) : base(heading2Style)
    {
        _heading2Style = heading2Style;
        ClassName = "Heading2Style";
    }
}