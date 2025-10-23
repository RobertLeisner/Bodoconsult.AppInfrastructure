using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="Heading5Style"/> instances
/// </summary>
public class Heading5StyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly Heading5Style _heading5Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading5StyleWpfTextRendererElement(Heading5Style heading5Style) : base(heading5Style)
    {
        _heading5Style = heading5Style;
        ClassName = "Heading5Style";
    }
}