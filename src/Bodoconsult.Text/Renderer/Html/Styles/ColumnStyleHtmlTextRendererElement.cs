// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Interfaces;
using System.Text;

namespace Bodoconsult.Text.Renderer.Html.Styles;

/// <summary>
/// HTML rendering element for <see cref="ColumnStyle"/> instances
/// </summary>
public class ColumnStyleHtmlTextRendererElement : HtmlStyleTextRendererElementBase
{
    private readonly ColumnStyle _columnStyle;

    /// <summary>
    /// Default ctor
    /// </summary>
    public ColumnStyleHtmlTextRendererElement(ColumnStyle columnStyle)
    {
        _columnStyle = columnStyle;
        ClassName = "ColumnStyle";
    }

    /// <summary>
    /// Render the element
    /// </summary>
    /// <param name="renderer">Current renderer</param>
    public override void RenderIt(ITextDocumentRenderer renderer)
    {
        var sb = new StringBuilder();

        sb.AppendLine($".{_columnStyle.GetType().Name}");
        sb.AppendLine("{");

        sb.AppendLine("}");
        renderer.Content.Append(sb);
    }
}