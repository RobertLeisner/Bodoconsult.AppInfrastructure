using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="TitleStyle"/> instances
/// </summary>
public class TitleStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly TitleStyle _titleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TitleStyleWpfTextRendererElement(TitleStyle titleStyle) : base(titleStyle)
    {
        _titleStyle = titleStyle;
        ClassName = "TitleStyle";
    }
}