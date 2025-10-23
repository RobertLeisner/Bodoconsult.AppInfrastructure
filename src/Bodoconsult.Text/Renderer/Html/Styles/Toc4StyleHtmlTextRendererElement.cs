using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="Toc4Style"/> instances
/// </summary>
public class Toc4StyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly Toc4Style _toc4Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc4StyleHtmlTextRendererElement(Toc4Style toc4Style) : base(toc4Style)
    {
        _toc4Style = toc4Style;
        ClassName = "Toc4Style";
    }
}