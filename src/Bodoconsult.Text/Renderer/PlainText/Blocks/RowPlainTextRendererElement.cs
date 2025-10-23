// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using System.Collections.Generic;
using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;

namespace Bodoconsult.Text.Renderer.PlainText;

/// <summary>
/// HTML rendering element for <see cref="Row"/> instances
/// </summary>
public class RowPlainTextRendererElement : ITextRendererElement
{
    private readonly Row _row;

    /// <summary>
    /// Default ctor
    /// </summary>
    public RowPlainTextRendererElement(Row row) 
    {
        _row = row;
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public void RenderIt(ITextDocumentRenderer renderer)
    {
        //renderer.Content.Append('|');
        //DocumentRendererHelper.RenderCellsToPlain(renderer, _row.Cells);
        //renderer.Content.Append($"{Environment.NewLine}");
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    /// <param name="rows">Current row list</param>
    public void RenderToString(ITextDocumentRenderer renderer, List<List<string>> rows)
    {
        var row = new List<string>();
        DocumentRendererHelper.RenderCellsToPlain(renderer, _row.Cells, row);
        rows.Add(row);
    }
}