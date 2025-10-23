using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="Toc1Style"/> instances
/// </summary>
public class Toc1StyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly Toc1Style _toc1Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1StyleHtmlTextRendererElement(Toc1Style toc1Style) : base(toc1Style)
    {
        _toc1Style = toc1Style;
        ClassName = "Toc1Style";
    }
}