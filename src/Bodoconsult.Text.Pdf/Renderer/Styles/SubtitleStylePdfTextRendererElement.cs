using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="SubtitleStyle"/> instances
/// </summary>
public class SubtitleStylePdfTextRendererElement : PdfParagraphStyleTextRendererElementBase
{
    private readonly SubtitleStyle _subtitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitleStylePdfTextRendererElement(SubtitleStyle subtitleStyle) : base(subtitleStyle)
    {
        _subtitleStyle = subtitleStyle;
        ClassName = "SubtitleStyle";
    }
}