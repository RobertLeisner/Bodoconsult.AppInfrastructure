using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ErrorStyle"/> instances
/// </summary>
public class ErrorStyleHtmlTextRendererElement : HtmlParagraphStyleTextRendererElementBase
{
    private readonly ErrorStyle _errorStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ErrorStyleHtmlTextRendererElement(ErrorStyle errorStyle) : base(errorStyle)
    {
        _errorStyle = errorStyle;
        ClassName = "ErrorStyle";
    }
}