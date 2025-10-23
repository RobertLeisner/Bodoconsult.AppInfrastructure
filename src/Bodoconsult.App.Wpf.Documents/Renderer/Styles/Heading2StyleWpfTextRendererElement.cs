using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="Heading2Style"/> instances
/// </summary>
public class Heading2StyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly Heading2Style _heading2Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Heading2StyleWpfTextRendererElement(Heading2Style heading2Style) : base(heading2Style)
    {
        _heading2Style = heading2Style;
        ClassName = "Heading2Style";
    }
}