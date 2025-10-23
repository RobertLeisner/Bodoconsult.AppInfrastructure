using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="InfoStyle"/> instances
/// </summary>
public class InfoStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly InfoStyle _infoStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public InfoStylePdfTextRendererElement(InfoStyle infoStyle) : base(infoStyle)
    {
        _infoStyle = infoStyle;
        ClassName = "InfoStyle";
    }
}