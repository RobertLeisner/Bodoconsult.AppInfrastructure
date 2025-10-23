using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="Heading4Style"/> instances
/// </summary>
public class Heading4StyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly Heading4Style _heading4Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading4StyleHtmlTextRendererElement(Heading4Style heading4Style) : base(heading4Style)
    {
        _heading4Style = heading4Style;
        ClassName = "Heading4Style";
    }
}