using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="Heading3Style"/> instances
/// </summary>
public class Heading3StyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly Heading3Style _heading3Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading3StyleWpfTextRendererElement(Heading3Style heading3Style) : base(heading3Style)
    {
        _heading3Style = heading3Style;
        ClassName = "Heading3Style";
    }
}