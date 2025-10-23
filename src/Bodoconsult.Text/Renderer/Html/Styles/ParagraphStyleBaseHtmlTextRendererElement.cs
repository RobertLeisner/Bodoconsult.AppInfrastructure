using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ParagraphStyleBase"/> instances
/// </summary>
public class ParagraphStyleBaseHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly ParagraphStyleBase _paragraphStyleBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ParagraphStyleBaseHtmlTextRendererElement(ParagraphStyleBase paragraphStyleBase) : base(paragraphStyleBase)
    {
        _paragraphStyleBase = paragraphStyleBase;
        ClassName = "ParagraphStyleBase";
    }
}