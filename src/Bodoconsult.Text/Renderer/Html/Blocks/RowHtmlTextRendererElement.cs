// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Helpers;
using Bodoconsult.Text.Interfaces;
using System;

namespace Bodoconsult.Text.Renderer.Html;

/// <summary>
/// HTML rendering element for <see cref="Row"/> instances
/// </summary>
public class RowHtmlTextRendererElement : HtmlTextRendererElementBase
{
    private readonly Row _row;

    /// <summary>
    /// Default ctor
    /// </summary>
    public RowHtmlTextRendererElement(Row row) : base(row)
    {
        _row = row;
        ClassName = "RowStyle";
        TagToUse = "tr";
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        if (string.IsNullOrEmpty(LocalCss))
        {
            renderer.Content.AppendLine($"<{TagToUse} class=\"{ClassName}\">");
        }
        else
        {
            renderer.Content.AppendLine($"<{TagToUse} class=\"{ClassName}\" style=\"{LocalCss}\">");
        }



        DocumentRendererHelper.RenderCellsToHtml(renderer, _row.Cells);

        renderer.Content.Append($"</{TagToUse}>{Environment.NewLine}");
    }
}