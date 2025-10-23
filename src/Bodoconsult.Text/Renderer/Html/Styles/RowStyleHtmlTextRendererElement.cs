// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using System.Text;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="RowStyle"/> instances
/// </summary>
public class RowStyleHtmlTextRendererElement : HtmlStyleTextRendererElementBase
{
    private readonly RowStyle _rowStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public RowStyleHtmlTextRendererElement(RowStyle rowStyle)
    {
        _rowStyle = rowStyle;
        ClassName = "RowStyle";
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        var sb = new StringBuilder();

        sb.AppendLine($".{_rowStyle.GetType().Name}");
        sb.AppendLine("{");

        sb.AppendLine("}");
        renderer.Content.Append(sb);
    }
}