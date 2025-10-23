using Bodoconsult.App.Wpf.Documents.Renderer.Blocks;
using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="SectionBase"/> instances
/// </summary>
public abstract class SectionBaseWpfTextRendererElement : WpfTextRendererElementBase
{
    private readonly SectionBase _sectionBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    protected SectionBaseWpfTextRendererElement(SectionBase sectionBase) : base(sectionBase)
    {
        _sectionBase = sectionBase;
        ClassName = sectionBase.StyleName;
    }
}