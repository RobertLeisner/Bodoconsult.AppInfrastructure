using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="Toc1Style"/> instances
/// </summary>
public class Toc1StyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly Toc1Style _toc1Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1StyleWpfTextRendererElement(Toc1Style toc1Style) : base(toc1Style)
    {
        _toc1Style = toc1Style;
        ClassName = "Toc1Style";
    }
}