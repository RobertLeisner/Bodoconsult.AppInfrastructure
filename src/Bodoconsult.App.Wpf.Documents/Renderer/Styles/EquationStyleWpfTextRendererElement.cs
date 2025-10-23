using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="EquationStyle"/> instances
/// </summary>
public class EquationStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly EquationStyle _equationStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public EquationStyleWpfTextRendererElement(EquationStyle equationStyle) : base(equationStyle)
    {
        _equationStyle = equationStyle;
        ClassName = "EquationStyle";
    }
}