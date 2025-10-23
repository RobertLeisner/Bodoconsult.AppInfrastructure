using Bodoconsult.Text.Documents;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="DefinitionList"/> instances
/// </summary>
public class DefinitionListHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly DefinitionList _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListHtmlTextRendererElement(DefinitionList item) : base(item)
    {
        _item = item;
        ClassName = item.StyleName;
        TagToUse = "dl";
    }
}