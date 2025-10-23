// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="TocSection"/> instances
/// </summary>
public class TocSectionHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly TocSection _tocSection;

    /// <summary>
    /// Default ctor
    /// </summary>
    public TocSectionHtmlTextRendererElement(TocSection tocSection) : base(tocSection)
    {
        _tocSection = tocSection;
        ClassName = tocSection.StyleName;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        if (_tocSection.ChildBlocks.Count==0)
        {
            return;
        }

        // Get the content of all inlines as string
        renderer.Content.AppendLine($"<p class=\"TocHeadingStyle\">{renderer.CheckContent(renderer.Document.DocumentMetaData.TocHeading)}</p>");

        DocumentRendererHelper.RenderBlockChildsToPlain(renderer, _tocSection.ChildBlocks);
    }
}