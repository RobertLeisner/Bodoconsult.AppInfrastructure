// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Plain text rendering element for <see cref="Section"/> instances
/// </summary>
public class SectionPlainTextRendererElement : ITextRendererElement
{
    private readonly Section _section;

    /// <summary>
    /// Default ctor
    /// </summary>
    public SectionPlainTextRendererElement(Section section)
    {
        _section = section;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();

        DocumentRendererHelper.RenderBlockChildsToPlain(renderer, _section.ChildBlocks);

        DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, _section.ChildInlines, string.Empty, true);
        renderer.Content.Append(sb);
    }
}