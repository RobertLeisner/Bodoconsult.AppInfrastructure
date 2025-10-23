using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="DefinitionListTerm"/> instances
/// </summary>
public class DefinitionListTermPdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly DefinitionListTerm _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListTermPdfTextRendererElement(DefinitionListTerm item) : base(item)
    {
        _item = item;
        ClassName = item.StyleName;
    }
}