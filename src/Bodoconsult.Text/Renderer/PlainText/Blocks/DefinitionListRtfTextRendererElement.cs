// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// HTML rendering element for <see cref="DefinitionList"/> instances
/// </summary>
public class DefinitionListPlainTextRendererElement : ITextRendererElement
{
    private readonly DefinitionList _item;

    /// <summary>
    /// Default ctor
    /// </summary>
    public DefinitionListPlainTextRendererElement(DefinitionList item) 
    {
        _item = item;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        DocumentRendererHelper.RenderBlockChildsToPlain(renderer, _item.ChildBlocks);
    }
}