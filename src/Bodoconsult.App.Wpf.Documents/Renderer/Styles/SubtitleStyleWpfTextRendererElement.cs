using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="SubtitleStyle"/> instances
/// </summary>
public class SubtitleStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly SubtitleStyle _subtitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitleStyleWpfTextRendererElement(SubtitleStyle subtitleStyle) : base(subtitleStyle)
    {
        _subtitleStyle = subtitleStyle;
        ClassName = "SubtitleStyle";
    }
}