using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="SectionTitleStyle"/> instances
/// </summary>
public class SectionTitleStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly SectionTitleStyle _sectionTitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionTitleStyleWpfTextRendererElement(SectionTitleStyle sectionTitleStyle) : base(sectionTitleStyle)
    {
        _sectionTitleStyle = sectionTitleStyle;
        ClassName = "SectionTitleStyle";
    }
}