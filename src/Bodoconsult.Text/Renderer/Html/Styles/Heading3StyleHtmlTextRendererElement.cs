using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="Heading3Style"/> instances
/// </summary>
public class Heading3StyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly Heading3Style _heading3Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3StyleHtmlTextRendererElement(Heading3Style heading3Style) : base(heading3Style)
    {
        _heading3Style = heading3Style;
        ClassName = "Heading3Style";
    }
}