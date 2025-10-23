using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="TofSection"/> instances
/// </summary>
public class TofSectionHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly TofSection _tofSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TofSectionHtmlTextRendererElement(TofSection tofSection) : base(tofSection)
    {
        _tofSection = tofSection;
        ClassName = tofSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        if (_tofSection.ChildBlocks.Count == 0)
        {
            return;
        }

        renderer.Content.AppendLine($"<p class=\"TofHeadingStyle\">{renderer.CheckContent(renderer.Document.DocumentMetaData.TofHeading)}</p>");
        DocumentRendererHelper.RenderBlockChildsToHtml(renderer, _tofSection.ChildBlocks);

    }
}