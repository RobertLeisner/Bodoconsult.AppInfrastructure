using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Section"/> instances
/// </summary>
public class SectionHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Section _section;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionHtmlTextRendererElement(Section section) : base(section)
    {
        _section = section;
        ClassName = section.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        DocumentRendererHelper.RenderBlockChildsToHtml(renderer, _section.ChildBlocks);
    }
}