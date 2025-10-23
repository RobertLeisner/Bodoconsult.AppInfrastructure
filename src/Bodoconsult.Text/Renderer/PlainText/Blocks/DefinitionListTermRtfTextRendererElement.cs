// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// Plain rendering element for <see cref="DefinitionListTerm"/> instances
/// </summary>
public class DefinitionListTermPlainTextRendererElement : ParagraphBasePlainTextRendererElement
{
    private readonly DefinitionListTerm _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListTermPlainTextRendererElement(DefinitionListTerm item) 
    {
        _item = item;
        Paragraph = item;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        // Get the content of all inlines as string
        var sb = new StringBuilder();
        sb.Append("*** ");
        DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, _item.ChildInlines);
        sb.Append($" ***{Environment.NewLine}");
        renderer.Content.Append(sb);

        DocumentRendererHelper.RenderBlockChildsToPlain(renderer, _item.ChildBlocks);

        renderer.Content.AppendLine(string.Empty);
    }
}