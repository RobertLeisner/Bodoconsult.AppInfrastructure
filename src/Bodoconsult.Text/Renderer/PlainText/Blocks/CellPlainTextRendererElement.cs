// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Generic;
using System.Text;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// HTML rendering element for <see cref="Cell"/> instances
/// </summary>
public class CellPlainTextRendererElement : ITextRendererElement
{
    private readonly Cell _cell;

    /// <summary>
    /// Default ctor
    /// </summary>
    public CellPlainTextRendererElement(Cell cell)
    {
        _cell = cell;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        // Do nothing
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="row"></param>
    public void RenderToString(ITextDocumentRenderer renderer, List<string> row)
    {
        var sb = new StringBuilder();
        DocumentRendererHelper.RenderInlineChildsToPlainText(renderer, sb, _cell.ChildInlines);
        row.Add(sb.ToString());
    }
}
