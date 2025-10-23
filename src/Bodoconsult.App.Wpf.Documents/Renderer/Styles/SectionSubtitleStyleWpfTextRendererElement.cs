using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="SectionSubtitleStyle"/> instances
/// </summary>
public class SectionSubtitleStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly SectionSubtitleStyle _sectionSubtitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionSubtitleStyleWpfTextRendererElement(SectionSubtitleStyle sectionSubtitleStyle) : base(sectionSubtitleStyle)
    {
        _sectionSubtitleStyle = sectionSubtitleStyle;
        ClassName = "SectionSubtitleStyle";
    }
}