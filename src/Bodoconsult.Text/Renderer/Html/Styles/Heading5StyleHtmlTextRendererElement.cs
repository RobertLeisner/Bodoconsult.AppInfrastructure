using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="Heading5Style"/> instances
/// </summary>
public class Heading5StyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly Heading5Style _heading5Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading5StyleHtmlTextRendererElement(Heading5Style heading5Style) : base(heading5Style)
    {
        _heading5Style = heading5Style;
        ClassName = "Heading5Style";
    }
}