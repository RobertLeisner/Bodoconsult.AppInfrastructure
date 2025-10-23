using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="Toc2Style"/> instances
/// </summary>
public class Toc2StyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly Toc2Style _toc2Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc2StyleHtmlTextRendererElement(Toc2Style toc2Style) : base(toc2Style)
    {
        _toc2Style = toc2Style;
        ClassName = "Toc2Style";
    }
}