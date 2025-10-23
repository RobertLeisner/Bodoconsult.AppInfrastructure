using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="FigureStyle"/> instances
/// </summary>
public class FigureStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly FigureStyle _figureStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public FigureStylePdfTextRendererElement(FigureStyle figureStyle) : base(figureStyle)
    {
        _figureStyle = figureStyle;
        ClassName = "FigureStyle";
    }
}