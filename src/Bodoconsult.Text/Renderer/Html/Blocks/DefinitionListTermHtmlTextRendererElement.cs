using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;
using System.Text;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="DefinitionListTerm"/> instances
/// </summary>
public class DefinitionListTermHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly DefinitionListTerm _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListTermHtmlTextRendererElement(DefinitionListTerm item) : base(item)
    {
        _item = item;
        ClassName = item.StyleName;
        TagToUse = "dt";
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();

        if (string.IsNullOrEmpty(LocalCss))
        {
            sb.AppendLine($"<{TagToUse} class=\"{ClassName}\">");
        }
        else
        {
            sb.AppendLine($"<{TagToUse} class=\"{ClassName}\" style=\"{LocalCss}\">");
        }
        DocumentRendererHelper.RenderInlineChildsToHtml(renderer, sb, Block.ChildInlines);
        sb.AppendLine($"{Environment.NewLine}</{TagToUse}>");
        renderer.Content.Append(sb);

        DocumentRendererHelper.RenderBlockChildsToHtml(renderer, Block.ChildBlocks);
    }
}