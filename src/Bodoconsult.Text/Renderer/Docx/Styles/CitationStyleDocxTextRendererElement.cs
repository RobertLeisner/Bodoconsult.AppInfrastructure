using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="CitationStyle"/> instances
/// </summary>
public class CitationStyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly CitationStyle _citationStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CitationStyleDocxTextRendererElement(CitationStyle citationStyle) : base(citationStyle)
    {
        _citationStyle = citationStyle;
        ClassName = "CitationStyle";
    }
}