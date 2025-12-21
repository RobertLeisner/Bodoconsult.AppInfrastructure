using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="Toc1Style"/> instances
/// </summary>
public class Toc1StyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly Toc1Style _toc1Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc1StyleDocxTextRendererElement(Toc1Style toc1Style) : base(toc1Style)
    {
        _toc1Style = toc1Style;
        ClassName = "Toc1Style";
    }
}