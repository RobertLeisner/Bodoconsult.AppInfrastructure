using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="DefinitionListItem"/> instances
/// </summary>
public class DefinitionListItemHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly DefinitionListItem _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListItemHtmlTextRendererElement(DefinitionListItem item) : base(item)
    {
        _item = item;
        ClassName = item.StyleName;
        TagToUse = "dd";
    }
}