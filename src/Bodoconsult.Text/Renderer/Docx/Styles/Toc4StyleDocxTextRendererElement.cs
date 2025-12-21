using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="Toc4Style"/> instances
/// </summary>
public class Toc4StyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly Toc4Style _toc4Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc4StyleDocxTextRendererElement(Toc4Style toc4Style) : base(toc4Style)
    {
        _toc4Style = toc4Style;
        ClassName = "Toc4Style";
    }
}