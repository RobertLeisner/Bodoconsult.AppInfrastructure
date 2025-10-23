using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="Heading4Style"/> instances
/// </summary>
public class Heading4StyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly Heading4Style _heading4Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading4StyleWpfTextRendererElement(Heading4Style heading4Style) : base(heading4Style)
    {
        _heading4Style = heading4Style;
        ClassName = "Heading4Style";
    }
}