using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Docx.Styles;

/// <summary>
/// Docx rendering element for <see cref="Toc2Style"/> instances
/// </summary>
public class Toc2StyleDocxTextRendererElement : DocxParagraphStyleTextRendererElementBase
{
    private readonly Toc2Style _toc2Style;

    /// <summary>
    /// Default ctor
    /// </summary>
    public Toc2StyleDocxTextRendererElement(Toc2Style toc2Style) : base(toc2Style)
    {
        _toc2Style = toc2Style;
        ClassName = "Toc2Style";
    }
}