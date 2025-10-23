using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ParagraphRightStyle"/> instances
/// </summary>
public class ParagraphRightStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly ParagraphRightStyle _paragraphRightStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphRightStyleHtmlTextRendererElement(ParagraphRightStyle paragraphRightStyle) : base(paragraphRightStyle)
    {
        _paragraphRightStyle = paragraphRightStyle;
        ClassName = "ParagraphRightStyle";
    }
}