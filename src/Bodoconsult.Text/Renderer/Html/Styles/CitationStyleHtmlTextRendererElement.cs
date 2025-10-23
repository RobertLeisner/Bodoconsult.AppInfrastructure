using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="CitationStyle"/> instances
/// </summary>
public class CitationStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly CitationStyle _citationStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationStyleHtmlTextRendererElement(CitationStyle citationStyle) : base(citationStyle)
    {
        _citationStyle = citationStyle;
        ClassName = "CitationStyle";
    }
}