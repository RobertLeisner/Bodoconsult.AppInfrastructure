using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="FigureStyle"/> instances
/// </summary>
public class FigureStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly FigureStyle _figureStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FigureStyleDocxTextRendererElement(FigureStyle figureStyle) : base(figureStyle)
    {
        _figureStyle = figureStyle;
        ClassName = "FigureStyle";
    }
}