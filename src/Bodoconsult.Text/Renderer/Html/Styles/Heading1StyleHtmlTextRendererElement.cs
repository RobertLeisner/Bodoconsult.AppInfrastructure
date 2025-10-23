using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="Heading1Style"/> instances
/// </summary>
public class Heading1StyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly Heading1Style _heading1Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading1StyleHtmlTextRendererElement(Heading1Style heading1Style) : base(heading1Style)
    {
        _heading1Style = heading1Style;
        ClassName = "Heading1Style";
    }
}