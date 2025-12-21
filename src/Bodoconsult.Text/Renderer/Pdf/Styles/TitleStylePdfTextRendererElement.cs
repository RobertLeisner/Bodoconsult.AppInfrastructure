using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Pdf.Styles;

/// <summary>
/// PDF rendering element for <see cref="TitleStyle"/> instances
/// </summary>
public class TitleStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly TitleStyle _titleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TitleStylePdfTextRendererElement(TitleStyle titleStyle) : base(titleStyle)
    {
        _titleStyle = titleStyle;
        ClassName = "TitleStyle";
    }
}