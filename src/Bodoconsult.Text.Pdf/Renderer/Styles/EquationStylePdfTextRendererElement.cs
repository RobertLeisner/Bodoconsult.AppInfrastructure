using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="EquationStyle"/> instances
/// </summary>
public class EquationStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly EquationStyle _equationStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public EquationStylePdfTextRendererElement(EquationStyle equationStyle) : base(equationStyle)
    {
        _equationStyle = equationStyle;
        ClassName = "EquationStyle";
    }
}