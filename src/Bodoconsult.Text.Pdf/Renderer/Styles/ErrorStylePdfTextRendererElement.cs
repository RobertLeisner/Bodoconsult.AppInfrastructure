using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="ErrorStyle"/> instances
/// </summary>
public class ErrorStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly ErrorStyle _errorStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ErrorStylePdfTextRendererElement(ErrorStyle errorStyle) : base(errorStyle)
    {
        _errorStyle = errorStyle;
        ClassName = "ErrorStyle";
    }
}