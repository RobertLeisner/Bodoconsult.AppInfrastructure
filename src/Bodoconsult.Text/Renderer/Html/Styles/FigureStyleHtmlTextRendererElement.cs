using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="FigureStyle"/> instances
/// </summary>
public class FigureStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly FigureStyle _figureStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FigureStyleHtmlTextRendererElement(FigureStyle figureStyle) : base(figureStyle)
    {
        _figureStyle = figureStyle;
        ClassName = "FigureStyle";
    }
}