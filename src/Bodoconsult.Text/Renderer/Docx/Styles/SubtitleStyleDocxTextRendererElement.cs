using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="SubtitleStyle"/> instances
/// </summary>
public class SubtitleStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly SubtitleStyle _subtitleStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SubtitleStyleDocxTextRendererElement(SubtitleStyle subtitleStyle) : base(subtitleStyle)
    {
        _subtitleStyle = subtitleStyle;
        ClassName = "SubtitleStyle";
    }
}