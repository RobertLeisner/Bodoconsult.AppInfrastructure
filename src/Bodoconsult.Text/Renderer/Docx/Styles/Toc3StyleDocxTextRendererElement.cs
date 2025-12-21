using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="Toc3Style"/> instances
/// </summary>
public class Toc3StyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly Toc3Style _toc3Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc3StyleDocxTextRendererElement(Toc3Style toc3Style) : base(toc3Style)
    {
        _toc3Style = toc3Style;
        ClassName = "Toc3Style";
    }
}