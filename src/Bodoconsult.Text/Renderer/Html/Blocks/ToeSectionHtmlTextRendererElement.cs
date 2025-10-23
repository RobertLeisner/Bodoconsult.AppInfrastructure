// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="ToeSection"/> instances
/// </summary>
public class ToeSectionHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly ToeSection _toeSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ToeSectionHtmlTextRendererElement(ToeSection toeSection) : base(toeSection)
    {
        _toeSection = toeSection;
        ClassName = toeSection.StyleName;
    }
    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        if (_toeSection.ChildBlocks.Count == 0)
        {
            return;
        }

        renderer.Content.AppendLine($"<p class=\"ToeHeadingStyle\">{renderer.CheckContent(renderer.Document.DocumentMetaData.ToeHeading)}</p>");
        DocumentRendererHelper.RenderBlockChildsToHtml(renderer, _toeSection.ChildBlocks);

    }
}