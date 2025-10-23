using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ParagraphJustifyStyle"/> instances
/// </summary>
public class ParagraphJustifyStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly ParagraphJustifyStyle _paragraphJustifyStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphJustifyStyleHtmlTextRendererElement(ParagraphJustifyStyle paragraphJustifyStyle) : base(paragraphJustifyStyle)
    {
        _paragraphJustifyStyle = paragraphJustifyStyle;
        ClassName = "ParagraphJustifyStyle";
    }
}