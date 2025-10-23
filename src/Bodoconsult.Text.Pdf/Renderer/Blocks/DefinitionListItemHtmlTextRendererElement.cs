using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Pdf.Renderer.Blocks;

/// <summary>
/// HTML rendering element for <see cref="DefinitionListItem"/> instances
/// </summary>
public class DefinitionListItemPdfTextRendererElement : PdfTextRendererElementBase
{
    private readonly DefinitionListItem _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItemPdfTextRendererElement(DefinitionListItem item) : base(item)
    {
        _item = item;
        ClassName = item.StyleName;
    }
}