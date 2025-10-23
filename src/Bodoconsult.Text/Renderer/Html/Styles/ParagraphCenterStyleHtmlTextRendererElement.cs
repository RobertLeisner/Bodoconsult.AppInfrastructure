using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ParagraphCenterStyle"/> instances
/// </summary>
public class ParagraphCenterStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly ParagraphCenterStyle _paragraphCenterStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphCenterStyleHtmlTextRendererElement(ParagraphCenterStyle paragraphCenterStyle) : base(paragraphCenterStyle)
    {
        _paragraphCenterStyle = paragraphCenterStyle;
        ClassName = "ParagraphCenterStyle";
    }
}