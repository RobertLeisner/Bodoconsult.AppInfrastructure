using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Pdf.Renderer.Blocks;

namespace Bodoconsult.Text.Pdf.Renderer.Styles;

/// <summary>
/// HTML rendering element for <see cref="SectionBase"/> instances
/// </summary>
public abstract class SectionBasePdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly SectionBase _sectionBase;

    /// <summary>
    /// Default ctor
    /// </summary>
    protected SectionBasePdfTextRendererElement(SectionBase sectionBase) : base(sectionBase)
    {
        _sectionBase = sectionBase;
        ClassName = sectionBase.StyleName;
    }
}