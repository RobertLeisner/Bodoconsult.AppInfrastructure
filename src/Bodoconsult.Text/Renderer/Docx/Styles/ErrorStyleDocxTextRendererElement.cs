using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="ErrorStyle"/> instances
/// </summary>
public class ErrorStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly ErrorStyle _errorStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ErrorStyleDocxTextRendererElement(ErrorStyle errorStyle) : base(errorStyle)
    {
        _errorStyle = errorStyle;
        ClassName = "ErrorStyle";
    }
}