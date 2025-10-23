// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="TotSection"/> instances
/// </summary>
public class TotSectionHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly TotSection _totSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TotSectionHtmlTextRendererElement(TotSection totSection) : base(totSection)
    {
        _totSection = totSection;
        ClassName = totSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        if (_totSection.ChildBlocks.Count == 0)
        {
            return;
        }

        renderer.Content.AppendLine($"<p class=\"TotHeadingStyle\">{renderer.CheckContent(renderer.Document.DocumentMetaData.TotHeading)}</p>");
        DocumentRendererHelper.RenderBlockChildsToHtml(renderer, _totSection.ChildBlocks);
    }
}