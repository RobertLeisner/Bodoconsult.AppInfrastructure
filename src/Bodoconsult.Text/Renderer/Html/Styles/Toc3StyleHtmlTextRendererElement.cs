using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="Toc3Style"/> instances
/// </summary>
public class Toc3StyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly Toc3Style _toc3Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc3StyleHtmlTextRendererElement(Toc3Style toc3Style) : base(toc3Style)
    {
        _toc3Style = toc3Style;
        ClassName = "Toc3Style";
    }
}