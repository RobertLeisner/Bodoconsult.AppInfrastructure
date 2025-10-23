using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="EquationStyle"/> instances
/// </summary>
public class EquationStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly EquationStyle _equationStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public EquationStyleHtmlTextRendererElement(EquationStyle equationStyle) : base(equationStyle)
    {
        _equationStyle = equationStyle;
        ClassName = "EquationStyle";
    }
}