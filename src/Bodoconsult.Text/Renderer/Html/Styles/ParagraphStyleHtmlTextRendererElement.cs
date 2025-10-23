using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ParagraphStyle"/> instances
/// </summary>
public class ParagraphStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyle _paragraphStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphStyleHtmlTextRendererElement(ParagraphStyle paragraphStyle) : base(paragraphStyle)
    {
        _paragraphStyle = paragraphStyle;
        ClassName = "ParagraphStyle";
    }
}