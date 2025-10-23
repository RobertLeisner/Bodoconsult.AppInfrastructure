using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="Heading1Style"/> instances
/// </summary>
public class Heading1StyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly Heading1Style _heading1Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading1StyleWpfTextRendererElement(Heading1Style heading1Style) : base(heading1Style)
    {
        _heading1Style = heading1Style;
        ClassName = "Heading1Style";
    }
}