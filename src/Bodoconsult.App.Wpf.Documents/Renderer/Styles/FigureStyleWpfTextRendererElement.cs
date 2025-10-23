using Bodoconsult.Text.Documents;

namespace Bodoconsult.App.Wpf.Documents.Renderer.Styles;

/// <summary>
/// WPF rendering element for <see cref="FigureStyle"/> instances
/// </summary>
public class FigureStyleWpfTextRendererElement : WpfParagraphStyleTextRendererElementBase
{
    private readonly FigureStyle _figureStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FigureStyleWpfTextRendererElement(FigureStyle figureStyle) : base(figureStyle)
    {
        _figureStyle = figureStyle;
        ClassName = "FigureStyle";
    }
}