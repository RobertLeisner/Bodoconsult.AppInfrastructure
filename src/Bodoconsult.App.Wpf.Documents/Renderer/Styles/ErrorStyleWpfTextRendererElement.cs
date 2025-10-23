using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="ErrorStyle"/> instances
/// </summary>
public class ErrorStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly ErrorStyle _errorStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ErrorStyleWpfTextRendererElement(ErrorStyle errorStyle) : base(errorStyle)
    {
        _errorStyle = errorStyle;
        ClassName = "ErrorStyle";
    }
}